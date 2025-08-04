namespace ApiPaisesProyecto.Servicios
{
    public interface ISaludo
    {
        string Saludar(string nombre);
    }

    public class Saludo : ISaludo
    {
        public string Saludar(string nombre)
        {
            return $"Hola, {nombre}!";
        }
    }

    // Implementación alternativa de ISaludo en ingles
    public class EnglishSaludo : ISaludo
    {
        public string Saludar(string nombre)
        {
            return $"Hello, {nombre}!";
        }
    }

    // Implementación alternativa de ISaludo en francés
    public class FrenchSaludo : ISaludo
    {
        public string Saludar(string nombre)
        {
            return $"Bonjour, {nombre}!";
        }
    }

    // Implementación alternativa de ISaludo en alemán
    public class GermanSaludo : ISaludo
    {
        public string Saludar(string nombre)
        {
            return $"Hallo, {nombre}!";
        }
    }
    // Implementación alternativa de ISaludo en italiano
    public class ItalianSaludo : ISaludo
    {
        public string Saludar(string nombre)
        {
            return $"Ciao, {nombre}!";
        }
    }
    // Implementación alternativa de ISaludo en portugués
    public class PortugueseSaludo : ISaludo
    {
        public string Saludar(string nombre)
        {
            return $"Olá, {nombre}!";
        }
    }
    // Implementación alternativa de ISaludo en chino
    public class ChineseSaludo : ISaludo
    {
        public string Saludar(string nombre)
        {
            return $"你好, {nombre}!";
        }
    }





}
