namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1c7ed93a-32c9-4dd8-b60e-ea7be01f47ad', N'guest@vidly.com', 0, N'AJvBhjuAZ3LTf4Mg4d0z7mxNa8SzEpauprNAFLAtHbMOvQqzIv8wBjk/gAo9j8CwyA==', N'3ab7daef-61bc-4190-a1fe-a6cdcb6f8ec6', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5c4e8662-e58b-4907-900f-584ff520aae1', N'admin@vidly.com', 0, N'ADx4RuqyVkpKPgo85ZO6Cg8msOxE86pRz6/J+kXaBEMQeo+lDay0cmIc/vfYpmL1tw==', N'b41d3a5f-c6e7-4518-b5c0-f486a94bf3b6', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3c243c43-9cab-4710-81aa-ecaca2104216', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5c4e8662-e58b-4907-900f-584ff520aae1', N'3c243c43-9cab-4710-81aa-ecaca2104216')

");
        }
        
        public override void Down()
        {
        }
    }
}
