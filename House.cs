﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyhouseDomotique
{
    /// <summary>
    /// House classe
    /// </summary>
    public class House
    {
        // house data
        public List<Room> Rooms { get; set; } // a house contain multiples Room
        public List<Wall> Walls { get; set; } // a house contain multiples walls

        // constructor
        public House()
        {
            this.Rooms = new List<Room>();
            this.Walls = new List<Wall>();
            
            // adding all the rooms
            this.addRoom("Exterieur", 0); // ID = 0
            this.addRoom("Salon", 19);    // ID = 1
            this.addRoom("Cuisine", 17);  // ID = 2
            this.addRoom("Chambre", 20);  // ID = 3

            // adding the walls and opening
            this.addWall(this.Rooms[0], this.Rooms[1]); // between exterior and saloon ID = 0
            this.Walls[0].addOpening("Porte entrée");
            this.Walls[0].addOpening("Fenêtre gauche");
            this.Walls[0].addOpening("Fenêtre droite");

            this.addWall(this.Rooms[0], this.Rooms[2]); // between exterior and kitchen ID = 1
            this.Walls[1].addOpening("Fenêtre cuisine");

            this.addWall(this.Rooms[0], this.Rooms[3]); // between exterior and bedroom ID = 2
            this.Walls[2].addOpening("Fenêtre chambre");

            this.addWall(this.Rooms[1], this.Rooms[2]); // between saloon and kitchen ID = 3
            this.Walls[3].addOpening("Porte cuisine");

            this.addWall(this.Rooms[1], this.Rooms[3]); // between saloon and bedroom ID = 4
            this.Walls[4].addOpening("Porte chambre");

            this.addWall(this.Rooms[2], this.Rooms[3]); // between kitchen and bedroom ID = 5
        }

        // adding a room to the list
        public void addRoom(string getName, double getDefault_temp)
        {
            Rooms.Add(new Room { name = getName, default_temp = getDefault_temp });
        }
        // adding a wall
        public void addWall(Room getRoom1, Room getRoom2)
        {
            Walls.Add(new Wall { Room1 = getRoom1, Room2 = getRoom2 });
        }
    }

    /// <summary>
    /// A room class
    /// </summary>
    public class Room
    {
        // room data
        public string name { get; set; }
        public double default_temp { get; set; }
    }

    /// <summary>
    /// Wall class
    /// </summary>
    public class Wall
    {
        // wall data
        public List<Opening> Openings { get; set; }
        public Room Room1 { get; set; }
        public Room Room2 { get; set; }

        public Wall()
        {
            this.Openings = new List<Opening>();
        }

        public void addOpening(string getName)
        {
            Openings.Add(new Opening { name = getName, state = false });
        }
    }

    /// <summary>
    /// Oening class
    /// </summary>
    public class Opening
    {
        public string name { get; set; }
        public Boolean state { get; set; }
    }
}
