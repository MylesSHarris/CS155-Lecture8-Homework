using System;

namespace Homework
{
    public class Homework
    {
        static void Main(string[] arguments)
        {
            Duelist[] duelists = new Duelist[3];
            duelists[0] = new Duelist("Aaron", 0.333);
            duelists[1] = new Duelist("Bob", 0.5);
            duelists[2] = new Duelist("Charlie", 0.995);

            for (int i=0; i<10000; i++)
            {
                SimulateDuel(duelists, false);
            }

            foreach (Duelist duelist in duelists)
            {
                double percentage = Math.Round(duelist.Wins / 100.0, 2);

                Console.WriteLine($"{duelist.Name} won {duelist.Wins}/10000 duels or {percentage}%");
            }
        }

        static void SimulateDuel(Duelist[] duelists, bool skipFirst)
        {
            foreach (Duelist duelist in duelists)
            {
                duelist.Alive = true;
            }

            int round = 0;
            while (CountAlive(duelists) > 1)
            {
                for (int shooterIndex=0; shooterIndex<3; shooterIndex++)
                {
                    if (round == 0 && shooterIndex == 0 && skipFirst) continue;
                    Duelist shooter = duelists[shooterIndex];
                    Duelist target = GetBestTarget(duelists, shooterIndex);

                    if (shooter.Alive) shooter.ShootAtTarget(target);
                }
                round++;
            }

            foreach (Duelist duelist in duelists)
            {
                if (duelist.Alive) duelist.Wins++;
            }
        }

        static int CountAlive(Duelist[] duelists)
        {
            int alive = 0;
            foreach (Duelist duelist in duelists)
            {
                if (duelist.Alive) alive++;
            }
            return alive;
        }

        static Duelist GetBestTarget(Duelist[] duelists, int shooterIndex)
        {
            if (shooterIndex == 0) return (duelists[2].Alive) ? duelists[2] : duelists[1];
            if (shooterIndex == 1) return (duelists[2].Alive) ? duelists[2] : duelists[0];
            if (shooterIndex == 2) return (duelists[1].Alive) ? duelists[1] : duelists[0];
            return null;
        }
    }
}
