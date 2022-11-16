﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableReservation.Models
{
    public enum State
    {
        Free = 0,
        Booked = 1
    }
    public class Table
    {
        public State State { get; private set; }
        public int SeatsCount { get; }
        public int Id { get; }

        public Table(int id)
        {
            Id = id;
            State = State.Free;
            SeatsCount = Random.Shared.Next(2, 5);
        }

        public bool SetState(State state)
        {
            if (state == State)
                return false;
            State = state;
            return true;
        }
    }
}
