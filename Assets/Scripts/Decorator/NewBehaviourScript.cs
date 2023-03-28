using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IPizza pizz = new Pizza();
        print(pizz.GetPizzaType());

        IPizza cheesedeco = new CheeseDeco(pizz);
        IPizza pinedeco = new PineAppleDeco(cheesedeco);
        print(pinedeco.GetPizzaType());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


//base interface
interface IPizza 
{
    string GetPizzaType();
}

//concrete class
class Pizza : IPizza
{
    public string GetPizzaType()
    {
        return "normal pizza";
    }
}

//base decorator
class PizzaDecorator : IPizza
{
    private IPizza _pitsa;

    public PizzaDecorator(IPizza pizza)
    {
        _pitsa = pizza;
    }

    public virtual string GetPizzaType()
    {
        return _pitsa.GetPizzaType();
    }
}

//concrete decorator
class PineAppleDeco : PizzaDecorator 
{
    public PineAppleDeco(IPizza pizza) : base(pizza)
    {

    }

    public override string GetPizzaType()
    {
        string type = base.GetPizzaType();
        type += "\r\n + pine";
        return type;
    }
}

class CheeseDeco : PizzaDecorator
{
    public CheeseDeco(IPizza pizza) : base(pizza)
    {

    }

    public override string GetPizzaType()
    {
        string type = base.GetPizzaType();
        type += "\r\n + cheese";
        return type;
    }
}