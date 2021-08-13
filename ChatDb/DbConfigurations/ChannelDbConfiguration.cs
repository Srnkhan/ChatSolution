using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace ChatDb.DbConfigurations
{
    public static class ChannelDbConfiguration
    {
        public static void ChannelConfiguration(this ModelBuilder builder)
        {
            builder.Entity<ChatModals.DbModal.Channel>().HasData(new ChatModals.DbModal.Channel
            {
                Id = Guid.Parse("22A1D9B0-F452-46E3-9E4A-E13739AB1DD9"),
                ChannelName = "First Channel",
                CreatedDate = DateTime.Now,
                UpdateDate = null,
            });

            builder.Entity<ChatModals.DbModal.Channel>().HasData(new ChatModals.DbModal.Channel
            {
                Id = Guid.Parse("86C3C0D1-7D93-4286-9F39-ACD12983DC07"),
                ChannelName = "Second Channel",
                CreatedDate = DateTime.Now,
                UpdateDate = null,
            });


            builder.Entity<ChatModals.DbModal.Channel>().HasData(new ChatModals.DbModal.Channel
            {
                Id = Guid.Parse("3CE2A3BE-93B3-45D6-97FA-22600E7F5A91"),
                ChannelName = "Third Channel",
                CreatedDate = DateTime.Now,
                UpdateDate = null,
            });


            builder.Entity<ChatModals.DbModal.Channel>().HasData(new ChatModals.DbModal.Channel
            {
                Id = Guid.Parse("5FEB5B2A-8D19-40F6-B142-6D6E26849A5C"),
                ChannelName = "Fourth Channel",
                CreatedDate = DateTime.Now,
                UpdateDate = null,
            });


            builder.Entity<ChatModals.DbModal.Channel>().HasData(new ChatModals.DbModal.Channel
            {
                Id = Guid.Parse("699E8187-5FF9-4F58-BEFE-A3D8E2A2BDC8"),
                ChannelName = "Fifth Channel",
                CreatedDate = DateTime.Now,
                UpdateDate = null,
            });
        }
    }
}
