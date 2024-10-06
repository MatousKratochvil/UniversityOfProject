using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework.Common;

public interface IComplexPropertyConfiguration<TEntity> where TEntity : class
{
    ComplexPropertyBuilder<TEntity> Configure(ComplexPropertyBuilder<TEntity> builder);
}