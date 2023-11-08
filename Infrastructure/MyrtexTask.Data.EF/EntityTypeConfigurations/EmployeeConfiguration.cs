using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyrtexTask.Domain;

namespace MyrtexTask.Data.EF.EntityTypeConfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasData
                (
                    new Employee(Guid.NewGuid(), "Разработчики", "Аполин С.Ю.", new DateTime(1995, 7, 14), new DateTime(2020, 8, 11), 170000),
                    new Employee(Guid.NewGuid(), "Разработчики", "Волков А.В.", new DateTime(1997, 4, 11), new DateTime(2022, 5, 9), 130000),
                    new Employee(Guid.NewGuid(), "Поддержка", "Воронов Е.В.", new DateTime(1996, 6, 21), new DateTime(2021, 2, 13), 100000),
                    new Employee(Guid.NewGuid(), "Маркетинг", "Елисеева А.С.", new DateTime(1998, 11, 9), new DateTime(2021, 6, 12), 90000),
                    new Employee(Guid.NewGuid(), "Управление", "Савин В.Г.", new DateTime(1991, 5, 14), new DateTime(2018, 3, 17), 200000)
                );
        }
    }
}
