using ApiTesting.Objects;

namespace ApiTesting.Builders
{
    public class UserBuilder
    {
        private int _id = 1;
        private string _firstName = "John";
        private string _lastName = "Doe";
        private string _email = "john.doe@example.com";

        public UserBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public UserBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public User Build()
        {
            return new User
            {
                Id = _id,
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email
            };
        }
    }
}
