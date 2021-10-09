using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TasnimWhatsAppOrchestration.Models;

#nullable disable

namespace TasnimWhatsAppOrchestration.WorkingWithData
{
    public partial class TasnimContext : ScafoldedContext, ITasnimContext
    {
        public TasnimContext()
        {
        }

        public TasnimContext(DbContextOptions<TasnimContext> options)
            : base(options)
        {

           // Database.ExecuteSqlRaw("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
        }






        public virtual DbSet<TN_GET_CUSTOMER_SESSION> TN_GET_CUSTOMER_SESSION { get; set; }

        public virtual DbSet<TN_GET_CUSTOMNER_LEVEL> TN_GET_CUSTOMNER_LEVEL { get; set; }
        public virtual DbSet<SP_H7N_GET_CUSTOMNER_LEVEL> SP_H7N_GET_CUSTOMNER_LEVEL { get; set; }
        public virtual DbSet<SAL_OFFERS> SAL_OFFERS { get; set; }

        public virtual DbSet<SP_Husoomat_Whatsapp_Offer_Cityies> SP_Husoomat_Whatsapp_Offer_Cityies { get; set; }

        public override void OnTansimeModeolCreaing(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SAL_OFFERS>(entity =>
                entity.HasNoKey()
                );

            modelBuilder.Entity<TN_GET_CUSTOMER_SESSION>(entity =>
            entity.HasNoKey()
            );

            modelBuilder.Entity<SP_H7N_GET_CUSTOMNER_LEVEL>(entity =>
          entity.HasNoKey()
          );
            modelBuilder.Entity<SP_Husoomat_Whatsapp_Offer_Cityies>(entity =>
            entity.HasNoKey()
            );
        }


        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

              modelBuilder.Entity<FileCustomer>(entity =>
              {
                  entity.ToTable("FileCustomer");

                  entity.HasIndex(e => e.CareStpId, "IX_FileCustomer_CARE");

                  entity.HasIndex(e => new { e.Mobile, e.IsMerge }, "IX_FileCustomer_MobileIsMerge");

                  entity.Property(e => e.Address).HasComment("العنوان");

                  entity.Property(e => e.CardId)
                      .HasMaxLength(250)
                      .HasComment("رقم البطاقه");

                  entity.Property(e => e.CareStpId)
                      .HasColumnName("CARE_STP_Id")
                      .HasComment("رقم ذمة العميل في ملف الذمم ");

                  entity.Property(e => e.CreateDate)
                      .HasColumnType("datetime")
                      .HasComment("تاريخ الإنشاء");

                  entity.Property(e => e.DateofBirth)
                      .HasColumnType("date")
                      .HasComment("تاريخ الميلاد");

                  entity.Property(e => e.Email)
                      .HasMaxLength(250)
                      .HasComment("البريد الإلكتروني");

                  entity.Property(e => e.Gender).HasComment("الجنس");

                  entity.Property(e => e.IdentifyWayId).HasComment("وسيلة التعرف");

                  entity.Property(e => e.InsertedUserId).HasColumnName("InsertedUserID");

                  entity.Property(e => e.IsMerge).HasComment("تم دمج الملف");

                  entity.Property(e => e.Job)
                      .HasMaxLength(500)
                      .HasComment("الوظيفه")
                      .UseCollation("Arabic_CS_AS");

                  entity.Property(e => e.MarketingPlaceId).HasColumnName("MarketingPlaceID");

                  entity.Property(e => e.Mobile).HasComment("الجوال");

                  entity.Property(e => e.MobileVerificationId).HasColumnName("MobileVerificationID");

                  entity.Property(e => e.Name)
                      .HasMaxLength(500)
                      .HasComment("الإسم")
                      .UseCollation("Arabic_CS_AS");

                  entity.Property(e => e.Nationality).HasComment("الجنسية");

                  entity.Property(e => e.NewId).HasComment("رقم الملف الجديد بعد الدمج");

                  entity.Property(e => e.OfficialEndDate)
                      .HasColumnType("date")
                      .HasComment("تاريخ إنتهاء الوثيقة");

                  entity.Property(e => e.OfficialId).HasComment("نوع الوثيقة");

                  entity.Property(e => e.OfficialNumber)
                      .HasMaxLength(500)
                      .HasComment("رقم الوثيقة")
                      .UseCollation("Arabic_CS_AS");

                  entity.Property(e => e.PersonalImage).HasComment("الصورة الشخصية");

                  entity.Property(e => e.SmsTrue).HasColumnName("SMS_TRUE");

                  entity.Property(e => e.Telephone).HasComment("الهاتف");
              });

              modelBuilder.Entity<FileCustomerMobile>(entity =>
              {
                  entity.ToTable("FileCustomerMobile");

                  entity.HasIndex(e => new { e.Mobile, e.MobileKey }, "IX_FileCustomerMobile")
                      .IsUnique();

                  entity.Property(e => e.Id).HasColumnName("ID");

                  entity.Property(e => e.FileCustomerId).HasColumnName("FileCustomerID");

                  entity.Property(e => e.InsertedDateTime).HasColumnType("datetime");

                  entity.Property(e => e.InsertedUserId).HasColumnName("InsertedUserID");
              });

              modelBuilder.Entity<FileListed>(entity =>
              {
                  entity.ToTable("FileListed");

                  entity.HasIndex(e => e.FileCustemerId, "IX_FileListed_I");

                  entity.HasIndex(e => e.SubCod, "IX_FileListed_SUB_COD");

                  entity.Property(e => e.Id).HasComment("رمز القائمة السوداء");

                  entity.Property(e => e.ApproveDate).HasColumnType("datetime");

                  entity.Property(e => e.CreateDateTime)
                      .HasColumnType("datetime")
                      .HasComment("تاربخ الأنشاء");

                  entity.Property(e => e.EmpApprovedId).HasComment("رمز الموظف");

                  entity.Property(e => e.EmpId)
                      .HasColumnName("Emp_Id")
                      .HasComment("رمز المظف");

                  entity.Property(e => e.FileCustemerId).HasComment("رمز العمبل");

                  entity.Property(e => e.FileListedHistoryId).HasColumnName("FileListedHistoryID");

                  entity.Property(e => e.IsApproved).HasComment("الحالة");

                  entity.Property(e => e.IsListed).HasComment("المدرج في الجدول");

                  entity.Property(e => e.ListReason)
                      .HasMaxLength(400)
                      .HasComment("قائمة السبب");

                  entity.Property(e => e.Notes)
                      .HasMaxLength(400)
                      .HasComment("ملاحظات");

                  entity.Property(e => e.SubCod)
                      .HasColumnName("SUB_COD")
                      .HasComment("رمز تفاصيل ");

                  entity.Property(e => e.ValidatedInDateTime).HasColumnType("datetime");
              });

              modelBuilder.Entity<SessionCardHeader>(entity =>
              {
                  entity.ToTable("SessionCardHeader");

                  entity.HasIndex(e => e.MatStpId, "IX_SessionCardHeader")
                      .IsUnique();

                  entity.Property(e => e.DmnDtlId)
                      .HasColumnName("DMN_DTL_ID")
                      .HasComment("طريقة الجدولة");

                  entity.Property(e => e.HelperAvgWorkMinutes)
                      .HasColumnName("HELPER_AVG_WORK_MINUTES")
                      .HasComment("مدة عمل المساعد بالجلسة");

                  entity.Property(e => e.IsFreeConsultancy)
                      .HasDefaultValueSql("((0))")
                      .HasComment("جلسة إستشارية نعم-لا");

                  entity.Property(e => e.LastEditDate).HasColumnType("datetime");

                  entity.Property(e => e.MatCatId)
                      .HasColumnName("MAT_CAT_ID")
                      .HasComment("فئات المواد ");

                  entity.Property(e => e.MatStpId)
                      .HasColumnName("MAT_STP_ID")
                      .HasComment("المواد ");

                  entity.Property(e => e.NoAssetsUsed).HasColumnName("NO_ASSETS_USED");

                  entity.Property(e => e.NoMaterialsUsed).HasColumnName("NO_MATERIALS_USED");

                  entity.Property(e => e.OrgStpId).HasColumnName("ORG_STP_ID");

                  entity.Property(e => e.SchDuration)
                      .HasColumnName("SCH_DURATION")
                      .HasComment("مدة الجلسه بالدقائق ");

                  entity.Property(e => e.SpecialistAvgWorkMinutes)
                      .HasColumnName("SPECIALIST_AVG_WORK_MINUTES")
                      .HasComment("مدة عمل الأخصائي بالجلسة");
              });

              modelBuilder.Entity<SAL_OFFERS>(entity =>
              entity.HasNoKey()
              );

              modelBuilder.Entity<TN_GET_CUSTOMER_SESSION>(entity =>
              entity.HasNoKey()
              );

              modelBuilder.HasSequence("CountBy");

              OnModelCreatingPartial(modelBuilder);
          }

          partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
