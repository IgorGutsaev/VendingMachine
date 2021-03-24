using Serilog.Sinks.File;
using Serilog.Sinks.File.Archive;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filuet.ASC.OnBoard.Kernel.HostApp
{
    public class SerilogHooks: FileLifecycleHooks
    {
        private long _limitBytes;
        private string _pathArchive;
        private int _retainedFileCountLimit;
        private ArchiveHooks MyArchiveHooks;


        public SerilogHooks(long limitBytes,int retainedFileCountLimit, string pathArchive = null, CompressionLevel compression = CompressionLevel.Fastest)
        {
            _limitBytes = limitBytes;

            _pathArchive = pathArchive;

            _retainedFileCountLimit = retainedFileCountLimit;

            if (string.IsNullOrEmpty(_pathArchive))
            {
                _pathArchive = null;
            }

            MyArchiveHooks = new ArchiveHooks(CompressionLevel.Fastest, _pathArchive);
        }

        public override void OnFileDeleting(string path)
        {
            MyArchiveHooks.OnFileDeleting(path);

            if (string.IsNullOrEmpty(_pathArchive))
            {
                _pathArchive = path;
            }

            var dirArchive = Path.GetDirectoryName(_pathArchive);

            var dirLog = Path.GetDirectoryName(path);

            var archFiles = Directory.GetFiles(dirArchive, "*.gz");
            var files = Directory.GetFiles(dirLog, "*.txt");

            long currentSize = 0;
            var countFiles = files.Length;
            do
            {
                countFiles--;

                if (countFiles < files.Length - _retainedFileCountLimit)
                    break;
                currentSize += (new FileInfo(files[countFiles])).Length;
            } while (currentSize < _limitBytes);

            if (currentSize < _limitBytes)
            {
                countFiles = archFiles.Length;

                do
                {
                    countFiles--;
                    if (countFiles < 0)
                        break;
                    currentSize += (new FileInfo(archFiles[countFiles])).Length;                    
                } while (currentSize < _limitBytes);

                if (currentSize > _limitBytes)
                {
                    for (int i = countFiles; i >=0; i--)
                        File.Delete(archFiles[countFiles]);
                }
            }
            else
            {
                foreach (var archFile in archFiles)
                    File.Delete(archFile);

                for (int i = countFiles; i >= 0; i--)
                    File.Delete(files[countFiles]);
            }

            base.OnFileDeleting(path);
        }
    }
}
