using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class UvsDataEntities : DbContext
    {
        public UvsDataEntities() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Uvs"].ConnectionString);
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        public virtual DbSet<AgeVerification> AgeVerifications { get; set; }
        public virtual DbSet<AnnulHead> AnnulHeads { get; set; }
        public virtual DbSet<AnnulLine> AnnulLines { get; set; }
        public virtual DbSet<Aparatai> Aparatais { get; set; }
        public virtual DbSet<AparatoGrupe> AparatoGrupes { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<BarKodai> BarKodais { get; set; }
        public virtual DbSet<CashierLog> CashierLogs { get; set; }
        public virtual DbSet<CatPicture> CatPictures { get; set; }
        public virtual DbSet<ClientInfo> ClientInfoes { get; set; }
        public virtual DbSet<CompPLU> CompPLUs { get; set; }
        public virtual DbSet<CouponActivate> CouponActivates { get; set; }
        public virtual DbSet<EuroStage> EuroStages { get; set; }
        public virtual DbSet<GroupsDep> GroupsDeps { get; set; }
        public virtual DbSet<Grupe> Grupes { get; set; }
        public virtual DbSet<InactivityTime> InactivityTimes { get; set; }
        public virtual DbSet<Inkasac> Inkasacs { get; set; }
        public virtual DbSet<Kasininkai> Kasininkais { get; set; }
        public virtual DbSet<Kortele> Korteles { get; set; }
        public virtual DbSet<KupList> KupLists { get; set; }
        public virtual DbSet<KvitoEilute> KvitoEilutes { get; set; }
        public virtual DbSet<KvitoGalva> KvitoGalvas { get; set; }
        public virtual DbSet<MatavimoVienetai> MatavimoVienetais { get; set; }
        public virtual DbSet<Mokesciai> Mokesciais { get; set; }
        public virtual DbSet<NaujienosSvarstyklem> NaujienosSvarstyklems { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentBank> PaymentBanks { get; set; }
        public virtual DbSet<PluAttributeAssigment> PluAttributeAssigments { get; set; }
        public virtual DbSet<PLUPicture> PLUPictures { get; set; }
        public virtual DbSet<PLUSet> PLUSets { get; set; }
        public virtual DbSet<PLUSetLine> PLUSetLines { get; set; }
        public virtual DbSet<Points_Headers> Points_Headers { get; set; }
        public virtual DbSet<Points_Items> Points_Items { get; set; }
        public virtual DbSet<Preke> Prekes { get; set; }
        public virtual DbSet<Prekes2> Prekes2 { get; set; }
        public virtual DbSet<Price_Discounts_Items> Price_Discounts_Items { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ReceiptHeadAttributeAssignment> ReceiptHeadAttributeAssignments { get; set; }
        public virtual DbSet<ReceiptHeadAttribute> ReceiptHeadAttributes { get; set; }
        public virtual DbSet<ReceiptLineAttribute> ReceiptLineAttributes { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<SellDiscount> SellDiscounts { get; set; }
        public virtual DbSet<SellEntry> SellEntries { get; set; }
        public virtual DbSet<Skaitliukai> Skaitliukais { get; set; }
        public virtual DbSet<StartLikuciai> StartLikuciais { get; set; }
        public virtual DbSet<StartParam> StartParams { get; set; }
        public virtual DbSet<TimeStamp> TimeStamps { get; set; }
        public virtual DbSet<Tomra_AllowedDeps> Tomra_AllowedDeps { get; set; }
        public virtual DbSet<Tomra_Barcodes> Tomra_Barcodes { get; set; }
        public virtual DbSet<Tomra_Log> Tomra_Log { get; set; }
        public virtual DbSet<UpdateFH> UpdateFHs { get; set; }
        public virtual DbSet<UpdatePLU> UpdatePLUs { get; set; }
        public virtual DbSet<UpdateTax> UpdateTaxes { get; set; }
        public virtual DbSet<Utility> Utilities { get; set; }
        public virtual DbSet<Vaztarasciai> Vaztarasciais { get; set; }
        public virtual DbSet<VaztarascioEilute> VaztarascioEilutes { get; set; }
        public virtual DbSet<zetai> zetais { get; set; }
        public virtual DbSet<Zetai4> Zetai4 { get; set; }
        public virtual DbSet<Ataskaito> Ataskaitos { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<PrekesIstorija> PrekesIstorijas { get; set; }
        public virtual DbSet<Talpos> Talpos { get; set; }
        public virtual DbSet<Tiekejai> Tiekejais { get; set; }
        public virtual DbSet<Aurimas_NK> Aurimas_NK { get; set; }
        public virtual DbSet<GetGrupeByID> GetGrupeByIDs { get; set; }
        public virtual DbSet<GetKasininkasByID> GetKasininkasByIDs { get; set; }
        public virtual DbSet<GetKorteleByID> GetKorteleByIDs { get; set; }
        public virtual DbSet<GetMatasByID> GetMatasByIDs { get; set; }
        public virtual DbSet<GetPrekeByID> GetPrekeByIDs { get; set; }
        public virtual DbSet<GetStartParamByApID> GetStartParamByApIDs { get; set; }
        public virtual DbSet<GrupesScan> GrupesScans { get; set; }
        public virtual DbSet<KasininkaiScan> KasininkaiScans { get; set; }
        public virtual DbSet<KvitaiJoin> KvitaiJoins { get; set; }
        public virtual DbSet<LastCheck> LastChecks { get; set; }
        public virtual DbSet<MataiScan> MataiScans { get; set; }
        public virtual DbSet<MaxKvitai> MaxKvitais { get; set; }
        public virtual DbSet<PrekesScan> PrekesScans { get; set; }
        public virtual DbSet<View1> View1 { get; set; }
        public virtual DbSet<PLUSetAttribute> PLUSetAttributes { get; set; }
        public virtual DbSet<PLUSetLineAttribute> PLUSetLineAttributes { get; set; }
    
        //public virtual int ClearAparatai()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ClearAparatai");
        //}
    
        //public virtual ObjectResult<LastKvitai_Result> LastKvitai()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LastKvitai_Result>("LastKvitai");
        //}
    
        //public virtual int MarkGroupByPLUId(int? pOSId, int? pluId)
        //{
        //    var pOSIdParameter = pOSId.HasValue ?
        //        new ObjectParameter("POSId", pOSId) :
        //        new ObjectParameter("POSId", typeof(int));
    
        //    var pluIdParameter = pluId.HasValue ?
        //        new ObjectParameter("pluId", pluId) :
        //        new ObjectParameter("pluId", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MarkGroupByPLUId", pOSIdParameter, pluIdParameter);
        //}
    
        //public virtual ObjectResult<rq_ReadPreke_Result> rq_ReadPreke(int? prekesID, int? bitoNr)
        //{
        //    var prekesIDParameter = prekesID.HasValue ?
        //        new ObjectParameter("PrekesID", prekesID) :
        //        new ObjectParameter("PrekesID", typeof(int));
    
        //    var bitoNrParameter = bitoNr.HasValue ?
        //        new ObjectParameter("BitoNr", bitoNr) :
        //        new ObjectParameter("BitoNr", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ReadPreke_Result>("rq_ReadPreke", prekesIDParameter, bitoNrParameter);
        //}
    
        //public virtual ObjectResult<rq_ScanCardsAll_Result> rq_ScanCardsAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanCardsAll_Result>("rq_ScanCardsAll");
        //}
    
        //public virtual ObjectResult<rq_ScanGrupes_Result> rq_ScanGrupes()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanGrupes_Result>("rq_ScanGrupes");
        //}
    
        //public virtual ObjectResult<rq_ScanGrupesAll_Result> rq_ScanGrupesAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanGrupesAll_Result>("rq_ScanGrupesAll");
        //}
    
        //public virtual ObjectResult<rq_ScanKasininkai_Result> rq_ScanKasininkai()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanKasininkai_Result>("rq_ScanKasininkai");
        //}
    
        //public virtual ObjectResult<rq_ScanKasininkaiByDep_Result> rq_ScanKasininkaiByDep(int? dep)
        //{
        //    var depParameter = dep.HasValue ?
        //        new ObjectParameter("dep", dep) :
        //        new ObjectParameter("dep", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanKasininkaiByDep_Result>("rq_ScanKasininkaiByDep", depParameter);
        //}
    
        //public virtual ObjectResult<rq_ScanKorteles_Result> rq_ScanKorteles()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanKorteles_Result>("rq_ScanKorteles");
        //}
    
        //public virtual ObjectResult<rq_ScanMatai_Result> rq_ScanMatai()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanMatai_Result>("rq_ScanMatai");
        //}
    
        //public virtual ObjectResult<rq_ScanPrekes_Result> rq_ScanPrekes()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanPrekes_Result>("rq_ScanPrekes");
        //}
    
        //public virtual ObjectResult<rq_ScanPrekesAll_Result> rq_ScanPrekesAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanPrekesAll_Result>("rq_ScanPrekesAll");
        //}
    
        //public virtual ObjectResult<rq_ScanPrekesAllEx_Result> rq_ScanPrekesAllEx()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanPrekesAllEx_Result>("rq_ScanPrekesAllEx");
        //}
    
        //public virtual ObjectResult<rq_ScanPrekesByDep_Result> rq_ScanPrekesByDep(int? dep)
        //{
        //    var depParameter = dep.HasValue ?
        //        new ObjectParameter("dep", dep) :
        //        new ObjectParameter("dep", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<rq_ScanPrekesByDep_Result>("rq_ScanPrekesByDep", depParameter);
        //}
    
        //public virtual int rq_SetBitByVal(int? baitas, int? bitas, int? bval, ObjectParameter data)
        //{
        //    var baitasParameter = baitas.HasValue ?
        //        new ObjectParameter("baitas", baitas) :
        //        new ObjectParameter("baitas", typeof(int));
    
        //    var bitasParameter = bitas.HasValue ?
        //        new ObjectParameter("bitas", bitas) :
        //        new ObjectParameter("bitas", typeof(int));
    
        //    var bvalParameter = bval.HasValue ?
        //        new ObjectParameter("bval", bval) :
        //        new ObjectParameter("bval", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_SetBitByVal", baitasParameter, bitasParameter, bvalParameter, data);
        //}
    
        //public virtual int rq_SetPOSBits(int? pOSId)
        //{
        //    var pOSIdParameter = pOSId.HasValue ?
        //        new ObjectParameter("POSId", pOSId) :
        //        new ObjectParameter("POSId", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_SetPOSBits", pOSIdParameter);
        //}
    
        //public virtual int rq_SetPOSBitsPictures(int? pOSId)
        //{
        //    var pOSIdParameter = pOSId.HasValue ?
        //        new ObjectParameter("POSId", pOSId) :
        //        new ObjectParameter("POSId", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_SetPOSBitsPictures", pOSIdParameter);
        //}
    
        //public virtual int rq_StoreAnnulHead(int? pOSId, int? idOnPos, int? checkNr, int? zNr, int? cashierId, DateTime? annulTime, int? annulType, ObjectParameter iD)
        //{
        //    var pOSIdParameter = pOSId.HasValue ?
        //        new ObjectParameter("POSId", pOSId) :
        //        new ObjectParameter("POSId", typeof(int));
    
        //    var idOnPosParameter = idOnPos.HasValue ?
        //        new ObjectParameter("IdOnPos", idOnPos) :
        //        new ObjectParameter("IdOnPos", typeof(int));
    
        //    var checkNrParameter = checkNr.HasValue ?
        //        new ObjectParameter("CheckNr", checkNr) :
        //        new ObjectParameter("CheckNr", typeof(int));
    
        //    var zNrParameter = zNr.HasValue ?
        //        new ObjectParameter("ZNr", zNr) :
        //        new ObjectParameter("ZNr", typeof(int));
    
        //    var cashierIdParameter = cashierId.HasValue ?
        //        new ObjectParameter("CashierId", cashierId) :
        //        new ObjectParameter("CashierId", typeof(int));
    
        //    var annulTimeParameter = annulTime.HasValue ?
        //        new ObjectParameter("AnnulTime", annulTime) :
        //        new ObjectParameter("AnnulTime", typeof(System.DateTime));
    
        //    var annulTypeParameter = annulType.HasValue ?
        //        new ObjectParameter("AnnulType", annulType) :
        //        new ObjectParameter("AnnulType", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreAnnulHead", pOSIdParameter, idOnPosParameter, checkNrParameter, zNrParameter, cashierIdParameter, annulTimeParameter, annulTypeParameter, iD);
        //}
    
        //public virtual int rq_StoreAnnulLine(int? headId, int? lineNumber, double? price, double? amount, double? count, double? discount, double? vatAmount, int? vatType, string barCode, double? packCount, double? realPrice, int? priceOption, ObjectParameter iD)
        //{
        //    var headIdParameter = headId.HasValue ?
        //        new ObjectParameter("HeadId", headId) :
        //        new ObjectParameter("HeadId", typeof(int));
    
        //    var lineNumberParameter = lineNumber.HasValue ?
        //        new ObjectParameter("LineNumber", lineNumber) :
        //        new ObjectParameter("LineNumber", typeof(int));
    
        //    var priceParameter = price.HasValue ?
        //        new ObjectParameter("Price", price) :
        //        new ObjectParameter("Price", typeof(double));
    
        //    var amountParameter = amount.HasValue ?
        //        new ObjectParameter("Amount", amount) :
        //        new ObjectParameter("Amount", typeof(double));
    
        //    var countParameter = count.HasValue ?
        //        new ObjectParameter("Count", count) :
        //        new ObjectParameter("Count", typeof(double));
    
        //    var discountParameter = discount.HasValue ?
        //        new ObjectParameter("Discount", discount) :
        //        new ObjectParameter("Discount", typeof(double));
    
        //    var vatAmountParameter = vatAmount.HasValue ?
        //        new ObjectParameter("VatAmount", vatAmount) :
        //        new ObjectParameter("VatAmount", typeof(double));
    
        //    var vatTypeParameter = vatType.HasValue ?
        //        new ObjectParameter("VatType", vatType) :
        //        new ObjectParameter("VatType", typeof(int));
    
        //    var barCodeParameter = barCode != null ?
        //        new ObjectParameter("BarCode", barCode) :
        //        new ObjectParameter("BarCode", typeof(string));
    
        //    var packCountParameter = packCount.HasValue ?
        //        new ObjectParameter("PackCount", packCount) :
        //        new ObjectParameter("PackCount", typeof(double));
    
        //    var realPriceParameter = realPrice.HasValue ?
        //        new ObjectParameter("RealPrice", realPrice) :
        //        new ObjectParameter("RealPrice", typeof(double));
    
        //    var priceOptionParameter = priceOption.HasValue ?
        //        new ObjectParameter("PriceOption", priceOption) :
        //        new ObjectParameter("PriceOption", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreAnnulLine", headIdParameter, lineNumberParameter, priceParameter, amountParameter, countParameter, discountParameter, vatAmountParameter, vatTypeParameter, barCodeParameter, packCountParameter, realPriceParameter, priceOptionParameter, iD);
        //}
    
        //public virtual int rq_StoreAparatasVersion(int? apId, string version, string fiskalNr, string fiskalVersion)
        //{
        //    var apIdParameter = apId.HasValue ?
        //        new ObjectParameter("ApId", apId) :
        //        new ObjectParameter("ApId", typeof(int));
    
        //    var versionParameter = version != null ?
        //        new ObjectParameter("version", version) :
        //        new ObjectParameter("version", typeof(string));
    
        //    var fiskalNrParameter = fiskalNr != null ?
        //        new ObjectParameter("fiskalNr", fiskalNr) :
        //        new ObjectParameter("fiskalNr", typeof(string));
    
        //    var fiskalVersionParameter = fiskalVersion != null ?
        //        new ObjectParameter("fiskalVersion", fiskalVersion) :
        //        new ObjectParameter("fiskalVersion", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreAparatasVersion", apIdParameter, versionParameter, fiskalNrParameter, fiskalVersionParameter);
        //}
    
        //public virtual int rq_StoreAparatasVersionHw(int? apId, string version, string fiskalNr, string fiskalVersion, string cPUName, int? cPUFreq, string hardDriveModel, string hardDriveSerial, double? hardDriveSize_Mb, string videoName, int? videoRAM_Kb, int? rAM_Mb)
        //{
        //    var apIdParameter = apId.HasValue ?
        //        new ObjectParameter("ApId", apId) :
        //        new ObjectParameter("ApId", typeof(int));
    
        //    var versionParameter = version != null ?
        //        new ObjectParameter("version", version) :
        //        new ObjectParameter("version", typeof(string));
    
        //    var fiskalNrParameter = fiskalNr != null ?
        //        new ObjectParameter("fiskalNr", fiskalNr) :
        //        new ObjectParameter("fiskalNr", typeof(string));
    
        //    var fiskalVersionParameter = fiskalVersion != null ?
        //        new ObjectParameter("fiskalVersion", fiskalVersion) :
        //        new ObjectParameter("fiskalVersion", typeof(string));
    
        //    var cPUNameParameter = cPUName != null ?
        //        new ObjectParameter("CPUName", cPUName) :
        //        new ObjectParameter("CPUName", typeof(string));
    
        //    var cPUFreqParameter = cPUFreq.HasValue ?
        //        new ObjectParameter("CPUFreq", cPUFreq) :
        //        new ObjectParameter("CPUFreq", typeof(int));
    
        //    var hardDriveModelParameter = hardDriveModel != null ?
        //        new ObjectParameter("HardDriveModel", hardDriveModel) :
        //        new ObjectParameter("HardDriveModel", typeof(string));
    
        //    var hardDriveSerialParameter = hardDriveSerial != null ?
        //        new ObjectParameter("HardDriveSerial", hardDriveSerial) :
        //        new ObjectParameter("HardDriveSerial", typeof(string));
    
        //    var hardDriveSize_MbParameter = hardDriveSize_Mb.HasValue ?
        //        new ObjectParameter("HardDriveSize_Mb", hardDriveSize_Mb) :
        //        new ObjectParameter("HardDriveSize_Mb", typeof(double));
    
        //    var videoNameParameter = videoName != null ?
        //        new ObjectParameter("VideoName", videoName) :
        //        new ObjectParameter("VideoName", typeof(string));
    
        //    var videoRAM_KbParameter = videoRAM_Kb.HasValue ?
        //        new ObjectParameter("VideoRAM_Kb", videoRAM_Kb) :
        //        new ObjectParameter("VideoRAM_Kb", typeof(int));
    
        //    var rAM_MbParameter = rAM_Mb.HasValue ?
        //        new ObjectParameter("RAM_Mb", rAM_Mb) :
        //        new ObjectParameter("RAM_Mb", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreAparatasVersionHw", apIdParameter, versionParameter, fiskalNrParameter, fiskalVersionParameter, cPUNameParameter, cPUFreqParameter, hardDriveModelParameter, hardDriveSerialParameter, hardDriveSize_MbParameter, videoNameParameter, videoRAM_KbParameter, rAM_MbParameter);
        //}
    
        //public virtual int rq_StoreCashierLog(int? cashierId, int? aparatoId, DateTime? logOnTime, DateTime? logOffTime, int? idOnPos, ObjectParameter iD)
        //{
        //    var cashierIdParameter = cashierId.HasValue ?
        //        new ObjectParameter("CashierId", cashierId) :
        //        new ObjectParameter("CashierId", typeof(int));
    
        //    var aparatoIdParameter = aparatoId.HasValue ?
        //        new ObjectParameter("AparatoId", aparatoId) :
        //        new ObjectParameter("AparatoId", typeof(int));
    
        //    var logOnTimeParameter = logOnTime.HasValue ?
        //        new ObjectParameter("LogOnTime", logOnTime) :
        //        new ObjectParameter("LogOnTime", typeof(System.DateTime));
    
        //    var logOffTimeParameter = logOffTime.HasValue ?
        //        new ObjectParameter("LogOffTime", logOffTime) :
        //        new ObjectParameter("LogOffTime", typeof(System.DateTime));
    
        //    var idOnPosParameter = idOnPos.HasValue ?
        //        new ObjectParameter("IdOnPos", idOnPos) :
        //        new ObjectParameter("IdOnPos", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreCashierLog", cashierIdParameter, aparatoIdParameter, logOnTimeParameter, logOffTimeParameter, idOnPosParameter, iD);
        //}
    
        //public virtual int rq_StoreCouponActivate(int? idOnPos, int? pOSId, DateTime? opTime, double? balance, int? cashierId, int? receiptNr, string couponNumber, int? clientId, ObjectParameter iD)
        //{
        //    var idOnPosParameter = idOnPos.HasValue ?
        //        new ObjectParameter("IdOnPos", idOnPos) :
        //        new ObjectParameter("IdOnPos", typeof(int));
    
        //    var pOSIdParameter = pOSId.HasValue ?
        //        new ObjectParameter("POSId", pOSId) :
        //        new ObjectParameter("POSId", typeof(int));
    
        //    var opTimeParameter = opTime.HasValue ?
        //        new ObjectParameter("OpTime", opTime) :
        //        new ObjectParameter("OpTime", typeof(System.DateTime));
    
        //    var balanceParameter = balance.HasValue ?
        //        new ObjectParameter("balance", balance) :
        //        new ObjectParameter("balance", typeof(double));
    
        //    var cashierIdParameter = cashierId.HasValue ?
        //        new ObjectParameter("CashierId", cashierId) :
        //        new ObjectParameter("CashierId", typeof(int));
    
        //    var receiptNrParameter = receiptNr.HasValue ?
        //        new ObjectParameter("ReceiptNr", receiptNr) :
        //        new ObjectParameter("ReceiptNr", typeof(int));
    
        //    var couponNumberParameter = couponNumber != null ?
        //        new ObjectParameter("CouponNumber", couponNumber) :
        //        new ObjectParameter("CouponNumber", typeof(string));
    
        //    var clientIdParameter = clientId.HasValue ?
        //        new ObjectParameter("ClientId", clientId) :
        //        new ObjectParameter("ClientId", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreCouponActivate", idOnPosParameter, pOSIdParameter, opTimeParameter, balanceParameter, cashierIdParameter, receiptNrParameter, couponNumberParameter, clientIdParameter, iD);
        //}
    
        //public virtual int rq_StoreEuroStage(int? posId, int? stageNr, DateTime? when)
        //{
        //    var posIdParameter = posId.HasValue ?
        //        new ObjectParameter("PosId", posId) :
        //        new ObjectParameter("PosId", typeof(int));
    
        //    var stageNrParameter = stageNr.HasValue ?
        //        new ObjectParameter("StageNr", stageNr) :
        //        new ObjectParameter("StageNr", typeof(int));
    
        //    var whenParameter = when.HasValue ?
        //        new ObjectParameter("When", when) :
        //        new ObjectParameter("When", typeof(System.DateTime));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreEuroStage", posIdParameter, stageNrParameter, whenParameter);
        //}
    
        //public virtual int rq_StoreInactivityTime(int? kvitoEiluteId, double? duration, ObjectParameter iD)
        //{
        //    var kvitoEiluteIdParameter = kvitoEiluteId.HasValue ?
        //        new ObjectParameter("KvitoEiluteId", kvitoEiluteId) :
        //        new ObjectParameter("KvitoEiluteId", typeof(int));
    
        //    var durationParameter = duration.HasValue ?
        //        new ObjectParameter("Duration", duration) :
        //        new ObjectParameter("Duration", typeof(double));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreInactivityTime", kvitoEiluteIdParameter, durationParameter, iD);
        //}
    
        //public virtual int rq_StoreInkasac(int? idOnPos, int? pOSId, DateTime? opTime, double? amount, int? opType, int? zNr, int? cashierId, ObjectParameter iD)
        //{
        //    var idOnPosParameter = idOnPos.HasValue ?
        //        new ObjectParameter("IdOnPos", idOnPos) :
        //        new ObjectParameter("IdOnPos", typeof(int));
    
        //    var pOSIdParameter = pOSId.HasValue ?
        //        new ObjectParameter("POSId", pOSId) :
        //        new ObjectParameter("POSId", typeof(int));
    
        //    var opTimeParameter = opTime.HasValue ?
        //        new ObjectParameter("OpTime", opTime) :
        //        new ObjectParameter("OpTime", typeof(System.DateTime));
    
        //    var amountParameter = amount.HasValue ?
        //        new ObjectParameter("amount", amount) :
        //        new ObjectParameter("amount", typeof(double));
    
        //    var opTypeParameter = opType.HasValue ?
        //        new ObjectParameter("OpType", opType) :
        //        new ObjectParameter("OpType", typeof(int));
    
        //    var zNrParameter = zNr.HasValue ?
        //        new ObjectParameter("ZNr", zNr) :
        //        new ObjectParameter("ZNr", typeof(int));
    
        //    var cashierIdParameter = cashierId.HasValue ?
        //        new ObjectParameter("CashierId", cashierId) :
        //        new ObjectParameter("CashierId", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreInkasac", idOnPosParameter, pOSIdParameter, opTimeParameter, amountParameter, opTypeParameter, zNrParameter, cashierIdParameter, iD);
        //}
    
        //public virtual int rq_StoreInkasacEx(int? idOnPos, int? pOSId, DateTime? opTime, double? amount, int? opType, int? zNr, int? cashierId, string opName, string objId, string objName, ObjectParameter iD)
        //{
        //    var idOnPosParameter = idOnPos.HasValue ?
        //        new ObjectParameter("IdOnPos", idOnPos) :
        //        new ObjectParameter("IdOnPos", typeof(int));
    
        //    var pOSIdParameter = pOSId.HasValue ?
        //        new ObjectParameter("POSId", pOSId) :
        //        new ObjectParameter("POSId", typeof(int));
    
        //    var opTimeParameter = opTime.HasValue ?
        //        new ObjectParameter("OpTime", opTime) :
        //        new ObjectParameter("OpTime", typeof(System.DateTime));
    
        //    var amountParameter = amount.HasValue ?
        //        new ObjectParameter("amount", amount) :
        //        new ObjectParameter("amount", typeof(double));
    
        //    var opTypeParameter = opType.HasValue ?
        //        new ObjectParameter("OpType", opType) :
        //        new ObjectParameter("OpType", typeof(int));
    
        //    var zNrParameter = zNr.HasValue ?
        //        new ObjectParameter("ZNr", zNr) :
        //        new ObjectParameter("ZNr", typeof(int));
    
        //    var cashierIdParameter = cashierId.HasValue ?
        //        new ObjectParameter("CashierId", cashierId) :
        //        new ObjectParameter("CashierId", typeof(int));
    
        //    var opNameParameter = opName != null ?
        //        new ObjectParameter("OpName", opName) :
        //        new ObjectParameter("OpName", typeof(string));
    
        //    var objIdParameter = objId != null ?
        //        new ObjectParameter("ObjId", objId) :
        //        new ObjectParameter("ObjId", typeof(string));
    
        //    var objNameParameter = objName != null ?
        //        new ObjectParameter("ObjName", objName) :
        //        new ObjectParameter("ObjName", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreInkasacEx", idOnPosParameter, pOSIdParameter, opTimeParameter, amountParameter, opTypeParameter, zNrParameter, cashierIdParameter, opNameParameter, objIdParameter, objNameParameter, iD);
        //}
    
        //public virtual int rq_StoreKvitoEilute(int? galvosID, int? prekesKodas, double? kiekis, double? kaina, double? suma, double? mokesciai, double? nuolaida, int? prekesID, string barkodas, double? vietDez, double? savikaina, double? realKaina, int? priceOption, int? vAT, int? sellFlags, int? lineNumber, ObjectParameter iD)
        //{
        //    var galvosIDParameter = galvosID.HasValue ?
        //        new ObjectParameter("GalvosID", galvosID) :
        //        new ObjectParameter("GalvosID", typeof(int));
    
        //    var prekesKodasParameter = prekesKodas.HasValue ?
        //        new ObjectParameter("PrekesKodas", prekesKodas) :
        //        new ObjectParameter("PrekesKodas", typeof(int));
    
        //    var kiekisParameter = kiekis.HasValue ?
        //        new ObjectParameter("Kiekis", kiekis) :
        //        new ObjectParameter("Kiekis", typeof(double));
    
        //    var kainaParameter = kaina.HasValue ?
        //        new ObjectParameter("Kaina", kaina) :
        //        new ObjectParameter("Kaina", typeof(double));
    
        //    var sumaParameter = suma.HasValue ?
        //        new ObjectParameter("Suma", suma) :
        //        new ObjectParameter("Suma", typeof(double));
    
        //    var mokesciaiParameter = mokesciai.HasValue ?
        //        new ObjectParameter("Mokesciai", mokesciai) :
        //        new ObjectParameter("Mokesciai", typeof(double));
    
        //    var nuolaidaParameter = nuolaida.HasValue ?
        //        new ObjectParameter("Nuolaida", nuolaida) :
        //        new ObjectParameter("Nuolaida", typeof(double));
    
        //    var prekesIDParameter = prekesID.HasValue ?
        //        new ObjectParameter("PrekesID", prekesID) :
        //        new ObjectParameter("PrekesID", typeof(int));
    
        //    var barkodasParameter = barkodas != null ?
        //        new ObjectParameter("Barkodas", barkodas) :
        //        new ObjectParameter("Barkodas", typeof(string));
    
        //    var vietDezParameter = vietDez.HasValue ?
        //        new ObjectParameter("VietDez", vietDez) :
        //        new ObjectParameter("VietDez", typeof(double));
    
        //    var savikainaParameter = savikaina.HasValue ?
        //        new ObjectParameter("Savikaina", savikaina) :
        //        new ObjectParameter("Savikaina", typeof(double));
    
        //    var realKainaParameter = realKaina.HasValue ?
        //        new ObjectParameter("RealKaina", realKaina) :
        //        new ObjectParameter("RealKaina", typeof(double));
    
        //    var priceOptionParameter = priceOption.HasValue ?
        //        new ObjectParameter("PriceOption", priceOption) :
        //        new ObjectParameter("PriceOption", typeof(int));
    
        //    var vATParameter = vAT.HasValue ?
        //        new ObjectParameter("VAT", vAT) :
        //        new ObjectParameter("VAT", typeof(int));
    
        //    var sellFlagsParameter = sellFlags.HasValue ?
        //        new ObjectParameter("SellFlags", sellFlags) :
        //        new ObjectParameter("SellFlags", typeof(int));
    
        //    var lineNumberParameter = lineNumber.HasValue ?
        //        new ObjectParameter("LineNumber", lineNumber) :
        //        new ObjectParameter("LineNumber", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreKvitoEilute", galvosIDParameter, prekesKodasParameter, kiekisParameter, kainaParameter, sumaParameter, mokesciaiParameter, nuolaidaParameter, prekesIDParameter, barkodasParameter, vietDezParameter, savikainaParameter, realKainaParameter, priceOptionParameter, vATParameter, sellFlagsParameter, lineNumberParameter, iD);
        //}
    
        //public virtual int rq_StoreKvitoEiluteEx(int? galvosID, int? prekesKodas, double? kiekis, double? kaina, double? suma, double? mokesciai, double? nuolaida, int? prekesID, string barkodas, double? vietDez, double? savikaina, double? realKaina, int? priceOption, int? vAT, int? sellFlags, int? lineNumber, double? duration, short? priceType, ObjectParameter iD)
        //{
        //    var galvosIDParameter = galvosID.HasValue ?
        //        new ObjectParameter("GalvosID", galvosID) :
        //        new ObjectParameter("GalvosID", typeof(int));
    
        //    var prekesKodasParameter = prekesKodas.HasValue ?
        //        new ObjectParameter("PrekesKodas", prekesKodas) :
        //        new ObjectParameter("PrekesKodas", typeof(int));
    
        //    var kiekisParameter = kiekis.HasValue ?
        //        new ObjectParameter("Kiekis", kiekis) :
        //        new ObjectParameter("Kiekis", typeof(double));
    
        //    var kainaParameter = kaina.HasValue ?
        //        new ObjectParameter("Kaina", kaina) :
        //        new ObjectParameter("Kaina", typeof(double));
    
        //    var sumaParameter = suma.HasValue ?
        //        new ObjectParameter("Suma", suma) :
        //        new ObjectParameter("Suma", typeof(double));
    
        //    var mokesciaiParameter = mokesciai.HasValue ?
        //        new ObjectParameter("Mokesciai", mokesciai) :
        //        new ObjectParameter("Mokesciai", typeof(double));
    
        //    var nuolaidaParameter = nuolaida.HasValue ?
        //        new ObjectParameter("Nuolaida", nuolaida) :
        //        new ObjectParameter("Nuolaida", typeof(double));
    
        //    var prekesIDParameter = prekesID.HasValue ?
        //        new ObjectParameter("PrekesID", prekesID) :
        //        new ObjectParameter("PrekesID", typeof(int));
    
        //    var barkodasParameter = barkodas != null ?
        //        new ObjectParameter("Barkodas", barkodas) :
        //        new ObjectParameter("Barkodas", typeof(string));
    
        //    var vietDezParameter = vietDez.HasValue ?
        //        new ObjectParameter("VietDez", vietDez) :
        //        new ObjectParameter("VietDez", typeof(double));
    
        //    var savikainaParameter = savikaina.HasValue ?
        //        new ObjectParameter("Savikaina", savikaina) :
        //        new ObjectParameter("Savikaina", typeof(double));
    
        //    var realKainaParameter = realKaina.HasValue ?
        //        new ObjectParameter("RealKaina", realKaina) :
        //        new ObjectParameter("RealKaina", typeof(double));
    
        //    var priceOptionParameter = priceOption.HasValue ?
        //        new ObjectParameter("PriceOption", priceOption) :
        //        new ObjectParameter("PriceOption", typeof(int));
    
        //    var vATParameter = vAT.HasValue ?
        //        new ObjectParameter("VAT", vAT) :
        //        new ObjectParameter("VAT", typeof(int));
    
        //    var sellFlagsParameter = sellFlags.HasValue ?
        //        new ObjectParameter("SellFlags", sellFlags) :
        //        new ObjectParameter("SellFlags", typeof(int));
    
        //    var lineNumberParameter = lineNumber.HasValue ?
        //        new ObjectParameter("LineNumber", lineNumber) :
        //        new ObjectParameter("LineNumber", typeof(int));
    
        //    var durationParameter = duration.HasValue ?
        //        new ObjectParameter("Duration", duration) :
        //        new ObjectParameter("Duration", typeof(double));
    
        //    var priceTypeParameter = priceType.HasValue ?
        //        new ObjectParameter("PriceType", priceType) :
        //        new ObjectParameter("PriceType", typeof(short));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreKvitoEiluteEx", galvosIDParameter, prekesKodasParameter, kiekisParameter, kainaParameter, sumaParameter, mokesciaiParameter, nuolaidaParameter, prekesIDParameter, barkodasParameter, vietDezParameter, savikainaParameter, realKainaParameter, priceOptionParameter, vATParameter, sellFlagsParameter, lineNumberParameter, durationParameter, priceTypeParameter, iD);
        //}
    
        //public virtual int rq_StoreKvitoEiluteEx2(int? galvosID, int? prekesKodas, double? kiekis, double? kaina, double? suma, double? mokesciai, double? nuolaida, int? prekesID, string barkodas, double? vietDez, double? savikaina, double? realKaina, int? priceOption, int? vAT, int? sellFlags, int? lineNumber, double? duration, short? priceType, string priceOriginType,long? priceIdentificator, ObjectParameter iD)
        //{
        //    var galvosIDParameter = galvosID.HasValue ?
        //        new ObjectParameter("GalvosID", galvosID) :
        //        new ObjectParameter("GalvosID", typeof(int));
    
        //    var prekesKodasParameter = prekesKodas.HasValue ?
        //        new ObjectParameter("PrekesKodas", prekesKodas) :
        //        new ObjectParameter("PrekesKodas", typeof(int));
    
        //    var kiekisParameter = kiekis.HasValue ?
        //        new ObjectParameter("Kiekis", kiekis) :
        //        new ObjectParameter("Kiekis", typeof(double));
    
        //    var kainaParameter = kaina.HasValue ?
        //        new ObjectParameter("Kaina", kaina) :
        //        new ObjectParameter("Kaina", typeof(double));
    
        //    var sumaParameter = suma.HasValue ?
        //        new ObjectParameter("Suma", suma) :
        //        new ObjectParameter("Suma", typeof(double));
    
        //    var mokesciaiParameter = mokesciai.HasValue ?
        //        new ObjectParameter("Mokesciai", mokesciai) :
        //        new ObjectParameter("Mokesciai", typeof(double));
    
        //    var nuolaidaParameter = nuolaida.HasValue ?
        //        new ObjectParameter("Nuolaida", nuolaida) :
        //        new ObjectParameter("Nuolaida", typeof(double));
    
        //    var prekesIDParameter = prekesID.HasValue ?
        //        new ObjectParameter("PrekesID", prekesID) :
        //        new ObjectParameter("PrekesID", typeof(int));
    
        //    var barkodasParameter = barkodas != null ?
        //        new ObjectParameter("Barkodas", barkodas) :
        //        new ObjectParameter("Barkodas", typeof(string));
    
        //    var vietDezParameter = vietDez.HasValue ?
        //        new ObjectParameter("VietDez", vietDez) :
        //        new ObjectParameter("VietDez", typeof(double));
    
        //    var savikainaParameter = savikaina.HasValue ?
        //        new ObjectParameter("Savikaina", savikaina) :
        //        new ObjectParameter("Savikaina", typeof(double));
    
        //    var realKainaParameter = realKaina.HasValue ?
        //        new ObjectParameter("RealKaina", realKaina) :
        //        new ObjectParameter("RealKaina", typeof(double));
    
        //    var priceOptionParameter = priceOption.HasValue ?
        //        new ObjectParameter("PriceOption", priceOption) :
        //        new ObjectParameter("PriceOption", typeof(int));
    
        //    var vATParameter = vAT.HasValue ?
        //        new ObjectParameter("VAT", vAT) :
        //        new ObjectParameter("VAT", typeof(int));
    
        //    var sellFlagsParameter = sellFlags.HasValue ?
        //        new ObjectParameter("SellFlags", sellFlags) :
        //        new ObjectParameter("SellFlags", typeof(int));
    
        //    var lineNumberParameter = lineNumber.HasValue ?
        //        new ObjectParameter("LineNumber", lineNumber) :
        //        new ObjectParameter("LineNumber", typeof(int));
    
        //    var durationParameter = duration.HasValue ?
        //        new ObjectParameter("Duration", duration) :
        //        new ObjectParameter("Duration", typeof(double));
    
        //    var priceTypeParameter = priceType.HasValue ?
        //        new ObjectParameter("PriceType", priceType) :
        //        new ObjectParameter("PriceType", typeof(short));
    
        //    var priceOriginTypeParameter = priceOriginType != null ?
        //        new ObjectParameter("PriceOriginType", priceOriginType) :
        //        new ObjectParameter("PriceOriginType", typeof(string));
    
        //    var priceIdentificatorParameter = priceIdentificator.HasValue ?
        //        new ObjectParameter("PriceIdentificator", priceIdentificator) :
        //        new ObjectParameter("PriceIdentificator", typeof(long));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreKvitoEiluteEx2", galvosIDParameter, prekesKodasParameter, kiekisParameter, kainaParameter, sumaParameter, mokesciaiParameter, nuolaidaParameter, prekesIDParameter, barkodasParameter, vietDezParameter, savikainaParameter, realKainaParameter, priceOptionParameter, vATParameter, sellFlagsParameter, lineNumberParameter, durationParameter, priceTypeParameter, priceOriginTypeParameter, priceIdentificatorParameter, iD);
        //}
    
        //public virtual int rq_StoreKvitoEiluteEx3(int? galvosID, int? prekesKodas, double? kiekis, double? kaina, double? suma, double? mokesciai, double? nuolaida, int? prekesID, string barkodas, double? vietDez, double? savikaina, double? realKaina, int? priceOption, int? vAT, int? sellFlags, int? lineNumber, double? duration, short? priceType, string priceOriginType,long? priceIdentificator, string packerId, ObjectParameter iD)
        //{
        //    var galvosIDParameter = galvosID.HasValue ?
        //        new ObjectParameter("GalvosID", galvosID) :
        //        new ObjectParameter("GalvosID", typeof(int));
    
        //    var prekesKodasParameter = prekesKodas.HasValue ?
        //        new ObjectParameter("PrekesKodas", prekesKodas) :
        //        new ObjectParameter("PrekesKodas", typeof(int));
    
        //    var kiekisParameter = kiekis.HasValue ?
        //        new ObjectParameter("Kiekis", kiekis) :
        //        new ObjectParameter("Kiekis", typeof(double));
    
        //    var kainaParameter = kaina.HasValue ?
        //        new ObjectParameter("Kaina", kaina) :
        //        new ObjectParameter("Kaina", typeof(double));
    
        //    var sumaParameter = suma.HasValue ?
        //        new ObjectParameter("Suma", suma) :
        //        new ObjectParameter("Suma", typeof(double));
    
        //    var mokesciaiParameter = mokesciai.HasValue ?
        //        new ObjectParameter("Mokesciai", mokesciai) :
        //        new ObjectParameter("Mokesciai", typeof(double));
    
        //    var nuolaidaParameter = nuolaida.HasValue ?
        //        new ObjectParameter("Nuolaida", nuolaida) :
        //        new ObjectParameter("Nuolaida", typeof(double));
    
        //    var prekesIDParameter = prekesID.HasValue ?
        //        new ObjectParameter("PrekesID", prekesID) :
        //        new ObjectParameter("PrekesID", typeof(int));
    
        //    var barkodasParameter = barkodas != null ?
        //        new ObjectParameter("Barkodas", barkodas) :
        //        new ObjectParameter("Barkodas", typeof(string));
    
        //    var vietDezParameter = vietDez.HasValue ?
        //        new ObjectParameter("VietDez", vietDez) :
        //        new ObjectParameter("VietDez", typeof(double));
    
        //    var savikainaParameter = savikaina.HasValue ?
        //        new ObjectParameter("Savikaina", savikaina) :
        //        new ObjectParameter("Savikaina", typeof(double));
    
        //    var realKainaParameter = realKaina.HasValue ?
        //        new ObjectParameter("RealKaina", realKaina) :
        //        new ObjectParameter("RealKaina", typeof(double));
    
        //    var priceOptionParameter = priceOption.HasValue ?
        //        new ObjectParameter("PriceOption", priceOption) :
        //        new ObjectParameter("PriceOption", typeof(int));
    
        //    var vATParameter = vAT.HasValue ?
        //        new ObjectParameter("VAT", vAT) :
        //        new ObjectParameter("VAT", typeof(int));
    
        //    var sellFlagsParameter = sellFlags.HasValue ?
        //        new ObjectParameter("SellFlags", sellFlags) :
        //        new ObjectParameter("SellFlags", typeof(int));
    
        //    var lineNumberParameter = lineNumber.HasValue ?
        //        new ObjectParameter("LineNumber", lineNumber) :
        //        new ObjectParameter("LineNumber", typeof(int));
    
        //    var durationParameter = duration.HasValue ?
        //        new ObjectParameter("Duration", duration) :
        //        new ObjectParameter("Duration", typeof(double));
    
        //    var priceTypeParameter = priceType.HasValue ?
        //        new ObjectParameter("PriceType", priceType) :
        //        new ObjectParameter("PriceType", typeof(short));
    
        //    var priceOriginTypeParameter = priceOriginType != null ?
        //        new ObjectParameter("PriceOriginType", priceOriginType) :
        //        new ObjectParameter("PriceOriginType", typeof(string));
    
        //    var priceIdentificatorParameter = priceIdentificator.HasValue ?
        //        new ObjectParameter("PriceIdentificator", priceIdentificator) :
        //        new ObjectParameter("PriceIdentificator", typeof(long));
    
        //    var packerIdParameter = packerId != null ?
        //        new ObjectParameter("PackerId", packerId) :
        //        new ObjectParameter("PackerId", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreKvitoEiluteEx3", galvosIDParameter, prekesKodasParameter, kiekisParameter, kainaParameter, sumaParameter, mokesciaiParameter, nuolaidaParameter, prekesIDParameter, barkodasParameter, vietDezParameter, savikainaParameter, realKainaParameter, priceOptionParameter, vATParameter, sellFlagsParameter, lineNumberParameter, durationParameter, priceTypeParameter, priceOriginTypeParameter, priceIdentificatorParameter, packerIdParameter, iD);
        //}
    
        //public virtual int rq_StoreKvitoGalva(int? aparatoID, int? kvitoNr, short? year, byte? month, byte? day, byte? hour, byte? minute, byte? apmokejimoRusis, double? suma, double? nuolaida, double? antkainis, double? mokesciai, string kortelesNr, int? kasininkas, int? znr, string kvitoNr2, string nlKort, double? sumaGryni, ObjectParameter iD)
        //{
        //    var aparatoIDParameter = aparatoID.HasValue ?
        //        new ObjectParameter("AparatoID", aparatoID) :
        //        new ObjectParameter("AparatoID", typeof(int));
    
        //    var kvitoNrParameter = kvitoNr.HasValue ?
        //        new ObjectParameter("KvitoNr", kvitoNr) :
        //        new ObjectParameter("KvitoNr", typeof(int));
    
        //    var yearParameter = year.HasValue ?
        //        new ObjectParameter("Year", year) :
        //        new ObjectParameter("Year", typeof(short));
    
        //    var monthParameter = month.HasValue ?
        //        new ObjectParameter("Month", month) :
        //        new ObjectParameter("Month", typeof(byte));
    
        //    var dayParameter = day.HasValue ?
        //        new ObjectParameter("Day", day) :
        //        new ObjectParameter("Day", typeof(byte));
    
        //    var hourParameter = hour.HasValue ?
        //        new ObjectParameter("Hour", hour) :
        //        new ObjectParameter("Hour", typeof(byte));
    
        //    var minuteParameter = minute.HasValue ?
        //        new ObjectParameter("Minute", minute) :
        //        new ObjectParameter("Minute", typeof(byte));
    
        //    var apmokejimoRusisParameter = apmokejimoRusis.HasValue ?
        //        new ObjectParameter("ApmokejimoRusis", apmokejimoRusis) :
        //        new ObjectParameter("ApmokejimoRusis", typeof(byte));
    
        //    var sumaParameter = suma.HasValue ?
        //        new ObjectParameter("Suma", suma) :
        //        new ObjectParameter("Suma", typeof(double));
    
        //    var nuolaidaParameter = nuolaida.HasValue ?
        //        new ObjectParameter("Nuolaida", nuolaida) :
        //        new ObjectParameter("Nuolaida", typeof(double));
    
        //    var antkainisParameter = antkainis.HasValue ?
        //        new ObjectParameter("Antkainis", antkainis) :
        //        new ObjectParameter("Antkainis", typeof(double));
    
        //    var mokesciaiParameter = mokesciai.HasValue ?
        //        new ObjectParameter("Mokesciai", mokesciai) :
        //        new ObjectParameter("Mokesciai", typeof(double));
    
        //    var kortelesNrParameter = kortelesNr != null ?
        //        new ObjectParameter("KortelesNr", kortelesNr) :
        //        new ObjectParameter("KortelesNr", typeof(string));
    
        //    var kasininkasParameter = kasininkas.HasValue ?
        //        new ObjectParameter("Kasininkas", kasininkas) :
        //        new ObjectParameter("Kasininkas", typeof(int));
    
        //    var znrParameter = znr.HasValue ?
        //        new ObjectParameter("Znr", znr) :
        //        new ObjectParameter("Znr", typeof(int));
    
        //    var kvitoNr2Parameter = kvitoNr2 != null ?
        //        new ObjectParameter("KvitoNr2", kvitoNr2) :
        //        new ObjectParameter("KvitoNr2", typeof(string));
    
        //    var nlKortParameter = nlKort != null ?
        //        new ObjectParameter("NlKort", nlKort) :
        //        new ObjectParameter("NlKort", typeof(string));
    
        //    var sumaGryniParameter = sumaGryni.HasValue ?
        //        new ObjectParameter("SumaGryni", sumaGryni) :
        //        new ObjectParameter("SumaGryni", typeof(double));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreKvitoGalva", aparatoIDParameter, kvitoNrParameter, yearParameter, monthParameter, dayParameter, hourParameter, minuteParameter, apmokejimoRusisParameter, sumaParameter, nuolaidaParameter, antkainisParameter, mokesciaiParameter, kortelesNrParameter, kasininkasParameter, znrParameter, kvitoNr2Parameter, nlKortParameter, sumaGryniParameter, iD);
        //}
    
        //public virtual int rq_StoreKvitoGalvaEx(int? aparatoID, int? kvitoNr, short? year, byte? month, byte? day, byte? hour, byte? minute, byte? apmokejimoRusis, double? suma, double? nuolaida, double? antkainis, double? mokesciai, string kortelesNr, int? kasininkas, int? znr, string kvitoNr2, string nlKort, double? sumaGryni, byte? seconds, double? duration, double? durationToPushTotal, ObjectParameter iD)
        //{
        //    var aparatoIDParameter = aparatoID.HasValue ?
        //        new ObjectParameter("AparatoID", aparatoID) :
        //        new ObjectParameter("AparatoID", typeof(int));
    
        //    var kvitoNrParameter = kvitoNr.HasValue ?
        //        new ObjectParameter("KvitoNr", kvitoNr) :
        //        new ObjectParameter("KvitoNr", typeof(int));
    
        //    var yearParameter = year.HasValue ?
        //        new ObjectParameter("Year", year) :
        //        new ObjectParameter("Year", typeof(short));
    
        //    var monthParameter = month.HasValue ?
        //        new ObjectParameter("Month", month) :
        //        new ObjectParameter("Month", typeof(byte));
    
        //    var dayParameter = day.HasValue ?
        //        new ObjectParameter("Day", day) :
        //        new ObjectParameter("Day", typeof(byte));
    
        //    var hourParameter = hour.HasValue ?
        //        new ObjectParameter("Hour", hour) :
        //        new ObjectParameter("Hour", typeof(byte));
    
        //    var minuteParameter = minute.HasValue ?
        //        new ObjectParameter("Minute", minute) :
        //        new ObjectParameter("Minute", typeof(byte));
    
        //    var apmokejimoRusisParameter = apmokejimoRusis.HasValue ?
        //        new ObjectParameter("ApmokejimoRusis", apmokejimoRusis) :
        //        new ObjectParameter("ApmokejimoRusis", typeof(byte));
    
        //    var sumaParameter = suma.HasValue ?
        //        new ObjectParameter("Suma", suma) :
        //        new ObjectParameter("Suma", typeof(double));
    
        //    var nuolaidaParameter = nuolaida.HasValue ?
        //        new ObjectParameter("Nuolaida", nuolaida) :
        //        new ObjectParameter("Nuolaida", typeof(double));
    
        //    var antkainisParameter = antkainis.HasValue ?
        //        new ObjectParameter("Antkainis", antkainis) :
        //        new ObjectParameter("Antkainis", typeof(double));
    
        //    var mokesciaiParameter = mokesciai.HasValue ?
        //        new ObjectParameter("Mokesciai", mokesciai) :
        //        new ObjectParameter("Mokesciai", typeof(double));
    
        //    var kortelesNrParameter = kortelesNr != null ?
        //        new ObjectParameter("KortelesNr", kortelesNr) :
        //        new ObjectParameter("KortelesNr", typeof(string));
    
        //    var kasininkasParameter = kasininkas.HasValue ?
        //        new ObjectParameter("Kasininkas", kasininkas) :
        //        new ObjectParameter("Kasininkas", typeof(int));
    
        //    var znrParameter = znr.HasValue ?
        //        new ObjectParameter("Znr", znr) :
        //        new ObjectParameter("Znr", typeof(int));
    
        //    var kvitoNr2Parameter = kvitoNr2 != null ?
        //        new ObjectParameter("KvitoNr2", kvitoNr2) :
        //        new ObjectParameter("KvitoNr2", typeof(string));
    
        //    var nlKortParameter = nlKort != null ?
        //        new ObjectParameter("NlKort", nlKort) :
        //        new ObjectParameter("NlKort", typeof(string));
    
        //    var sumaGryniParameter = sumaGryni.HasValue ?
        //        new ObjectParameter("SumaGryni", sumaGryni) :
        //        new ObjectParameter("SumaGryni", typeof(double));
    
        //    var secondsParameter = seconds.HasValue ?
        //        new ObjectParameter("Seconds", seconds) :
        //        new ObjectParameter("Seconds", typeof(byte));
    
        //    var durationParameter = duration.HasValue ?
        //        new ObjectParameter("Duration", duration) :
        //        new ObjectParameter("Duration", typeof(double));
    
        //    var durationToPushTotalParameter = durationToPushTotal.HasValue ?
        //        new ObjectParameter("DurationToPushTotal", durationToPushTotal) :
        //        new ObjectParameter("DurationToPushTotal", typeof(double));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreKvitoGalvaEx", aparatoIDParameter, kvitoNrParameter, yearParameter, monthParameter, dayParameter, hourParameter, minuteParameter, apmokejimoRusisParameter, sumaParameter, nuolaidaParameter, antkainisParameter, mokesciaiParameter, kortelesNrParameter, kasininkasParameter, znrParameter, kvitoNr2Parameter, nlKortParameter, sumaGryniParameter, secondsParameter, durationParameter, durationToPushTotalParameter, iD);
        //}
    
        //public virtual int rq_StoreKvitoGalvaEx2(int? aparatoID, int? kvitoNr, short? year, byte? month, byte? day, byte? hour, byte? minute, byte? apmokejimoRusis, double? suma, double? nuolaida, double? antkainis, double? mokesciai, string kortelesNr, int? kasininkas, int? znr, string kvitoNr2, string nlKort, double? sumaGryni, byte? seconds, double? duration, double? durationToPushTotal, int? flags, ObjectParameter iD)
        //{
        //    var aparatoIDParameter = aparatoID.HasValue ?
        //        new ObjectParameter("AparatoID", aparatoID) :
        //        new ObjectParameter("AparatoID", typeof(int));
    
        //    var kvitoNrParameter = kvitoNr.HasValue ?
        //        new ObjectParameter("KvitoNr", kvitoNr) :
        //        new ObjectParameter("KvitoNr", typeof(int));
    
        //    var yearParameter = year.HasValue ?
        //        new ObjectParameter("Year", year) :
        //        new ObjectParameter("Year", typeof(short));
    
        //    var monthParameter = month.HasValue ?
        //        new ObjectParameter("Month", month) :
        //        new ObjectParameter("Month", typeof(byte));
    
        //    var dayParameter = day.HasValue ?
        //        new ObjectParameter("Day", day) :
        //        new ObjectParameter("Day", typeof(byte));
    
        //    var hourParameter = hour.HasValue ?
        //        new ObjectParameter("Hour", hour) :
        //        new ObjectParameter("Hour", typeof(byte));
    
        //    var minuteParameter = minute.HasValue ?
        //        new ObjectParameter("Minute", minute) :
        //        new ObjectParameter("Minute", typeof(byte));
    
        //    var apmokejimoRusisParameter = apmokejimoRusis.HasValue ?
        //        new ObjectParameter("ApmokejimoRusis", apmokejimoRusis) :
        //        new ObjectParameter("ApmokejimoRusis", typeof(byte));
    
        //    var sumaParameter = suma.HasValue ?
        //        new ObjectParameter("Suma", suma) :
        //        new ObjectParameter("Suma", typeof(double));
    
        //    var nuolaidaParameter = nuolaida.HasValue ?
        //        new ObjectParameter("Nuolaida", nuolaida) :
        //        new ObjectParameter("Nuolaida", typeof(double));
    
        //    var antkainisParameter = antkainis.HasValue ?
        //        new ObjectParameter("Antkainis", antkainis) :
        //        new ObjectParameter("Antkainis", typeof(double));
    
        //    var mokesciaiParameter = mokesciai.HasValue ?
        //        new ObjectParameter("Mokesciai", mokesciai) :
        //        new ObjectParameter("Mokesciai", typeof(double));
    
        //    var kortelesNrParameter = kortelesNr != null ?
        //        new ObjectParameter("KortelesNr", kortelesNr) :
        //        new ObjectParameter("KortelesNr", typeof(string));
    
        //    var kasininkasParameter = kasininkas.HasValue ?
        //        new ObjectParameter("Kasininkas", kasininkas) :
        //        new ObjectParameter("Kasininkas", typeof(int));
    
        //    var znrParameter = znr.HasValue ?
        //        new ObjectParameter("Znr", znr) :
        //        new ObjectParameter("Znr", typeof(int));
    
        //    var kvitoNr2Parameter = kvitoNr2 != null ?
        //        new ObjectParameter("KvitoNr2", kvitoNr2) :
        //        new ObjectParameter("KvitoNr2", typeof(string));
    
        //    var nlKortParameter = nlKort != null ?
        //        new ObjectParameter("NlKort", nlKort) :
        //        new ObjectParameter("NlKort", typeof(string));
    
        //    var sumaGryniParameter = sumaGryni.HasValue ?
        //        new ObjectParameter("SumaGryni", sumaGryni) :
        //        new ObjectParameter("SumaGryni", typeof(double));
    
        //    var secondsParameter = seconds.HasValue ?
        //        new ObjectParameter("Seconds", seconds) :
        //        new ObjectParameter("Seconds", typeof(byte));
    
        //    var durationParameter = duration.HasValue ?
        //        new ObjectParameter("Duration", duration) :
        //        new ObjectParameter("Duration", typeof(double));
    
        //    var durationToPushTotalParameter = durationToPushTotal.HasValue ?
        //        new ObjectParameter("DurationToPushTotal", durationToPushTotal) :
        //        new ObjectParameter("DurationToPushTotal", typeof(double));
    
        //    var flagsParameter = flags.HasValue ?
        //        new ObjectParameter("Flags", flags) :
        //        new ObjectParameter("Flags", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreKvitoGalvaEx2", aparatoIDParameter, kvitoNrParameter, yearParameter, monthParameter, dayParameter, hourParameter, minuteParameter, apmokejimoRusisParameter, sumaParameter, nuolaidaParameter, antkainisParameter, mokesciaiParameter, kortelesNrParameter, kasininkasParameter, znrParameter, kvitoNr2Parameter, nlKortParameter, sumaGryniParameter, secondsParameter, durationParameter, durationToPushTotalParameter, flagsParameter, iD);
        //}
    
        //public virtual int rq_StoreKvitoGalvaEx3(int? aparatoID, int? kvitoNr, short? year, byte? month, byte? day, byte? hour, byte? minute, byte? apmokejimoRusis, double? suma, double? nuolaida, double? antkainis, double? mokesciai, string kortelesNr, int? kasininkas, int? znr, string kvitoNr2, string nlKort, double? sumaGryni, byte? seconds, double? duration, double? durationToPushTotal, int? flags, string invNr, ObjectParameter iD)
        //{
        //    var aparatoIDParameter = aparatoID.HasValue ?
        //        new ObjectParameter("AparatoID", aparatoID) :
        //        new ObjectParameter("AparatoID", typeof(int));
    
        //    var kvitoNrParameter = kvitoNr.HasValue ?
        //        new ObjectParameter("KvitoNr", kvitoNr) :
        //        new ObjectParameter("KvitoNr", typeof(int));
    
        //    var yearParameter = year.HasValue ?
        //        new ObjectParameter("Year", year) :
        //        new ObjectParameter("Year", typeof(short));
    
        //    var monthParameter = month.HasValue ?
        //        new ObjectParameter("Month", month) :
        //        new ObjectParameter("Month", typeof(byte));
    
        //    var dayParameter = day.HasValue ?
        //        new ObjectParameter("Day", day) :
        //        new ObjectParameter("Day", typeof(byte));
    
        //    var hourParameter = hour.HasValue ?
        //        new ObjectParameter("Hour", hour) :
        //        new ObjectParameter("Hour", typeof(byte));
    
        //    var minuteParameter = minute.HasValue ?
        //        new ObjectParameter("Minute", minute) :
        //        new ObjectParameter("Minute", typeof(byte));
    
        //    var apmokejimoRusisParameter = apmokejimoRusis.HasValue ?
        //        new ObjectParameter("ApmokejimoRusis", apmokejimoRusis) :
        //        new ObjectParameter("ApmokejimoRusis", typeof(byte));
    
        //    var sumaParameter = suma.HasValue ?
        //        new ObjectParameter("Suma", suma) :
        //        new ObjectParameter("Suma", typeof(double));
    
        //    var nuolaidaParameter = nuolaida.HasValue ?
        //        new ObjectParameter("Nuolaida", nuolaida) :
        //        new ObjectParameter("Nuolaida", typeof(double));
    
        //    var antkainisParameter = antkainis.HasValue ?
        //        new ObjectParameter("Antkainis", antkainis) :
        //        new ObjectParameter("Antkainis", typeof(double));
    
        //    var mokesciaiParameter = mokesciai.HasValue ?
        //        new ObjectParameter("Mokesciai", mokesciai) :
        //        new ObjectParameter("Mokesciai", typeof(double));
    
        //    var kortelesNrParameter = kortelesNr != null ?
        //        new ObjectParameter("KortelesNr", kortelesNr) :
        //        new ObjectParameter("KortelesNr", typeof(string));
    
        //    var kasininkasParameter = kasininkas.HasValue ?
        //        new ObjectParameter("Kasininkas", kasininkas) :
        //        new ObjectParameter("Kasininkas", typeof(int));
    
        //    var znrParameter = znr.HasValue ?
        //        new ObjectParameter("Znr", znr) :
        //        new ObjectParameter("Znr", typeof(int));
    
        //    var kvitoNr2Parameter = kvitoNr2 != null ?
        //        new ObjectParameter("KvitoNr2", kvitoNr2) :
        //        new ObjectParameter("KvitoNr2", typeof(string));
    
        //    var nlKortParameter = nlKort != null ?
        //        new ObjectParameter("NlKort", nlKort) :
        //        new ObjectParameter("NlKort", typeof(string));
    
        //    var sumaGryniParameter = sumaGryni.HasValue ?
        //        new ObjectParameter("SumaGryni", sumaGryni) :
        //        new ObjectParameter("SumaGryni", typeof(double));
    
        //    var secondsParameter = seconds.HasValue ?
        //        new ObjectParameter("Seconds", seconds) :
        //        new ObjectParameter("Seconds", typeof(byte));
    
        //    var durationParameter = duration.HasValue ?
        //        new ObjectParameter("Duration", duration) :
        //        new ObjectParameter("Duration", typeof(double));
    
        //    var durationToPushTotalParameter = durationToPushTotal.HasValue ?
        //        new ObjectParameter("DurationToPushTotal", durationToPushTotal) :
        //        new ObjectParameter("DurationToPushTotal", typeof(double));
    
        //    var flagsParameter = flags.HasValue ?
        //        new ObjectParameter("Flags", flags) :
        //        new ObjectParameter("Flags", typeof(int));
    
        //    var invNrParameter = invNr != null ?
        //        new ObjectParameter("InvNr", invNr) :
        //        new ObjectParameter("InvNr", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreKvitoGalvaEx3", aparatoIDParameter, kvitoNrParameter, yearParameter, monthParameter, dayParameter, hourParameter, minuteParameter, apmokejimoRusisParameter, sumaParameter, nuolaidaParameter, antkainisParameter, mokesciaiParameter, kortelesNrParameter, kasininkasParameter, znrParameter, kvitoNr2Parameter, nlKortParameter, sumaGryniParameter, secondsParameter, durationParameter, durationToPushTotalParameter, flagsParameter, invNrParameter, iD);
        //}
    
        //public virtual int rq_StorePayment(int? galvosId, int? type, double? amount, string cardNo, string authCode, int? authModule, double? currencyRate, double? currencyAmount, ObjectParameter iD)
        //{
        //    var galvosIdParameter = galvosId.HasValue ?
        //        new ObjectParameter("GalvosId", galvosId) :
        //        new ObjectParameter("GalvosId", typeof(int));
    
        //    var typeParameter = type.HasValue ?
        //        new ObjectParameter("Type", type) :
        //        new ObjectParameter("Type", typeof(int));
    
        //    var amountParameter = amount.HasValue ?
        //        new ObjectParameter("Amount", amount) :
        //        new ObjectParameter("Amount", typeof(double));
    
        //    var cardNoParameter = cardNo != null ?
        //        new ObjectParameter("CardNo", cardNo) :
        //        new ObjectParameter("CardNo", typeof(string));
    
        //    var authCodeParameter = authCode != null ?
        //        new ObjectParameter("AuthCode", authCode) :
        //        new ObjectParameter("AuthCode", typeof(string));
    
        //    var authModuleParameter = authModule.HasValue ?
        //        new ObjectParameter("AuthModule", authModule) :
        //        new ObjectParameter("AuthModule", typeof(int));
    
        //    var currencyRateParameter = currencyRate.HasValue ?
        //        new ObjectParameter("CurrencyRate", currencyRate) :
        //        new ObjectParameter("CurrencyRate", typeof(double));
    
        //    var currencyAmountParameter = currencyAmount.HasValue ?
        //        new ObjectParameter("CurrencyAmount", currencyAmount) :
        //        new ObjectParameter("CurrencyAmount", typeof(double));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StorePayment", galvosIdParameter, typeParameter, amountParameter, cardNoParameter, authCodeParameter, authModuleParameter, currencyRateParameter, currencyAmountParameter, iD);
        //}
    
        //public virtual int rq_StorePaymentBank(int? paymentId, short? bankId, short? bankOwnerId, bool? isCobrand, bool? isOnline, ObjectParameter iD)
        //{
        //    var paymentIdParameter = paymentId.HasValue ?
        //        new ObjectParameter("PaymentId", paymentId) :
        //        new ObjectParameter("PaymentId", typeof(int));
    
        //    var bankIdParameter = bankId.HasValue ?
        //        new ObjectParameter("BankId", bankId) :
        //        new ObjectParameter("BankId", typeof(short));
    
        //    var bankOwnerIdParameter = bankOwnerId.HasValue ?
        //        new ObjectParameter("BankOwnerId", bankOwnerId) :
        //        new ObjectParameter("BankOwnerId", typeof(short));
    
        //    var isCobrandParameter = isCobrand.HasValue ?
        //        new ObjectParameter("IsCobrand", isCobrand) :
        //        new ObjectParameter("IsCobrand", typeof(bool));
    
        //    var isOnlineParameter = isOnline.HasValue ?
        //        new ObjectParameter("IsOnline", isOnline) :
        //        new ObjectParameter("IsOnline", typeof(bool));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StorePaymentBank", paymentIdParameter, bankIdParameter, bankOwnerIdParameter, isCobrandParameter, isOnlineParameter, iD);
        //}
    
        //public virtual int rq_StorePaymentBank2(int? paymentId, short? bankId, short? bankOwnerId, bool? isCobrand, bool? isOnline, string authId, string ci, ObjectParameter iD)
        //{
        //    var paymentIdParameter = paymentId.HasValue ?
        //        new ObjectParameter("PaymentId", paymentId) :
        //        new ObjectParameter("PaymentId", typeof(int));
    
        //    var bankIdParameter = bankId.HasValue ?
        //        new ObjectParameter("BankId", bankId) :
        //        new ObjectParameter("BankId", typeof(short));
    
        //    var bankOwnerIdParameter = bankOwnerId.HasValue ?
        //        new ObjectParameter("BankOwnerId", bankOwnerId) :
        //        new ObjectParameter("BankOwnerId", typeof(short));
    
        //    var isCobrandParameter = isCobrand.HasValue ?
        //        new ObjectParameter("IsCobrand", isCobrand) :
        //        new ObjectParameter("IsCobrand", typeof(bool));
    
        //    var isOnlineParameter = isOnline.HasValue ?
        //        new ObjectParameter("IsOnline", isOnline) :
        //        new ObjectParameter("IsOnline", typeof(bool));
    
        //    var authIdParameter = authId != null ?
        //        new ObjectParameter("AuthId", authId) :
        //        new ObjectParameter("AuthId", typeof(string));
    
        //    var ciParameter = ci != null ?
        //        new ObjectParameter("Ci", ci) :
        //        new ObjectParameter("Ci", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StorePaymentBank2", paymentIdParameter, bankIdParameter, bankOwnerIdParameter, isCobrandParameter, isOnlineParameter, authIdParameter, ciParameter, iD);
        //}
    
        //public virtual int rq_StorePoints_Headers(int? galvosId, double? points, double? centerPoints, int? discountIdentificator, ObjectParameter iD)
        //{
        //    var galvosIdParameter = galvosId.HasValue ?
        //        new ObjectParameter("GalvosId", galvosId) :
        //        new ObjectParameter("GalvosId", typeof(int));
    
        //    var pointsParameter = points.HasValue ?
        //        new ObjectParameter("Points", points) :
        //        new ObjectParameter("Points", typeof(double));
    
        //    var centerPointsParameter = centerPoints.HasValue ?
        //        new ObjectParameter("CenterPoints", centerPoints) :
        //        new ObjectParameter("CenterPoints", typeof(double));
    
        //    var discountIdentificatorParameter = discountIdentificator.HasValue ?
        //        new ObjectParameter("DiscountIdentificator", discountIdentificator) :
        //        new ObjectParameter("DiscountIdentificator", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StorePoints_Headers", galvosIdParameter, pointsParameter, centerPointsParameter, discountIdentificatorParameter, iD);
        //}
    
        //public virtual int rq_StorePoints_Items(int? kvitoEiluteId, double? points, int? discountIdentificator, ObjectParameter iD)
        //{
        //    var kvitoEiluteIdParameter = kvitoEiluteId.HasValue ?
        //        new ObjectParameter("KvitoEiluteId", kvitoEiluteId) :
        //        new ObjectParameter("KvitoEiluteId", typeof(int));
    
        //    var pointsParameter = points.HasValue ?
        //        new ObjectParameter("Points", points) :
        //        new ObjectParameter("Points", typeof(double));
    
        //    var discountIdentificatorParameter = discountIdentificator.HasValue ?
        //        new ObjectParameter("DiscountIdentificator", discountIdentificator) :
        //        new ObjectParameter("DiscountIdentificator", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StorePoints_Items", kvitoEiluteIdParameter, pointsParameter, discountIdentificatorParameter, iD);
        //}
    
        //public virtual int rq_StorePrice_Discounts_Items(int? kvitoEiluteId, double? discount, int? discountScenarioType, int? discountIdentificator, int? sellDiscountId, ObjectParameter iD)
        //{
        //    var kvitoEiluteIdParameter = kvitoEiluteId.HasValue ?
        //        new ObjectParameter("KvitoEiluteId", kvitoEiluteId) :
        //        new ObjectParameter("KvitoEiluteId", typeof(int));
    
        //    var discountParameter = discount.HasValue ?
        //        new ObjectParameter("Discount", discount) :
        //        new ObjectParameter("Discount", typeof(double));
    
        //    var discountScenarioTypeParameter = discountScenarioType.HasValue ?
        //        new ObjectParameter("DiscountScenarioType", discountScenarioType) :
        //        new ObjectParameter("DiscountScenarioType", typeof(int));
    
        //    var discountIdentificatorParameter = discountIdentificator.HasValue ?
        //        new ObjectParameter("DiscountIdentificator", discountIdentificator) :
        //        new ObjectParameter("DiscountIdentificator", typeof(int));
    
        //    var sellDiscountIdParameter = sellDiscountId.HasValue ?
        //        new ObjectParameter("SellDiscountId", sellDiscountId) :
        //        new ObjectParameter("SellDiscountId", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StorePrice_Discounts_Items", kvitoEiluteIdParameter, discountParameter, discountScenarioTypeParameter, discountIdentificatorParameter, sellDiscountIdParameter, iD);
        //}
    
        //public virtual int rq_StoreReward(int? galvosId, int? discountIdentificator, string rewardIdentificator, string couponBarcode, bool? isGsm, short? quantity, ObjectParameter iD)
        //{
        //    var galvosIdParameter = galvosId.HasValue ?
        //        new ObjectParameter("GalvosId", galvosId) :
        //        new ObjectParameter("GalvosId", typeof(int));
    
        //    var discountIdentificatorParameter = discountIdentificator.HasValue ?
        //        new ObjectParameter("DiscountIdentificator", discountIdentificator) :
        //        new ObjectParameter("DiscountIdentificator", typeof(int));
    
        //    var rewardIdentificatorParameter = rewardIdentificator != null ?
        //        new ObjectParameter("RewardIdentificator", rewardIdentificator) :
        //        new ObjectParameter("RewardIdentificator", typeof(string));
    
        //    var couponBarcodeParameter = couponBarcode != null ?
        //        new ObjectParameter("CouponBarcode", couponBarcode) :
        //        new ObjectParameter("CouponBarcode", typeof(string));
    
        //    var isGsmParameter = isGsm.HasValue ?
        //        new ObjectParameter("IsGsm", isGsm) :
        //        new ObjectParameter("IsGsm", typeof(bool));
    
        //    var quantityParameter = quantity.HasValue ?
        //        new ObjectParameter("Quantity", quantity) :
        //        new ObjectParameter("Quantity", typeof(short));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreReward", galvosIdParameter, discountIdentificatorParameter, rewardIdentificatorParameter, couponBarcodeParameter, isGsmParameter, quantityParameter, iD);
        //}
    
        //public virtual int rq_StoreSellDiscount(int? galvosId, int? type, int? subType, int? custNo, double? percent, double? amount, string cardNo, string discountTitle, ObjectParameter iD)
        //{
        //    var galvosIdParameter = galvosId.HasValue ?
        //        new ObjectParameter("GalvosId", galvosId) :
        //        new ObjectParameter("GalvosId", typeof(int));
    
        //    var typeParameter = type.HasValue ?
        //        new ObjectParameter("Type", type) :
        //        new ObjectParameter("Type", typeof(int));
    
        //    var subTypeParameter = subType.HasValue ?
        //        new ObjectParameter("SubType", subType) :
        //        new ObjectParameter("SubType", typeof(int));
    
        //    var custNoParameter = custNo.HasValue ?
        //        new ObjectParameter("CustNo", custNo) :
        //        new ObjectParameter("CustNo", typeof(int));
    
        //    var percentParameter = percent.HasValue ?
        //        new ObjectParameter("Percent", percent) :
        //        new ObjectParameter("Percent", typeof(double));
    
        //    var amountParameter = amount.HasValue ?
        //        new ObjectParameter("Amount", amount) :
        //        new ObjectParameter("Amount", typeof(double));
    
        //    var cardNoParameter = cardNo != null ?
        //        new ObjectParameter("CardNo", cardNo) :
        //        new ObjectParameter("CardNo", typeof(string));
    
        //    var discountTitleParameter = discountTitle != null ?
        //        new ObjectParameter("DiscountTitle", discountTitle) :
        //        new ObjectParameter("DiscountTitle", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreSellDiscount", galvosIdParameter, typeParameter, subTypeParameter, custNoParameter, percentParameter, amountParameter, cardNoParameter, discountTitleParameter, iD);
        //}
    
        //public virtual int rq_StoreSellEntry(int? galvosId, int? sellLine, int? entryCode, string entry, ObjectParameter iD)
        //{
        //    var galvosIdParameter = galvosId.HasValue ?
        //        new ObjectParameter("GalvosId", galvosId) :
        //        new ObjectParameter("GalvosId", typeof(int));
    
        //    var sellLineParameter = sellLine.HasValue ?
        //        new ObjectParameter("SellLine", sellLine) :
        //        new ObjectParameter("SellLine", typeof(int));
    
        //    var entryCodeParameter = entryCode.HasValue ?
        //        new ObjectParameter("EntryCode", entryCode) :
        //        new ObjectParameter("EntryCode", typeof(int));
    
        //    var entryParameter = entry != null ?
        //        new ObjectParameter("Entry", entry) :
        //        new ObjectParameter("Entry", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreSellEntry", galvosIdParameter, sellLineParameter, entryCodeParameter, entryParameter, iD);
        //}
    
        //public virtual int rq_StoreStartParam(int? apID, int? zNR, int? kVNR)
        //{
        //    var apIDParameter = apID.HasValue ?
        //        new ObjectParameter("apID", apID) :
        //        new ObjectParameter("apID", typeof(int));
    
        //    var zNRParameter = zNR.HasValue ?
        //        new ObjectParameter("ZNR", zNR) :
        //        new ObjectParameter("ZNR", typeof(int));
    
        //    var kVNRParameter = kVNR.HasValue ?
        //        new ObjectParameter("KVNR", kVNR) :
        //        new ObjectParameter("KVNR", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_StoreStartParam", apIDParameter, zNRParameter, kVNRParameter);
        //}
    
        //public virtual int rq_SwapBits(int? bitonr, ObjectParameter data1, ObjectParameter data2)
        //{
        //    var bitonrParameter = bitonr.HasValue ?
        //        new ObjectParameter("bitonr", bitonr) :
        //        new ObjectParameter("bitonr", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("rq_SwapBits", bitonrParameter, data1, data2);
        //}
    
        //public virtual ObjectResult<ScanMataiAll_Result> ScanMataiAll()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ScanMataiAll_Result>("ScanMataiAll");
        //}
    
        //public virtual int sco_ClearBit(int? bitonr, ObjectParameter data1)
        //{
        //    var bitonrParameter = bitonr.HasValue ?
        //        new ObjectParameter("bitonr", bitonr) :
        //        new ObjectParameter("bitonr", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sco_ClearBit", bitonrParameter, data1);
        //}
    
        //public virtual int sco_ClearBits(int? bitoNr, string ids, string tableName, string fieldName, string iDfieldName)
        //{
        //    var bitoNrParameter = bitoNr.HasValue ?
        //        new ObjectParameter("BitoNr", bitoNr) :
        //        new ObjectParameter("BitoNr", typeof(int));
    
        //    var idsParameter = ids != null ?
        //        new ObjectParameter("ids", ids) :
        //        new ObjectParameter("ids", typeof(string));
    
        //    var tableNameParameter = tableName != null ?
        //        new ObjectParameter("tableName", tableName) :
        //        new ObjectParameter("tableName", typeof(string));
    
        //    var fieldNameParameter = fieldName != null ?
        //        new ObjectParameter("fieldName", fieldName) :
        //        new ObjectParameter("fieldName", typeof(string));
    
        //    var iDfieldNameParameter = iDfieldName != null ?
        //        new ObjectParameter("IDfieldName", iDfieldName) :
        //        new ObjectParameter("IDfieldName", typeof(string));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sco_ClearBits", bitoNrParameter, idsParameter, tableNameParameter, fieldNameParameter, iDfieldNameParameter);
        //}
    
        //public virtual int sco_PrekesTransferBit(int? prekesID, int? bitonr, int? deleteoperation)
        //{
        //    var prekesIDParameter = prekesID.HasValue ?
        //        new ObjectParameter("PrekesID", prekesID) :
        //        new ObjectParameter("PrekesID", typeof(int));
    
        //    var bitonrParameter = bitonr.HasValue ?
        //        new ObjectParameter("bitonr", bitonr) :
        //        new ObjectParameter("bitonr", typeof(int));
    
        //    var deleteoperationParameter = deleteoperation.HasValue ?
        //        new ObjectParameter("deleteoperation", deleteoperation) :
        //        new ObjectParameter("deleteoperation", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sco_PrekesTransferBit", prekesIDParameter, bitonrParameter, deleteoperationParameter);
        //}
    
        //public virtual ObjectResult<sco_ReadCashier_Result> sco_ReadCashier(int? cashierID, int? bitoNr)
        //{
        //    var cashierIDParameter = cashierID.HasValue ?
        //        new ObjectParameter("CashierID", cashierID) :
        //        new ObjectParameter("CashierID", typeof(int));
    
        //    var bitoNrParameter = bitoNr.HasValue ?
        //        new ObjectParameter("BitoNr", bitoNr) :
        //        new ObjectParameter("BitoNr", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sco_ReadCashier_Result>("sco_ReadCashier", cashierIDParameter, bitoNrParameter);
        //}
    
        //public virtual int sco_ReadCatPict(int? catPictID, int? bitoNr)
        //{
        //    var catPictIDParameter = catPictID.HasValue ?
        //        new ObjectParameter("CatPictID", catPictID) :
        //        new ObjectParameter("CatPictID", typeof(int));
    
        //    var bitoNrParameter = bitoNr.HasValue ?
        //        new ObjectParameter("BitoNr", bitoNr) :
        //        new ObjectParameter("BitoNr", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sco_ReadCatPict", catPictIDParameter, bitoNrParameter);
        //}
    
        //public virtual ObjectResult<sco_ReadLoyCard_Result> sco_ReadLoyCard(int? loyCardID, int? bitoNr)
        //{
        //    var loyCardIDParameter = loyCardID.HasValue ?
        //        new ObjectParameter("LoyCardID", loyCardID) :
        //        new ObjectParameter("LoyCardID", typeof(int));
    
        //    var bitoNrParameter = bitoNr.HasValue ?
        //        new ObjectParameter("BitoNr", bitoNr) :
        //        new ObjectParameter("BitoNr", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sco_ReadLoyCard_Result>("sco_ReadLoyCard", loyCardIDParameter, bitoNrParameter);
        //}
    
        //public virtual int sco_ReadPLUPict(int? pLUPictID, int? bitoNr)
        //{
        //    var pLUPictIDParameter = pLUPictID.HasValue ?
        //        new ObjectParameter("PLUPictID", pLUPictID) :
        //        new ObjectParameter("PLUPictID", typeof(int));
    
        //    var bitoNrParameter = bitoNr.HasValue ?
        //        new ObjectParameter("BitoNr", bitoNr) :
        //        new ObjectParameter("BitoNr", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sco_ReadPLUPict", pLUPictIDParameter, bitoNrParameter);
        //}
    
        //public virtual ObjectResult<sco_ReadPreke_Result> sco_ReadPreke(int? prekesID, int? bitoNr, int? dep)
        //{
        //    var prekesIDParameter = prekesID.HasValue ?
        //        new ObjectParameter("PrekesID", prekesID) :
        //        new ObjectParameter("PrekesID", typeof(int));
    
        //    var bitoNrParameter = bitoNr.HasValue ?
        //        new ObjectParameter("BitoNr", bitoNr) :
        //        new ObjectParameter("BitoNr", typeof(int));
    
        //    var depParameter = dep.HasValue ?
        //        new ObjectParameter("dep", dep) :
        //        new ObjectParameter("dep", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sco_ReadPreke_Result>("sco_ReadPreke", prekesIDParameter, bitoNrParameter, depParameter);
        //}
    
        //public virtual ObjectResult<sco_ReadPrekeDelete_Result> sco_ReadPrekeDelete(int? prekesID, int? bitoNr, int? dep)
        //{
        //    var prekesIDParameter = prekesID.HasValue ?
        //        new ObjectParameter("PrekesID", prekesID) :
        //        new ObjectParameter("PrekesID", typeof(int));
    
        //    var bitoNrParameter = bitoNr.HasValue ?
        //        new ObjectParameter("BitoNr", bitoNr) :
        //        new ObjectParameter("BitoNr", typeof(int));
    
        //    var depParameter = dep.HasValue ?
        //        new ObjectParameter("dep", dep) :
        //        new ObjectParameter("dep", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sco_ReadPrekeDelete_Result>("sco_ReadPrekeDelete", prekesIDParameter, bitoNrParameter, depParameter);
        //}
    
        //public virtual int StorePLUSetPaid(string bC, int? kGID)
        //{
        //    var bCParameter = bC != null ?
        //        new ObjectParameter("BC", bC) :
        //        new ObjectParameter("BC", typeof(string));
    
        //    var kGIDParameter = kGID.HasValue ?
        //        new ObjectParameter("KGID", kGID) :
        //        new ObjectParameter("KGID", typeof(int));
    
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("StorePLUSetPaid", bCParameter, kGIDParameter);
        //}
    
        //public virtual int UpdateBCDep()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateBCDep");
        //}
    }
}
