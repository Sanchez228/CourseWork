using Microsoft.EntityFrameworkCore;

namespace CourseWork.Model
{
    public class User
    {
        public int Id { get; set; }

        [Comment("The nickname of user")]
        public string Nickname { get; set; }


        [Comment("The password of user")]
        public string Password { get; set; }
    }
}
