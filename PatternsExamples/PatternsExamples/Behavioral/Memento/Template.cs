namespace PatternsExamples.Behavioral.Memento
{
    class Memento
    {
        public string State { get; }

        public Memento(string state)
        {
            State = state;
        }
    }

    class Caretaker
    {
        public Memento Memento { get; set; }
    }

    class Originator
    {
        public string State { get; set; }

        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }

        public Memento CreateMemento()
        {
            return new Memento(State);
        }
    }
}
