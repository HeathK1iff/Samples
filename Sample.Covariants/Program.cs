// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

Console.WriteLine("Hello, World!");

//Covariants
ICovariantList<Car> list = new LamborCarList();


//Cotrvariants
IContrvariantList<LamborCar> list2 = new CarList();

public interface ICovariantList<out T> where T: Car
{
    public T GetItem(int i);
}

public class LamborCarList : ICovariantList<LamborCar>
{
    public LamborCar GetItem(int i)
    {
        throw new NotImplementedException();
    }
}

public interface IContrvariantList<in K> where K: class
{
    public void GetItem(K i);
}

public class CarList : IContrvariantList<Car>
{
    public void GetItem(Car i)
    {
        throw new NotImplementedException();
    }
}


public class Car
{
}

public class LamborCar : Car
{

}