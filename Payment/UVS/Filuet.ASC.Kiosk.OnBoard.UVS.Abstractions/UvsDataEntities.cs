using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Configuration;
using System.Net.NetworkInformation;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class UvsDataEntities : DbContext
    {
        public UvsDataEntities()
        {
        }

        public UvsDataEntities(DbContextOptions<UvsDataEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeVerification> AgeVerification { get; set; }
        public virtual DbSet<AnnulHead> AnnulHead { get; set; }
        public virtual DbSet<AnnulLine> AnnulLine { get; set; }
        public virtual DbSet<Aparatai> Aparatai { get; set; }
        public virtual DbSet<AparatoGrupes> AparatoGrupes { get; set; }
        public virtual DbSet<Ataskaitos> Ataskaitos { get; set; }
        public virtual DbSet<Attributes> Attributes { get; set; }
        public virtual DbSet<AurimasNk> AurimasNk { get; set; }
        public virtual DbSet<BarKodai> BarKodai { get; set; }
        public virtual DbSet<CashierLogs> CashierLogs { get; set; }
        public virtual DbSet<CatPictures> CatPictures { get; set; }
        public virtual DbSet<ClientInfo> ClientInfo { get; set; }
        public virtual DbSet<CompPlu> CompPlu { get; set; }
        public virtual DbSet<CouponActivate> CouponActivate { get; set; }
        public virtual DbSet<EuroStages> EuroStages { get; set; }
        public virtual DbSet<GetBarcodeByPrekesId> GetBarcodeByPrekesId { get; set; }
        public virtual DbSet<GetGrupeById> GetGrupeById { get; set; }
        public virtual DbSet<GetKasininkasById> GetKasininkasById { get; set; }
        public virtual DbSet<GetKorteleById> GetKorteleById { get; set; }
        public virtual DbSet<GetLastKvitoNr> GetLastKvitoNr { get; set; }
        public virtual DbSet<GetMatasById> GetMatasById { get; set; }
        public virtual DbSet<GetPrekeById> GetPrekeById { get; set; }
        public virtual DbSet<GetPrekesIdbyLaikas1> GetPrekesIdbyLaikas1 { get; set; }
        public virtual DbSet<GetPrekesIdbyLaikas2> GetPrekesIdbyLaikas2 { get; set; }
        public virtual DbSet<GetStartParamByApId> GetStartParamByApId { get; set; }
        public virtual DbSet<GroupsDeps> GroupsDeps { get; set; }
        public virtual DbSet<Grupes> Grupes { get; set; }
        public virtual DbSet<GrupesScan> GrupesScan { get; set; }
        public virtual DbSet<InactivityTime> InactivityTime { get; set; }
        public virtual DbSet<Inkasac> Inkasac { get; set; }
        public virtual DbSet<Kasininkai> Kasininkai { get; set; }
        public virtual DbSet<KasininkaiScan> KasininkaiScan { get; set; }
        public virtual DbSet<Korteles> Korteles { get; set; }
        public virtual DbSet<KupList> KupList { get; set; }
        public virtual DbSet<KvitaiJoin> KvitaiJoin { get; set; }
        public virtual DbSet<KvitoEilute> KvitoEilute { get; set; }
        public virtual DbSet<KvitoGalva> KvitoGalva { get; set; }
        public virtual DbSet<LastChecks> LastChecks { get; set; }
        public virtual DbSet<LastVnr> LastVnr { get; set; }
        public virtual DbSet<LastZnr> LastZnr { get; set; }
        public virtual DbSet<LogAs> LogAs { get; set; }
        public virtual DbSet<MataiScan> MataiScan { get; set; }
        public virtual DbSet<MatavimoVienetai> MatavimoVienetai { get; set; }
        public virtual DbSet<MaxKvitai> MaxKvitai { get; set; }
        public virtual DbSet<Mokesciai> Mokesciai { get; set; }
        public virtual DbSet<NaujienosSvarstyklems> NaujienosSvarstyklems { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentBank> PaymentBank { get; set; }
        public virtual DbSet<PluAttributeAssigments> PluAttributeAssigments { get; set; }
        public virtual DbSet<Plupictures> Plupictures { get; set; }
        public virtual DbSet<Pluset> Plusets { get; set; }
        public virtual DbSet<PlusetAttribute> PlusetAttributes { get; set; }
        public virtual DbSet<PlusetLineAttributes> PlusetLineAttributes { get; set; }
        public virtual DbSet<PlusetLine> PlusetLines { get; set; }
        public virtual DbSet<PointsHeaders> PointsHeaders { get; set; }
        public virtual DbSet<PointsItems> PointsItems { get; set; }
        public virtual DbSet<Preke> Prekes { get; set; }
        public virtual DbSet<Prekes2> Prekes2 { get; set; }
        public virtual DbSet<PrekesIstorija> PrekesIstorija { get; set; }
        public virtual DbSet<PrekesIstorijosOperacijos> PrekesIstorijosOperacijos { get; set; }
        public virtual DbSet<PrekesScan> PrekesScan { get; set; }
        public virtual DbSet<PriceDiscountsItem> PriceDiscountsItems { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
        public virtual DbSet<ReceiptHeadAttributeAssignments> ReceiptHeadAttributeAssignments { get; set; }
        public virtual DbSet<ReceiptHeadAttributes> ReceiptHeadAttributes { get; set; }
        public virtual DbSet<ReceiptLineAttributes> ReceiptLineAttributes { get; set; }
        public virtual DbSet<Reward> Reward { get; set; }
        public virtual DbSet<SellDiscount> SellDiscounts { get; set; }
        public virtual DbSet<SellEntry> SellEntry { get; set; }
        public virtual DbSet<Skaitliukai> Skaitliukai { get; set; }
        public virtual DbSet<StartLikuciai> StartLikuciai { get; set; }
        public virtual DbSet<StartParam> StartParam { get; set; }
        public virtual DbSet<Talpos> Talpos { get; set; }
        public virtual DbSet<TalposCfg> TalposCfg { get; set; }
        public virtual DbSet<Terminals> Terminals { get; set; }
        public virtual DbSet<Tiekejai> Tiekejai { get; set; }
        public virtual DbSet<TimeStamp> TimeStamps { get; set; }
        public virtual DbSet<TomraAllowedDeps> TomraAllowedDeps { get; set; }
        public virtual DbSet<TomraBarcode> TomraBarcodes { get; set; }
        public virtual DbSet<TomraLog> TomraLog { get; set; }
        public virtual DbSet<UpdateFh> UpdateFh { get; set; }
        public virtual DbSet<UpdatePlu> UpdatePlu { get; set; }
        public virtual DbSet<UpdateTax> UpdateTax { get; set; }
        public virtual DbSet<Utility> Utility { get; set; }
        public virtual DbSet<Vaztarasciai> Vaztarasciai { get; set; }
        public virtual DbSet<VaztarascioEilute> VaztarascioEilute { get; set; }
        public virtual DbSet<View1> View1 { get; set; }
        public virtual DbSet<Zetai> Zetai { get; set; }
        public virtual DbSet<Zetai4> Zetai4 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=rdata;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeVerification>(entity =>
            {
                entity.Property(e => e.Bdate)
                    .HasColumnName("BDate")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Galvos)
                    .WithMany(p => p.AgeVerification)
                    .HasForeignKey(d => d.GalvosId)
                    .HasConstraintName("FK_AgeVerification_KvitoGalva");
            });

            modelBuilder.Entity<AnnulHead>(entity =>
            {
                entity.HasIndex(e => new { e.Posid, e.IdOnPos })
                    .HasName("IX_AnnulHead")
                    .IsUnique();

                entity.Property(e => e.AnnulTime).HasColumnType("datetime");

                entity.Property(e => e.Posid).HasColumnName("POSId");

                entity.Property(e => e.Znr).HasColumnName("ZNr");
            });

            modelBuilder.Entity<AnnulLine>(entity =>
            {
                entity.Property(e => e.BarCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.AnnulLine)
                    .HasForeignKey(d => d.HeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnnulLine_AnnulHead");
            });

            modelBuilder.Entity<Aparatai>(entity =>
            {
                entity.HasKey(e => e.AparatoId);

                entity.HasIndex(e => e.AparatoNr)
                    .HasName("AparatoNr")
                    .IsUnique();

                entity.Property(e => e.AparatoId)
                    .HasColumnName("AparatoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AparatoNr).HasDefaultValueSql("((0))");

                entity.Property(e => e.AparatoPavadinimas).HasMaxLength(50);

                entity.Property(e => e.Cpufreq).HasColumnName("CPUFreq");

                entity.Property(e => e.Cpuname)
                    .HasColumnName("CPUName")
                    .HasMaxLength(255);

                entity.Property(e => e.Dep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fbversion)
                    .HasColumnName("FBVersion")
                    .HasMaxLength(10);

                entity.Property(e => e.Fnumber)
                    .HasColumnName("FNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.HardDriveModel).HasMaxLength(255);

                entity.Property(e => e.HardDriveSerial).HasMaxLength(255);

                entity.Property(e => e.HardDriveSizeMb).HasColumnName("HardDriveSize_Mb");

                entity.Property(e => e.Ipadress)
                    .HasColumnName("IPAdress")
                    .HasMaxLength(50);

                entity.Property(e => e.MyId).HasColumnName("MyID");

                entity.Property(e => e.NodeId).HasColumnName("NodeID");

                entity.Property(e => e.NonUvsnumber).HasColumnName("NonUVSNumber");

                entity.Property(e => e.Posnr).HasColumnName("POSNr");

                entity.Property(e => e.RamMb).HasColumnName("RAM_Mb");

                entity.Property(e => e.Version).HasMaxLength(50);

                entity.Property(e => e.VideoName).HasMaxLength(255);

                entity.Property(e => e.VideoRamKb).HasColumnName("VideoRAM_Kb");
            });

            modelBuilder.Entity<AparatoGrupes>(entity =>
            {
                entity.HasIndex(e => new { e.AparatoId, e.GrupesId })
                    .HasName("IX_AparatoGrupes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.GrupesId).HasColumnName("GrupesID");
            });

            modelBuilder.Entity<Ataskaitos>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iki).HasColumnType("smalldatetime");

                entity.Property(e => e.Nuo).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Attributes>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(25);

                entity.Property(e => e.PossibleValues).HasColumnType("xml");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AurimasNk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Aurimas_NK");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.Barkodas)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KortelesNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BarKodai>(entity =>
            {
                entity.HasIndex(e => new { e.Dep, e.BarCode })
                    .HasName("IX_BarKodai_1");

                entity.HasIndex(e => new { e.Dep, e.PrekesKodas, e.BarCode })
                    .HasName("IX_BarKodai")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BarCode).HasMaxLength(20);

                entity.Property(e => e.Dep).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CashierLogs>(entity =>
            {
                entity.HasIndex(e => new { e.AparatoId, e.IdOnPos })
                    .HasName("IX_CashierLogsApIDidOnPos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LogOffTime).HasColumnType("datetime");

                entity.Property(e => e.LogOnTime).HasColumnType("datetime");

                entity.HasOne(d => d.Aparato)
                    .WithMany(p => p.CashierLogs)
                    .HasForeignKey(d => d.AparatoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AparatoId");
            });

            modelBuilder.Entity<CatPictures>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(200);

                entity.Property(e => e.DocId).HasColumnName("doc_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OpNr).HasColumnName("op_nr");

                entity.Property(e => e.PictureId).HasColumnName("picture_id");

                entity.Property(e => e.ShortCategoryName)
                    .IsRequired()
                    .HasColumnName("short_category_name")
                    .HasMaxLength(24);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tstamp)
                    .IsRequired()
                    .HasColumnName("tstamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ClientInfo>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.HeadId).HasColumnName("HeadID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Template).HasMaxLength(500);

                entity.Property(e => e.Vatcode)
                    .HasColumnName("VATCode")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Head)
                    .WithMany(p => p.ClientInfo)
                    .HasForeignKey(d => d.HeadId)
                    .HasConstraintName("FK_ClientInfo_KvitoGalva");
            });

            modelBuilder.Entity<CompPlu>(entity =>
            {
                entity.ToTable("CompPLU");

                entity.HasIndex(e => new { e.MainCode, e.Dep })
                    .HasName("IX_MainCode");

                entity.HasIndex(e => new { e.SupCode, e.Dep })
                    .HasName("IX_SupCode");

                entity.HasIndex(e => new { e.Dep, e.MainCode, e.SupCode })
                    .HasName("IX_DepMainSup")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Coef).HasDefaultValueSql("((1))");

                entity.Property(e => e.Dep).HasDefaultValueSql("((1))");

                entity.Property(e => e.SupCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CouponActivate>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CouponNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.IdOnPos).HasColumnName("idOnPos");

                entity.Property(e => e.Posid).HasColumnName("POSId");
            });

            modelBuilder.Entity<EuroStages>(entity =>
            {
                entity.Property(e => e.When).HasColumnType("datetime");
            });

            modelBuilder.Entity<GetBarcodeByPrekesId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetBarcodeByPrekesID");

                entity.Property(e => e.BarCode).HasMaxLength(20);
            });

            modelBuilder.Entity<GetGrupeById>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetGrupeByID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.GrupesId)
                    .HasColumnName("GrupesID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.GrupesPav)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<GetKasininkasById>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetKasininkasByID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Kodas)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.Pavarde)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<GetKorteleById>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetKorteleByID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasColumnName("Id number")
                    .HasMaxLength(30);

                entity.Property(e => e.Key1B).HasMaxLength(32);

                entity.Property(e => e.PusePin)
                    .HasColumnName("PusePIN")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<GetLastKvitoNr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetLastKvitoNr");
            });

            modelBuilder.Entity<GetMatasById>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetMatasByID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.Komentaras).HasMaxLength(50);

                entity.Property(e => e.MatoId)
                    .HasColumnName("MatoID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MatoPavad).HasMaxLength(20);
            });

            modelBuilder.Entity<GetPrekeById>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetPrekeByID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.AparataiL).HasMaxLength(30);

                entity.Property(e => e.AparataiL1)
                    .HasColumnName("_AparataiL")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.GlobalId).HasColumnName("GlobalID");

                entity.Property(e => e.GrupesId).HasColumnName("GrupesID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Laikas).HasColumnType("smalldatetime");

                entity.Property(e => e.N1Kiek).HasColumnName("N_1_Kiek");

                entity.Property(e => e.N1Nuo).HasColumnName("N_1_Nuo");

                entity.Property(e => e.N2Kiek).HasColumnName("N_2_Kiek");

                entity.Property(e => e.N2Nuo).HasColumnName("N_2_Nuo");

                entity.Property(e => e.NType).HasColumnName("N_Type");

                entity.Property(e => e.PrekesKomentaras).HasMaxLength(120);

                entity.Property(e => e.PrekesPavadinimas)
                    .IsRequired()
                    .HasMaxLength(90);

                entity.Property(e => e.TiekejoId).HasColumnName("TiekejoID");
            });

            modelBuilder.Entity<GetPrekesIdbyLaikas1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetPrekesIDByLaikas1");

                entity.Property(e => e.MaxId).HasColumnName("maxID");
            });

            modelBuilder.Entity<GetPrekesIdbyLaikas2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetPrekesIDByLaikas2");

                entity.Property(e => e.MinId).HasColumnName("minID");
            });

            modelBuilder.Entity<GetStartParamByApId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetStartParamByApID");

                entity.Property(e => e.ApId).HasColumnName("ApID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Znr).HasColumnName("ZNr");
            });

            modelBuilder.Entity<GroupsDeps>(entity =>
            {
                entity.HasIndex(e => e.Dep)
                    .HasName("Dep");

                entity.HasIndex(e => e.Plugroup)
                    .HasName("PLUGroup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dep).HasMaxLength(50);

                entity.Property(e => e.Pav).HasMaxLength(100);

                entity.Property(e => e.Plugroup)
                    .HasColumnName("PLUGroup")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Grupes>(entity =>
            {
                entity.Property(e => e.GrupesId).HasColumnName("GrupesID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.GrupesPav)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<GrupesScan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GrupesScan");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.GrupesId).HasColumnName("GrupesID");
            });

            modelBuilder.Entity<InactivityTime>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.KvitoEilute)
                    .WithMany(p => p.InactivityTime)
                    .HasForeignKey(d => d.KvitoEiluteId)
                    .HasConstraintName("FK_KvitoEiluteIdIT");
            });

            modelBuilder.Entity<Inkasac>(entity =>
            {
                entity.HasIndex(e => new { e.Posid, e.IdOnPos })
                    .HasName("IX_Inkasac")
                    .IsUnique();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ObjId)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ObjName).HasMaxLength(36);

                entity.Property(e => e.OpName).HasMaxLength(36);

                entity.Property(e => e.OpTime).HasColumnType("datetime");

                entity.Property(e => e.Posid).HasColumnName("POSId");

                entity.Property(e => e.Znr).HasColumnName("ZNr");
            });

            modelBuilder.Entity<Kasininkai>(entity =>
            {
                entity.HasIndex(e => new { e.Dep, e.VidinisNr, e.Id })
                    .HasName("IX_Kasininkai");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aktyvi).HasDefaultValueSql("((1))");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.CardNo).HasMaxLength(100);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.Kodas)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.Pavarde)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<KasininkaiScan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("KasininkaiScan");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Korteles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.BendrasLimitas).HasColumnName("Bendras limitas");

                entity.Property(e => e.Benzinas).HasMaxLength(8);

                entity.Property(e => e.GroupId).HasMaxLength(20);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasColumnName("Id number")
                    .HasMaxLength(30);

                entity.Property(e => e.Key1B).HasMaxLength(32);

                entity.Property(e => e.LimitasDienai).HasColumnName("Limitas dienai");

                entity.Property(e => e.LimitasMenesiui).HasColumnName("Limitas menesiui");

                entity.Property(e => e.MkJudintaDabar).HasColumnName("MK_JudintaDabar");

                entity.Property(e => e.MkMagneticCard).HasColumnName("MK_MagneticCard");

                entity.Property(e => e.PasiustaIcardlista).HasColumnName("PasiustaICardlista");

                entity.Property(e => e.PusePin)
                    .HasColumnName("PusePIN")
                    .HasMaxLength(16);

                entity.Property(e => e.Redaguota).HasColumnType("smalldatetime");

                entity.Property(e => e.Updated).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<KupList>(entity =>
            {
                entity.HasIndex(e => new { e.AparatoId, e.KvitoNr, e.Kuponas })
                    .HasName("IX_KupList")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.Kuponas)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Laikas).HasColumnType("datetime");
            });

            modelBuilder.Entity<KvitaiJoin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("KvitaiJoin");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.KortelesNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KvEid).HasColumnName("KvEID");

                entity.Property(e => e.KvGid).HasColumnName("KvGID");
            });

            modelBuilder.Entity<KvitoEilute>(entity =>
            {
                entity.HasIndex(e => e.GalvosId)
                    .HasName("IX_KvitoEilute");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barkodas)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.GalvosId).HasColumnName("GalvosID");

                entity.Property(e => e.MpvalueGranted).HasColumnName("MPValueGranted");

                entity.Property(e => e.MpvaluePaid).HasColumnName("MPValuePaid");

                entity.Property(e => e.PackerId)
                    .HasColumnName("PackerID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrekesId).HasColumnName("PrekesID");

                entity.Property(e => e.PriceOriginType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StrCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.HasOne(d => d.Galvos)
                    .WithMany(p => p.KvitoEilute)
                    .HasForeignKey(d => d.GalvosId)
                    .HasConstraintName("FK_KvitoEilute_KvitoGalva");
            });

            modelBuilder.Entity<KvitoGalva>(entity =>
            {
                entity.HasIndex(e => e.InvNr);

                entity.HasIndex(e => e.InvNrParent);

                entity.HasIndex(e => new { e.AparatoId, e.KvitoNr })
                    .HasName("IX_KvitoGalva")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.GalvosId).HasColumnName("GalvosID");

                entity.Property(e => e.InvNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InvNrParent)
                    .HasColumnName("InvNr_Parent")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.KortelesNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KvitoNr2)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.NlKort)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PosOrGroupIdParent).HasColumnName("PosOrGroupId_Parent");
            });

            modelBuilder.Entity<LastChecks>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LastChecks");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.AparatoPavadinimas).HasMaxLength(50);
            });

            modelBuilder.Entity<LastVnr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LastVnr");

                entity.Property(e => e.LastVnr1).HasColumnName("LastVnr");
            });

            modelBuilder.Entity<LastZnr>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LastZnr");

                entity.Property(e => e.LastZnr1).HasColumnName("LastZnr");
            });

            modelBuilder.Entity<LogAs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Log'as");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Ivykis).HasMaxLength(150);
            });

            modelBuilder.Entity<MataiScan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MataiScan");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.MatoId).HasColumnName("MatoID");
            });

            modelBuilder.Entity<MatavimoVienetai>(entity =>
            {
                entity.HasKey(e => e.MatoId)
                    .IsClustered(false);

                entity.HasIndex(e => e.MatoKodas)
                    .HasName("IX_MatavimoVienetai")
                    .IsUnique();

                entity.Property(e => e.MatoId).HasColumnName("MatoID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.Komentaras).HasMaxLength(50);

                entity.Property(e => e.MatoPavad).HasMaxLength(20);
            });

            modelBuilder.Entity<MaxKvitai>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MaxKvitai");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.AparatoPavadinimas).HasMaxLength(50);
            });

            modelBuilder.Entity<Mokesciai>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MokescioPavadinimas)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NaujienosSvarstyklems>(entity =>
            {
                entity.HasIndex(e => new { e.PrekK, e.Barcode, e.PrekesEilNr, e.ScGroup })
                    .HasName("IX_NaujienosSvarstyklems")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aprasas2).HasMaxLength(255);

                entity.Property(e => e.Barcode)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.EnergetineVerte).HasMaxLength(255);

                entity.Property(e => e.Gamintojas).HasMaxLength(255);

                entity.Property(e => e.Laikas).HasColumnType("smalldatetime");

                entity.Property(e => e.LaikymoSalygos).HasMaxLength(255);

                entity.Property(e => e.Plugroup)
                    .HasColumnName("PLUGroup")
                    .HasMaxLength(255);

                entity.Property(e => e.PrekesPav).HasMaxLength(255);

                entity.Property(e => e.Sudetis).HasMaxLength(1000);

                entity.Property(e => e.Sudetis2).HasMaxLength(255);

                entity.Property(e => e.TechSalygos).HasMaxLength(255);

                entity.Property(e => e.Ypatybes).HasMaxLength(255);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AllowNonZeroQdeletions).HasColumnName("AllowNonZeroQDeletions");

                entity.Property(e => e.AutoVaztTiekejoId)
                    .HasColumnName("AutoVaztTiekejoID")
                    .HasMaxLength(50);

                entity.Property(e => e.DegalinesId).HasColumnName("DegalinesID");

                entity.Property(e => e.ExportNewCardsPath).HasMaxLength(255);

                entity.Property(e => e.ExternalDb)
                    .HasColumnName("ExternalDB")
                    .HasMaxLength(50);

                entity.Property(e => e.FakturaFooter).HasColumnType("ntext");

                entity.Property(e => e.FakturaHeader).HasColumnType("ntext");

                entity.Property(e => e.FirmosPavadinimas).HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastEcrcounter).HasColumnName("LastECRCounter");

                entity.Property(e => e.LastKavcounter).HasColumnName("LastKAVCounter");

                entity.Property(e => e.LastKvitoIdforSavikaina).HasColumnName("LastKvitoIDForSavikaina");

                entity.Property(e => e.LastLogExportDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastVaztExpId).HasColumnName("LastVaztExpID");

                entity.Property(e => e.OrganizacijosId).HasColumnName("OrganizacijosID");

                entity.Property(e => e.Pvm).HasColumnName("PVM");

                entity.Property(e => e.VaztExportDir).HasMaxLength(255);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasIndex(e => e.GalvosId)
                    .HasName("IX_Payment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthCode)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.CardNo)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.HasOne(d => d.Galvos)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.GalvosId)
                    .HasConstraintName("FK_Payment_KvitoGalva");
            });

            modelBuilder.Entity<PaymentBank>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ci)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.PaymentBank)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_PaymentId");
            });

            modelBuilder.Entity<PluAttributeAssigments>(entity =>
            {
                entity.HasKey(e => new { e.PluCode, e.AttributeId });

                entity.Property(e => e.AttributeId).HasMaxLength(25);

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Plupictures>(entity =>
            {
                entity.ToTable("PLUPictures");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryTitle).HasColumnName("category_title");

                entity.Property(e => e.Dep).HasColumnName("dep");

                entity.Property(e => e.PictureId).HasColumnName("picture_id");

                entity.Property(e => e.PictureSourceId).HasColumnName("picture_source_id");

                entity.Property(e => e.Plu).HasColumnName("plu");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Pluset>(entity =>
            {
                entity.ToTable("PLUSet");

                entity.HasIndex(e => e.Barcode)
                    .HasName("IX_PLUSet_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.Dep, e.SetNo })
                    .HasName("IX_PLUSet")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("barcode")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Createdate)
                    .HasColumnName("createdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Customer)
                    .IsRequired()
                    .HasColumnName("customer")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dep).HasColumnName("dep");

                entity.Property(e => e.Kgid).HasColumnName("KGID");

                entity.Property(e => e.Paytype)
                    .IsRequired()
                    .HasColumnName("paytype")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Pickuplace).HasColumnName("pickuplace");

                entity.Property(e => e.Pricemode).HasColumnName("pricemode");

                entity.Property(e => e.Reservation).HasColumnName("reservation");

                entity.Property(e => e.SetNo).HasColumnName("setNo");
            });

            modelBuilder.Entity<PlusetAttribute>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PLUSetAttributes");

                entity.Property(e => e.AttributeId)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.PlusetId).HasColumnName("PLUSetId");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PlusetLineAttributes>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PLUSetLineAttributes");

                entity.Property(e => e.AttributeId)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.PlusetLineId).HasColumnName("PLUSetLineId");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PlusetLine>(entity =>
            {
                entity.ToTable("PLUSetLines");

                entity.HasIndex(e => e.Barcode)
                    .HasName("IX_PLUSetLines_1");

                entity.HasIndex(e => new { e.Dep, e.Setno, e.Barcode })
                    .HasName("IX_PLUSetLines");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("BARCODE")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dep).HasColumnName("dep");

                entity.Property(e => e.Packcount).HasColumnName("packcount");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Setno).HasColumnName("setno");

                entity.Property(e => e.Tax).HasColumnName("tax");
            });

            modelBuilder.Entity<PointsHeaders>(entity =>
            {
                entity.ToTable("Points_Headers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Galvos)
                    .WithMany(p => p.PointsHeaders)
                    .HasForeignKey(d => d.GalvosId)
                    .HasConstraintName("FK_GalvosIdPH");
            });

            modelBuilder.Entity<PointsItems>(entity =>
            {
                entity.ToTable("Points_Items");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.KvitoEilute)
                    .WithMany(p => p.PointsItems)
                    .HasForeignKey(d => d.KvitoEiluteId)
                    .HasConstraintName("FK_KvitoEiluteIdPI");
            });

            modelBuilder.Entity<Preke>(entity =>
            {
                entity.HasIndex(e => new { e.PrekesKodas, e.Laikas })
                    .HasName("IX_Prekes_Kodas_Laikas");

                entity.HasIndex(e => new { e.Dep, e.PrekesKodas, e.Id })
                    .HasName("IX_Prekes_Dep_Kodas_Akt");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.AparataiL).HasMaxLength(30);

                entity.Property(e => e.AparataiL1)
                    .HasColumnName("_AparataiL")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.Dep).HasDefaultValueSql("((0))");

                entity.Property(e => e.GlobalId).HasColumnName("GlobalID");

                entity.Property(e => e.GrupesId).HasColumnName("GrupesID");

                entity.Property(e => e.Laikas).HasColumnType("smalldatetime");

                entity.Property(e => e.N1Kiek).HasColumnName("N_1_Kiek");

                entity.Property(e => e.N1Nuo).HasColumnName("N_1_Nuo");

                entity.Property(e => e.N2Kiek).HasColumnName("N_2_Kiek");

                entity.Property(e => e.N2Nuo).HasColumnName("N_2_Nuo");

                entity.Property(e => e.NType)
                    .HasColumnName("N_Type")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrekesKomentaras).HasMaxLength(120);

                entity.Property(e => e.PrekesPavadinimas)
                    .IsRequired()
                    .HasMaxLength(90);

                entity.Property(e => e.PriceType).HasDefaultValueSql("((1))");

                entity.Property(e => e.TiekejoId).HasColumnName("TiekejoID");

                entity.Property(e => e.Updating).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Prekes2>(entity =>
            {
                entity.HasIndex(e => e.PrekesId)
                    .HasName("IX_Prekes2PrekesId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasMaxLength(20);

                entity.Property(e => e.ItemGroupId).HasMaxLength(20);

                entity.Property(e => e.ManufacId).HasMaxLength(20);

                entity.Property(e => e.PriceOriginType)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrekesIstorija>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Laikas).HasColumnType("smalldatetime");

                entity.Property(e => e.NewValue).HasMaxLength(255);

                entity.Property(e => e.OldValue).HasMaxLength(255);

                entity.Property(e => e.PrekesId).HasColumnName("PrekesID");
            });

            modelBuilder.Entity<PrekesIstorijosOperacijos>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Operacija).HasMaxLength(50);
            });

            modelBuilder.Entity<PrekesScan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrekesScan");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.AparataiL).HasMaxLength(30);

                entity.Property(e => e.AparataiL1)
                    .HasColumnName("_AparataiL")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<PriceDiscountsItem>(entity =>
            {
                entity.ToTable("Price_Discounts_Items");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.KvitoEilute)
                    .WithMany(p => p.PriceDiscountsItems)
                    .HasForeignKey(d => d.KvitoEiluteId)
                    .HasConstraintName("FK_KvitoEiluteId");

                entity.HasOne(d => d.SellDiscount)
                    .WithMany(p => p.PriceDiscountsItems)
                    .HasForeignKey(d => d.SellDiscountId)
                    .HasConstraintName("FK_SellDiscountId");
            });

            modelBuilder.Entity<Prices>(entity =>
            {
                entity.Property(e => e.FromTime).HasColumnType("datetime");

                entity.Property(e => e.Plucode).HasColumnName("PLUcode");

                entity.Property(e => e.ToTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ReceiptHeadAttributeAssignments>(entity =>
            {
                entity.HasKey(e => e.AttributeId)
                    .HasName("PK__ReceiptH__C18929EA5EAA0504");

                entity.Property(e => e.AttributeId).HasMaxLength(25);

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ReceiptHeadAttributes>(entity =>
            {
                entity.HasIndex(e => e.ReceiptHeadId)
                    .HasName("IX_ReceiptHeadAttributes_RHid");

                entity.Property(e => e.AttributeId)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Value).HasMaxLength(250);
            });

            modelBuilder.Entity<ReceiptLineAttributes>(entity =>
            {
                entity.HasIndex(e => e.ReceiptLineId)
                    .HasName("IX_ReceiptLineAttributes_RLid");

                entity.Property(e => e.AttributeId)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Value).HasMaxLength(250);
            });

            modelBuilder.Entity<Reward>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CouponBarcode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RewardIdentificator)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Galvos)
                    .WithMany(p => p.Reward)
                    .HasForeignKey(d => d.GalvosId)
                    .HasConstraintName("FK_GalvosId");
            });

            modelBuilder.Entity<SellDiscount>(entity =>
            {
                entity.HasIndex(e => e.GalvosId)
                    .HasName("IX_SellDiscount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountTitle).HasMaxLength(100);

                entity.HasOne(d => d.Galvos)
                    .WithMany(p => p.SellDiscount)
                    .HasForeignKey(d => d.GalvosId)
                    .HasConstraintName("FK_SellDiscount_KvitoGalva");
            });

            modelBuilder.Entity<SellEntry>(entity =>
            {
                entity.HasIndex(e => e.GalvosId)
                    .HasName("IX_SellEntry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Entry).HasMaxLength(50);

                entity.HasOne(d => d.Galvos)
                    .WithMany(p => p.SellEntry)
                    .HasForeignKey(d => d.GalvosId)
                    .HasConstraintName("FK_SellEntry_KvitoGalva");
            });

            modelBuilder.Entity<Skaitliukai>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.Idz).HasColumnName("IDZ");

                entity.Property(e => e.Pistoletas)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<StartLikuciai>(entity =>
            {
                entity.HasIndex(e => new { e.ApId, e.PrKodas })
                    .HasName("IX_StartLikuciai")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApId).HasColumnName("ApID");
            });

            modelBuilder.Entity<StartParam>(entity =>
            {
                entity.HasKey(e => e.ApId)
                    .IsClustered(false);

                entity.HasIndex(e => e.ApId)
                    .HasName("IX_StartParam")
                    .IsUnique();

                entity.Property(e => e.ApId)
                    .HasColumnName("ApID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Continue)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Valid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Znr).HasColumnName("ZNr");
            });

            modelBuilder.Entity<Talpos>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MatavimoLaikas).HasColumnType("smalldatetime");

                entity.Property(e => e.PrekyvId).HasColumnName("PrekyvID");
            });

            modelBuilder.Entity<TalposCfg>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Terminals>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.AuthCenter).HasMaxLength(32);

                entity.Property(e => e.Merchant).HasMaxLength(32);

                entity.Property(e => e.Terminal).HasMaxLength(32);
            });

            modelBuilder.Entity<Tiekejai>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Adresas).HasMaxLength(50);

                entity.Property(e => e.BankoKodas).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImKodas).HasMaxLength(14);

                entity.Property(e => e.Pavadinimas).HasMaxLength(50);

                entity.Property(e => e.Pvmkodas)
                    .HasColumnName("PVMKodas")
                    .HasMaxLength(16);

                entity.Property(e => e.Telefonai).HasMaxLength(100);
            });

            modelBuilder.Entity<TimeStamp>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApId).HasColumnName("ApID");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TomraAllowedDeps>(entity =>
            {
                entity.HasKey(e => e.Dep);

                entity.ToTable("Tomra_AllowedDeps");

                entity.Property(e => e.Dep).ValueGeneratedNever();
            });

            modelBuilder.Entity<TomraBarcode>(entity =>
            {
                entity.ToTable("Tomra_Barcodes");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptNr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stan).HasColumnName("STAN");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TerminalId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TomraReceiptId)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TomraLog>(entity =>
            {
                entity.ToTable("Tomra_Log");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Stan).HasColumnName("STAN");

                entity.Property(e => e.TerminalId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.When).HasColumnType("datetime");
            });

            modelBuilder.Entity<UpdateFh>(entity =>
            {
                entity.ToTable("UpdateFH");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Text).HasMaxLength(40);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            });

            modelBuilder.Entity<UpdatePlu>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("UpdatePLU");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Comment)
                    .HasMaxLength(120)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount1qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountType).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupCat).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GroupDiscount1amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupDiscount1qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupDiscount2amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupDiscount2qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Kuras')");

                entity.Property(e => e.GroupTax).HasDefaultValueSql("((1))");

                entity.Property(e => e.Price1).HasColumnType("money");

                entity.Property(e => e.Price2)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price3)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price4)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tax1).HasDefaultValueSql("((18))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(90);

                entity.Property(e => e.ToScales).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('vnt')");

                entity.Property(e => e.UnitScale).HasDefaultValueSql("((0))");

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.Veiksmas).HasDefaultValueSql("((1))");

                entity.Property(e => e.Weighting).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<UpdateTax>(entity =>
            {
                entity.HasIndex(e => e.Mask)
                    .HasName("IX_UpdateTax")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aparatai).HasMaxLength(30);

                entity.Property(e => e.Aparatai1)
                    .HasColumnName("_Aparatai")
                    .HasMaxLength(30);

                entity.Property(e => e.Delete).HasMaxLength(30);

                entity.Property(e => e.Delete1)
                    .HasColumnName("_Delete")
                    .HasMaxLength(30);

                entity.Property(e => e.Title).HasMaxLength(19);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            });

            modelBuilder.Entity<Utility>(entity =>
            {
                entity.HasIndex(e => new { e.GalvosId, e.ServiceBarcode, e.GoodsBarcode, e.EilNr })
                    .HasName("IX_Utility")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GalvosId).HasColumnName("GalvosID");

                entity.Property(e => e.GoodsBarcode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Laikas).HasColumnType("datetime");

                entity.Property(e => e.ServiceBarcode)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vaztarasciai>(entity =>
            {
                entity.HasIndex(e => new { e.AparatoId, e.Vnr })
                    .HasName("IX_Vaztarasciai");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AparatoId).HasColumnName("AparatoID");

                entity.Property(e => e.Data).HasColumnType("smalldatetime");

                entity.Property(e => e.GavimoPvm).HasColumnName("GavimoPVM");

                entity.Property(e => e.Komentaras).HasMaxLength(255);

                entity.Property(e => e.Numeris).HasMaxLength(50);

                entity.Property(e => e.RegistracijosData).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<VaztarascioEilute>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PrekesId).HasColumnName("PrekesID");

                entity.Property(e => e.VaztarascioId).HasColumnName("VaztarascioID");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View1");

                entity.Property(e => e.Expr1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Expr2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Zetai>(entity =>
            {
                entity.HasKey(e => e.Count);

                entity.ToTable("zetai");

                entity.HasIndex(e => new { e.Id, e.Zetas })
                    .HasName("IX_zetai")
                    .IsUnique();

                entity.Property(e => e.Count).HasColumnName("COUNT");

                entity.Property(e => e.Bsapyvarta).HasColumnName("BSapyvarta");

                entity.Property(e => e.Bsgrazinimai).HasColumnName("BSgrazinimai");

                entity.Property(e => e.Bsrealizacija).HasColumnName("BSrealizacija");

                entity.Property(e => e.GrazintaPrekiuGryni).HasColumnName("Grazinta prekiu gryni");

                entity.Property(e => e.GrazintaPrekiuKorteles).HasColumnName("Grazinta prekiu korteles");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iki)
                    .HasColumnName("IKI")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Kada)
                    .HasColumnName("KADA")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.KasaPamainosPabaigoje).HasColumnName("Kasa pamainos pabaigoje");

                entity.Property(e => e.KasaPamainosPradzioje).HasColumnName("Kasa pamainos pradzioje");

                entity.Property(e => e.KitaGryni).HasColumnName("Kita gryni");

                entity.Property(e => e.KitaKort).HasColumnName("Kita kort");

                entity.Property(e => e.Nuo)
                    .HasColumnName("NUO")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.PamainaPerdave)
                    .HasColumnName("Pamaina perdave")
                    .HasMaxLength(20);

                entity.Property(e => e.PamainaPrieme)
                    .HasColumnName("Pamaina prieme")
                    .HasMaxLength(20);

                entity.Property(e => e.RealizacijosSumaGryni).HasColumnName("Realizacijos suma gryni");

                entity.Property(e => e.RealizacijosSumaKorteles).HasColumnName("Realizacijos suma korteles");

                entity.Property(e => e.Sgapyvarta).HasColumnName("SGapyvarta");

                entity.Property(e => e.Sggrazinimai).HasColumnName("SGgrazinimai");

                entity.Property(e => e.Sgrealizacija).HasColumnName("SGrealizacija");

                entity.Property(e => e.Skapyvarta).HasColumnName("SKapyvarta");

                entity.Property(e => e.Skgrazinimai).HasColumnName("SKgrazinimai");

                entity.Property(e => e.Skrealizacija).HasColumnName("SKrealizacija");

                entity.Property(e => e.SuteiktaNuolaidaGryni).HasColumnName("Suteikta nuolaida gryni");

                entity.Property(e => e.SuteiktaNuolaidaKorteles).HasColumnName("Suteikta nuolaida korteles");
            });

            modelBuilder.Entity<Zetai4>(entity =>
            {
                entity.HasIndex(e => new { e.ApId, e.Znr })
                    .HasName("IX_Zetai4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApId).HasColumnName("ApID");

                entity.Property(e => e.EndTime).HasColumnType("smalldatetime");

                entity.Property(e => e.StartTime).HasColumnType("smalldatetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
