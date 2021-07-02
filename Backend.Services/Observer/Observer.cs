using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Services.Observer
{
    //Observer Patter
    //Use the IObserver and IObservable interfaces
    public class Observer
    {
        public Observer()
        {
            var notification = new Notification();
            notification.Subscribe(new Reciever());
            notification.Alert();
        }
        

        //IObservable - allows us to observe a certain class
        public class Notification : IObservable<int>
        {
            //have a list of observers
            List<IObserver<int>> watchers = new List<IObserver<int>>();
            //whenever an observer is added add them to the list of watchers
            public IDisposable Subscribe(IObserver<int> observer)
            {
                watchers.Add(observer);
                return (IDisposable)this;
            }
            //get each watcher and notify their onNext method witht he new value
            public void Alert()
            {
                watchers.ForEach(w => w.OnNext(1));
            }
        }

        //IObservable - allows to recieve OnNext() with the value recieved from the observable
        public class Reciever : IObserver<int>
        {
            public void OnCompleted()
            {
                throw new NotImplementedException();
            }

            public void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            //Do something with the value recieved
            public void OnNext(int value)
            {
                Console.WriteLine(value);
            }
        }
    }
}
