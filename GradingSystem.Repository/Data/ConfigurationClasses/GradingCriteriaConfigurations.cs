using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class GradingCriteriaConfigurations : IEntityTypeConfiguration<GradingCriteria>
    {
        public void Configure(EntityTypeBuilder<GradingCriteria> builder)
        {
            
        }
    }
}
