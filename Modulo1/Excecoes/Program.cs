try
{
    try
    {
        object o = null;
        o.ToString();
    }
    catch (NullReferenceException ex)
    {
        throw new Exception("Ocorreu um erro: Tentativa de realizar uma operação em um objeto nulo.", ex);
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
