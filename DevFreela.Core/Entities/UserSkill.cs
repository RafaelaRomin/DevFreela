using System.ComponentModel.DataAnnotations.Schema;

namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }

        [NotMapped]
        public Skill Skill { get; private set; }
        public User User { get; private set; }

    }
}