/*
***EVENT RSVP PORTAL***
*Author: Brian McKeown
*August 2016
*
*Class: Couple
*This class defines the Couple Invitee type. 
*/

using System;

namespace EventRSVPportal
{
	public class Couple:Invitee
	{
		private int numGuests;
		private string name1;
		private string name2;
		private string food1;
		private string food2;

		//Constructor:
		public Couple (bool responded, bool attending, int guests, string name1, string name2, string food1, string food2,
			int invNum, int login)
		{
			this.responded = responded;
			this.attending = attending;
			numGuests = guests;
			this.name1 = name1;
			this.name2 = name2;
			this.food1 = food1;
			this.food2 = food2;
			this.invNum = invNum;
			this.login = login;
			}

		//Getter Methods:
		public bool getResponded() {
			return responded;
		}
		public bool isAttending() {
			return attending;
		}
		public int getGuestCount() {
			return numGuests;
		}
		public string getName1() {
			return name1;
		}
		public string getName2() {
			return name2;
		}
		public string getFood1() {
			return food1;
		}
		public string getFood2() {
			return food2;
		}
		public int getInvNum() {
			return invNum;
		}
		public int getLogin() {
			return login;
		}

		//Setter Methods:
		public void setResponded(bool responded) {
			this.responded = responded;
		}
		public void setAttending(bool attending) {
			this.attending = attending;
		}
		public void setGuestCount(int guests) {
			numGuests = guests;
		}
		public void setName1(string name1) {
			this.name1 = name1;
		}
		public void setName2(string name2) {
			this.name2 = name2;
		}
		public void setFood1(string food1) {
			this.food1 = food1;
		}
		public void setFood2(string food2) {
			this.food2 = food2;
		}
		public void setInvNum(int invNum) {
			this.invNum = invNum;
		}
		public void setLogin(int login) {
			this.login = login;
		}
	}
}