using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Data
{
    public class DataConstants
    {
        
        public const int defaultMinLenght = 5;

        public const int defaultMaxLenght = 20;

        public const int passwordMinLenght = 6;

        public const int repositoryNameMinLenght = 3;

        public const int repositoryNameMaxLenght = 10;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    }
}
