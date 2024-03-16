namespace TrianguloGeometrico
{
    public struct Ponto<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }
    }

    public struct Triangulo<T>
    {
        public Ponto<T> P1 { get; set; }
        public Ponto<T> P2 { get; set; }
        public Ponto<T> P3 { get; set; }

        public override string ToString()
        {
            return $"P1: {P1}; P2: {P2}; P3: {P3}";
        }
    }
}