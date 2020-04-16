# Entity Framework ile CodeFirst Yaklaşımı
**Entity Framework projesi** bizi veritabanı işlemlerini daha kolay yapmamıza olanak sunar. Bu projede Entity Framework CodeFirst yaklaşımı basit olarak ele alınmıştır.

![lisance](https://img.shields.io/apm/l/vim-mode)
![university](https://img.shields.io/badge/University-MAKU-blue)
![platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![framework](https://img.shields.io/badge/.NET%20Framework-4.5-orange)
![entity](https://img.shields.io/badge/Entity%20Framework-5.0.0-brightgreen)
## Dosya İçeriği
* EntityFramework_CodeFirst_Web2 `Aspx.Net`
## Class Dosyaları
* Global.asax
* Lesson
* SchoolDBContext
* SchoolDBContextSeeder
* SchoolRepository
* Student
## Neler Var
Bu uygulamada bizlere:
- Student:
    * Tablo içeriği
    * attributes `Öznitelikler`
- Lesson:
    * Tablo içeriği
    * attributes `Öznitelikler`
- SchoolDBContext:
    * DbSet<>
    * DbContext
- SchoolDBContextSeeder:
    * DropCreateDatabaseIfModelChanges<SchoolDBContext>
    * override void Seed()
    * Veritabanına veri kayıt işlemi
- SchoolRepository:
    * Include("Students")
   
    
### Web.config

EntityFramework_CodeFirst_Web2 içindeki `Web.config` içine yazılan kodlar:

```xml
<?xml version="1.0" encoding="utf-8"?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  https://go.microsoft.com/fwlink/?LinkId=169433
  -->
<configuration>
  <configSections>
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </configSections>
  <system.web>
    <compilation debug="true" targetFramework="4.5" />
    <httpRuntime targetFramework="4.5" />
  </system.web>
  <system.codedom>
    <compilers>
      <compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:6 /nowarn:1659;1699;1701" />
      <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.VBCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:14 /nowarn:41008 /define:_MYTYPE=\&quot;Web\&quot; /optionInfer+" />
    </compilers>
  </system.codedom>
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
  </entityFramework>
  <!--
      name="SchoolDBContext" SchoolDBContext class ismini girdik.
      Database=School; Veritabanı kısmına oluşturulacak veritabanı ismi
      Integrated Security=true   veritabanına şifresiz bağlandığımız için
  -->
  <connectionStrings>
    <add name="SchoolDBContext" connectionString="Server=DESKTOP-CQIJ5R7\SQLEXPRESS; Database=School; Integrated Security=true" providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>
```
### Global.asax
```c#
protected void Application_Start(object sender, EventArgs e)
        {
            //Modelde bir değişiklik olduğunda _MigrationHistory senkron çalışmasını sağlamak için kullanılır.
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //veritabanına CodeFirst ile veri eklemek için bu kodu yazdık.
            Database.SetInitializer(new SchoolDBContextSeeder());
        }
```
### WebForm1.aspx
```c#
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EntityFramework_CodeFirst_Web2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Ders" SortExpression="Name" />
                    <asp:TemplateField HeaderText="Öğrenciler">
                        <ItemTemplate>
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSource='<%# Eval("Students") %>'>
                                <Columns>
                                    <asp:BoundField DataField="NameAndLastname" HeaderText="Ad ve Soyad" />
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <EmptyDataTemplate>
                    <asp:GridView ID="GridView2" runat="server" DataSource='<%# Eval("Student") %>'>
                    </asp:GridView>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLessons" TypeName="EntityFramework_CodeFirst_Web2.SchoolRepository"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
```
## Kullanılan Dil ve IDE
[![FVCproductions](https://danieljscheufler.files.wordpress.com/2016/05/2p4i.png?w=50&h=50)]()
[![FVCproductions](https://i1.wp.com/www.teknoloskop.net/wp-content/uploads/2018/12/Visual-Studio.png?fit=50%2C50&ssl=1)]()

