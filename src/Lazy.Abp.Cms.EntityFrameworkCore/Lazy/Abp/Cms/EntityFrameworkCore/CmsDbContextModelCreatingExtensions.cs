using Lazy.Abp.Cms.ArticleAuditLogs;
using Lazy.Abp.Cms.ArticleFavorites;
using Lazy.Abp.Cms.ArticleLikes;
using Lazy.Abp.Cms.Articles;
using Lazy.Abp.Cms.ArticleSales;
using Lazy.Abp.Cms.Categories;
using Lazy.Abp.Cms.SinglePages;
using Lazy.Abp.Cms.Tags;
using Lazy.Abp.Cms.UserCategories;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.Cms.EntityFrameworkCore
{
    public static class CmsDbContextModelCreatingExtensions
    {
        public static void ConfigureCms(
            this ModelBuilder builder,
            Action<CmsModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CmsModelBuilderConfigurationOptions(
                CmsDbProperties.DbTablePrefix,
                CmsDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<Article>(b =>
            {
                b.ToTable(options.TablePrefix + "Articles", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.UserCategoryId);

                b.HasMany(q => q.Pictures).WithOne().HasForeignKey(x => x.ArticleId);
                b.HasMany(q => q.Categories).WithOne().HasForeignKey(x => x.ArticleId);
                b.HasMany(q => q.Tags).WithOne().HasForeignKey(x => x.ArticleId);
                b.HasMany(q => q.Logs).WithOne().HasForeignKey(x => x.ArticleId);
                /* Configure more properties here */
            });

            builder.Entity<ArticlePicture>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticlePictures", options.Schema);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });

            builder.Entity<ArticleContent>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleContents", options.Schema);
                b.ConfigureByConvention();

                b.HasKey(q => q.ArticleId);
                /* Configure more properties here */
            });


            builder.Entity<ArticleFavorite>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleFavorites", options.Schema);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });


            builder.Entity<ArticleLike>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleLikes", options.Schema);
                b.ConfigureByConvention();
                /* Configure more properties here */
            });


            builder.Entity<ArticleMeta>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleMetas", options.Schema);
                b.ConfigureByConvention();

                b.HasKey(q => q.ArticleId);
                /* Configure more properties here */
            });


            builder.Entity<ArticleSale>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleSales", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.UserId);
                b.HasIndex(q => new
                {
                    q.UserId,
                    q.ArticleId
                });
                /* Configure more properties here */
            });


            builder.Entity<ArticleCategory>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleCategories", options.Schema);
                b.ConfigureByConvention();

                b.HasKey(q => new { q.ArticleId, q.CategoryId });
                /* Configure more properties here */
            });


            builder.Entity<Category>(b =>
            {
                b.ToTable(options.TablePrefix + "Categories", options.Schema);
                b.ConfigureByConvention(); 
                
                /* Configure more properties here */
            });


            builder.Entity<SinglePage>(b =>
            {
                b.ToTable(options.TablePrefix + "SinglePages", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.Name).IsUnique();
                /* Configure more properties here */
            });


            builder.Entity<Tag>(b =>
            {
                b.ToTable(options.TablePrefix + "Tags", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.Name).IsUnique();
                /* Configure more properties here */
            });

            builder.Entity<ArticleTag>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleTags", options.Schema);
                b.ConfigureByConvention();

                b.HasKey(q => new { q.ArticleId, q.TagId });
                /* Configure more properties here */
            });


            builder.Entity<UserCategory>(b =>
            {
                b.ToTable(options.TablePrefix + "UserCategories", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.UserId);
                /* Configure more properties here */
            });

            builder.Entity<ArticleAuditLog>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleAuditLogs", options.Schema);
                b.ConfigureByConvention();

                /* Configure more properties here */
            });
        }
    }
}
