namespace LabLibrary
{
    public class MyString
    {
        private string _value; // Приватне поле для зберігання тексту

        public string Value => _value; // Властивість для читання
        public int Length => _value.Length; // Властивість для отримання довжини

        public MyString(string value)
        {
            _value = value;
        }

        public void Upper()
        {
            _value = _value.ToUpper();
        }
    }
}