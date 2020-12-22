using System;
namespace Homework
{
    public class Duelist
    {

        private string name;
        private double accuracy;
        private bool alive = true;
        private int wins;

        public Duelist(string name, double accuracy)
        {
            this.name = name;
            this.accuracy = accuracy;
        }

        public void ShootAtTarget(Duelist target)
        {
            double random = new Random().NextDouble();
            if (random <= accuracy) target.alive = false;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }

        public int Wins
        {
            get { return wins; }
            set { wins = value; }
        }

        public bool Equals(Duelist other)
        {
            return name.Equals(other.name);
        }
    }
}
