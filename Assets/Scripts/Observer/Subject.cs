using System.Collections.Generic;

public class Subject {
    private List<Observer> observers = new List<Observer>();
    public Subject OnWalk;

    object sender;

    public Subject(object sender) {
        this.sender = sender;
    }

    void Awake() 
    {
        OnWalk = new Subject(this);
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (Observer observer in observers)
        {
            observer.SubjectUpdate(sender);

        }
    }

    /**
        Todo:
            Implement methods: 
                * AddObserver - Used by observers to register to this subject
                * RemoveObserver - Used by observers to deregister from this subject
                * Notify - Used by owner of this subject to notify observers, that something has happened.   
        */

}
