using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Kernel.Core
{

    public class Args
    {
        public string outputTemplate { get; set; }
        public string pathFormat { get; set; }
        public string pathArchive { get; set; }
        public int allFilesSizeLimitBytes { get; set; }
        public int fileSizeLimitBytes { get; set; }
        public bool rollOnFileSizeLimit { get; set; }
        public string rollingInterval { get; set; }
        public int retainedFileCountLimit { get; set; }
    }

    public class WriteTo
    {
        public string Name { get; set; }
        public Args Args { get; set; }
    }

    public class SerilogSelection
    {
        public string MinimumLevel { get; set; }
        public List<WriteTo> WriteTo { get; set; }
    }

    public class LogSettings
    {
        public string outputTemplate { get; set; }

        public string pathFormat { get; set; }

        public string pathArchive { get; set; }

        public long allFilesSizeLimitBytes { get; set; }

        public int fileSizeLimitBytes { get; set; }

        public bool rollOnFileSizeLimit { get; set; }
        public string rollingInterval { get; set; }
        public int retainedFileCountLimit { get; set; }
        public string path { get; set; }

        public LogSettings FromArgs(Args args)
        {

            return new LogSettings()
            {
                outputTemplate = args.outputTemplate,
                pathFormat = args.pathFormat,
                pathArchive = args.pathArchive,
                allFilesSizeLimitBytes = args.allFilesSizeLimitBytes,
                fileSizeLimitBytes = args.fileSizeLimitBytes,
                retainedFileCountLimit = args.retainedFileCountLimit,
                rollingInterval = args.rollingInterval,
                rollOnFileSizeLimit = args.rollOnFileSizeLimit
            };


        }
    }
}
