using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Skill)
                .WithMany()
                .HasForeignKey(p => p.IdSkill);

            builder
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.IdUser);

        }
    }
}
