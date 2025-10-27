using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // نقل البيانات من NameAr إلى NameEn في جدول الطلاب
            migrationBuilder.Sql("UPDATE Students SET NameEn = NameAr WHERE NameEn IS NULL OR NameEn = ''");

            // نقل البيانات من NameAr إلى NameEn في جدول الأقسام
            migrationBuilder.Sql("UPDATE Departments SET NameEn = NameAr WHERE NameEn IS NULL OR NameEn = ''");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // في حالة الرجوع، ممكن ترجّع العكس (اختياري)
            migrationBuilder.Sql("UPDATE Students SET NameAr = NameEn WHERE NameAr IS NULL OR NameAr = ''");
            migrationBuilder.Sql("UPDATE Departments SET NameAr = NameEn WHERE NameAr IS NULL OR NameAr = ''");
        }
    }

}
