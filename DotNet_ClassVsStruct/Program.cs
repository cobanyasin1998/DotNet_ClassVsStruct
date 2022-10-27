using System;

namespace DotNet_ClassVsStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                1.Assignments
                2.Interface Implentation
                3.Struct cannot be null, can be nullable
                4.Parameterless constructor ( Array calls parameterless ) (c#10 made it possible)
                5.Pass to method to change the value
                6.What if a struct references itself

                Performance -Should be tested
                -Arrays
                    Struct one array container. Easy to find the object and null
                    Object can be distributed
                    
                -struct memory problem
                    When too many object to copy/paste parameter         
             
             */
            //1-//  Assingments();
            //2-//  InterfaceImplentation();
            //3-//  StructNull();
            //4-// ParameterlessConstructor();
            //5-//  PassToMethod();
            ReferenceStruct();
        }

        private static void ReferenceStruct()
        {

        }
        private static void PassToMethod()
        {
            var userc = new UserClass();
            userc.Id = 10;

            ChangeValue(userc);

            var users = new UserStruct();
            users.Id = 10;
            ChangeValue(users);

            Console.WriteLine(userc.Id);
            Console.WriteLine(users.Id);

        }
        public static void ChangeValue(UserClass user)
        {
            user.Id = -1;
        }
        public static void ChangeValue(UserStruct user)
        {
            user.Id = -1;
        }
        private static void StructNull()
        {

            UserClass user = null;

            //UserStruct user1 = null;//ERROR
            UserStruct user2 = default;
            UserStruct user3 = new UserStruct();

        }
        private static void ParameterlessConstructor()
        {

        }


        private static void Assingments()
        {
            //int x = 1;
            //int y = x;

            //x = 10;

            //Console.WriteLine(y);


            var user_c = new UserClass();
            user_c.Id = 1;

            var user_c1 = user_c;

            user_c1.Id = 10;
            Console.WriteLine(user_c1.Id);
        }
        private static void InterfaceImplentation()
        {
            IUser user = new UserClass();
            user.Id = 1;
            IUser user2 = user;
            user2.Id = 10;
            Console.WriteLine(user.Id);


            IUser userS = new UserStruct();
            userS.Id = 1;
            IUser user2s = user;
            user2s.Id = 10;
            Console.WriteLine(userS.Id);
        }
        public class UserClass : IUser
        {
            public UserClass()
            {

            }

            public UserClass(int id, string fullName)
            {
                Id = id;
                FullName = fullName;
            }
            public UserClass InlineClass { get; set; }
            public int Id { get; set; }
            public string FullName { get; set; }
        }
        public struct UserStruct : IUser
        {
            //public UserStruct()///////ERROR
            //{

            //}
            //public UserStruct()////////ERROR C#10'a kadar
            //{
            //    Id = 0;
            //    FullName = string.Empty;
            //}
            public int Id { get; set; }
            public string FullName { get; set; }
           // public UserStruct InlineStruct { get; set; }//ERROR -> kendilerini alamaz ama başka struct alır.

        }
        public interface IUser
        {
            public int Id { get; set; }
            public string FullName { get; set; }
        }
    }
}
