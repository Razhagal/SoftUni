﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BookShop.Models;

namespace BookShop.Data.EntityConfiguration
{
    internal class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(e => new { e.BookId, e.CategoryId });

            builder.HasOne(e => e.Category)
                .WithMany(c => c.CategoryBooks)
                .HasForeignKey(e => e.CategoryId);

            builder.HasOne(e => e.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(e => e.BookId);
        }
    }
}