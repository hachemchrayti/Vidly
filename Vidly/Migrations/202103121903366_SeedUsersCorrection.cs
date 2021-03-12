namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersCorrection : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'232dae1c-353c-4699-b51d-3864b20467c5', N'hachemfst@gmail.com', 0, N'AOzfmswOuguqcmOhibdp4F6HheqT22e1U+aoTafPwueb+L8bEBzyao7zEkTJ64FgjQ==', N'619cf108-c69c-491f-a691-08c0f4836561', NULL, 0, 0, NULL, 1, 0, N'hachemfst@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3bdb4546-21fc-40d3-a48d-1ec361e08d1e', N'Guest@vidly.com', 0, N'AJl6C9zDcHKufsrafYCH0TbZD9HJ23M0y6zz+TdYpEL+BUSnJksu9LZKXrezi7XqrQ==', N'e65c708d-0318-4695-852d-3558729cfdc7', NULL, 0, 0, NULL, 1, 0, N'Guest@vidly.com')
");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e89453db-186d-4af7-aa7d-edd612d897b2', N'CanManageMovies')");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'232dae1c-353c-4699-b51d-3864b20467c5', N'e89453db-186d-4af7-aa7d-edd612d897b2')");
        }
        
        public override void Down()
        {
        }
    }
}
