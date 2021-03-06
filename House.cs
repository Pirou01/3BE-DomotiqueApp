﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

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
            this.addRoom("Exterieur", 0, 15, 999999999, 999999999, 0); // ID = 0
            this.addRoom("Salon", 1, 20, 20.4, 3886.45, 100);    // ID = 1
            this.addRoom("Cuisine", 2, 20, 8.16, 2748.24, 50);  // ID = 2
            this.addRoom("Chambre", 3, 20, 12.24, 3631.30, 50);  // ID = 3

            // adding the walls and opening
            this.addWall(0, this.Rooms[0], this.Rooms[1]); // between exterior and saloon ID = 0
            this.Walls[0].addOpening("Porte entrée");
            this.Walls[0].addOpening("Fenêtre gauche");
            this.Walls[0].addOpening("Fenêtre droite");

            this.addWall(1, this.Rooms[0], this.Rooms[2]); // between exterior and kitchen ID = 1
            this.Walls[1].addOpening("Fenêtre cuisine");

            this.addWall(2, this.Rooms[0], this.Rooms[3]); // between exterior and bedroom ID = 2
            this.Walls[2].addOpening("Fenêtre chambre");

            this.addWall(3, this.Rooms[1], this.Rooms[2]); // between saloon and kitchen ID = 3
            this.Walls[3].addOpening("Porte cuisine");

            this.addWall(4, this.Rooms[1], this.Rooms[3]); // between saloon and bedroom ID = 4
            this.Walls[4].addOpening("Porte chambre");

            this.addWall(5, this.Rooms[2], this.Rooms[3]); // between kitchen and bedroom ID = 5
        }

        // adding a room to the list
        public void addRoom(string getName, Int32 getIDRoom, double getTempratureOrder, double getVolume, double getT0, double getHeating_power)
        {
            Rooms.Add(new Room { name = getName, IDRoom = getIDRoom, temperature_order = getTempratureOrder, volume = getVolume, t0 = getT0, Heating_power = getHeating_power });
        }
        // adding a wall
        public void addWall(Int32 getIDWall, Room getRoom1, Room getRoom2)
        {
            Walls.Add(new Wall { IDWall = getIDWall, Room1 = getRoom1, Room2 = getRoom2 });
        }
    }

    /// <summary>
    /// A room class
    /// </summary>
    public class Room
    {
        // room data
        public string name { get; set; }
        public Int32 IDRoom { get; set; }
        public Boolean hot_is_active { get; set; }
        public Boolean light_is_active { get; set; }
        public double temperature { get; set; }
        public double temperature_order { get; set; }
        public double volume { get; set; }
        public double t0 { get; set; }
        public double Heating_power { get; set; }

        public Room()
        {
            this.hot_is_active = false;
            this.light_is_active = false;
        }
    }

    /// <summary>
    /// Wall class
    /// </summary>
    public class Wall
    {
        // wall data
        public List<Opening> Openings { get; set; }
        public Int32 IDWall { get; set; }
        public Room Room1 { get; set; }
        public Room Room2 { get; set; }

        public Wall()
        {
            this.Openings = new List<Opening>();
        }

        public void addOpening(string getName)
        {
            Openings.Add(new Opening { name = getName });
        }
    }

    /// <summary>
    /// Oening class
    /// </summary>
    public class Opening
    {
        public string name { get; set; }
        public Boolean isOpen { get; set; }

        public Opening()
        {
            this.isOpen = false;
        }

        /// <summary>
        /// To change the state of an opening
        /// </summary>
        /// <param name="getIsOpen"></param>
        public void ChangeState(Boolean getIsOpen)
        {
            if (this.isOpen != getIsOpen)
            {
                //need to place a sql resquest to add into the database
                this.isOpen = getIsOpen;
            }
        }
    }
}
