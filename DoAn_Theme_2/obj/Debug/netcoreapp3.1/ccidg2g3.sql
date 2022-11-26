ALTER TABLE [ChiTietDonHangs] ADD [IdDonViTrietKhau] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [ChiTietDonHangs] ADD [TrietKhau] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221102234459_add table donGia', N'3.1.30');

GO

