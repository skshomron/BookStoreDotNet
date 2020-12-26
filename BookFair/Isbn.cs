using System.Collections.Generic;
using System.Linq;
namespace BookFair
{
    delegate Isbn CreateIsbnDelegate(string code);
    public interface IIsbnBuilder
    {
        
    }
    public class ISBNFactory
    {
      
        public static bool TryParse(string code, out Isbn isbn)
        {
            isbn = null;
            if(code.Length == Isbn10.ISBN_10_LENGTH)
            {
                isbn = null;
            }
            return false;
        }
    }




    public abstract class Isbn
    {
        protected int[] _digits;       
        protected abstract int[] GetISBNDigitfromString(string code);
        public abstract int GetISBNDigitLength();
        public abstract Isbn Create(string code);
        protected abstract bool CheckISBNValidity(int[] isbn);
    }
    public class Isbn13 : Isbn
    {
        public static int ISBN_13_LENGTH = 13;

        private Isbn13(int[] digits)
        {
            _digits = digits;
        }

        protected override bool CheckISBNValidity(int[] digits)
        {
            throw new System.NotImplementedException();
        }

        public override Isbn Create(string code)
        {
            Isbn ret = null;
            if (code.Length == ISBN_13_LENGTH)
            {
                var isbnDigits = GetISBNDigitfromString(code);
                if (CheckISBNValidity(isbnDigits))
                {
                    ret = new Isbn13(isbnDigits);
                }
            }
            return ret;
        }

        protected override int[] GetISBNDigitfromString(string code)
        {
            var isbnInt = new int[ISBN_13_LENGTH];
            for (var i = 0; i < ISBN_13_LENGTH; i++)
            {
                if (int.TryParse(code[i].ToString(), out var digit))
                {
                    isbnInt[i] = digit;
                }
            }
            return isbnInt;
        }

        public override int GetISBNDigitLength()
        {
            return ISBN_13_LENGTH;
        }
    }
    public class Isbn10 : Isbn
    {
        public static int ISBN_10_LENGTH = 10;

        private Isbn10(int[] digits)
        {
            _digits = digits;
        }
        //https://en.wikipedia.org/wiki/International_Standard_Book_Number#Check_digits
        // Returns ISBN error syndrome, zero for a valid ISBN, non-zero for an invalid one.
        // digits[i] must be between 0 and 10.
        protected override bool CheckISBNValidity(int[] digits)
        {
            if (digits?.Length != ISBN_10_LENGTH)
            {
                return false;
            }

            int i, s = 0, t = 0;
            for (i = 0; i < ISBN_10_LENGTH; i++)
            {
                t += digits[i];
                s += t;
            }
            return s % 11 == 0;
        }
                
        protected override int[] GetISBNDigitfromString(string code)
        {
            var isbnInt = new int[ISBN_10_LENGTH];
            for (var i = 0; i < ISBN_10_LENGTH; i++)
            {
                if (int.TryParse(code[i].ToString(), out var digit))
                {
                    isbnInt[i] = digit;
                }
                if (i == 9 && string.Compare(code[9].ToString(), "x", true) == 0)
                {
                    isbnInt[i] = ISBN_10_LENGTH;
                }
            }
            return isbnInt;
        }

        public override Isbn Create(string code)
        {
            Isbn ret = null;
            int[] isbnDigits = null;
            if (code.Length == ISBN_10_LENGTH)
            {
                isbnDigits = GetISBNDigitfromString(code);
                if (CheckISBNValidity(isbnDigits))
                {
                    ret = new Isbn10(isbnDigits);
                }
            }
            return ret;
        }

        public override int GetISBNDigitLength()
        {
            return ISBN_10_LENGTH;
        }
    }
}
