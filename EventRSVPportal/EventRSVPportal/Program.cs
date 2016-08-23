/*
***EVENT RSVP PORTAL***
*Author: Brian McKeown
*August 2016
*
*This program has a predifined wedding guest list. The list is made of two data structures (lists), for both
*a single type wedding invitation, and couple type invitation. (Single types may bring a guest if they choose). 
*The portal requires guests to enter their login ID #, as well as invitation # to gain access to the portal. This
*security ensures that only the invitation recipient is RSVPing to the wedding. 
*
*Once logged in, the user can update their attending status, name(s), and choice of food. 
*
*The Administrator may also log in to view the current data statistics. More tools will be added in the future:
*ability to add and remove invitations, etc. 
*
*Main Class: the Run() and reRun() methods put together the various menus of this program, and allow the user to
*iterate through with ease. There are also various prompt and data calculation methods that help display needed
*information. 

*/

using System;
using System.Collections.Generic;

namespace EventRSVPportal
{
	class MainClass
	{
		//Create Guest Lists and Admin info:
		static List<Couple> coupleList = new List<Couple> ();
		static List<Single> singleList = new List<Single> ();
		static int finalIndex;
		const string adminLogin = "ADMIN";
		const string adminPass = "PASSWORD";

		public static void Main (string[] args)
		{
			run();
		}

		public static void fillGuestLists() {

			//Creates Guest List Entries: 
			//The following guests have ALREADY responded:
			Single johnSmith = new Single (true, true, true, 2, "John Smith", "Sally Johnson", "Chicken", "Chicken", 101, 1028101);
			Single kellyWatson = new Single (true, true, false, 1, "Kelly Watson", "", "Beef", "", 102, 1028102);
			Single kevinDolan = new Single (true, true, true, 2, "Kevin Dolan", "Melanie Borris", "Beef", "Chicken", 103, 1028103);
			Couple ashleyDan = new Couple (true, true, 2, "Ashley Pope", "Dan Pope", "Chicken", "Chicken", 201, 1028201);
			Couple billChristine = new Couple (true, true, 2, "Bill Jacobs", "Christine Jacobs", "Beef", "Beef", 202, 1028202);
			Couple krissyChris = new Couple (true, true, 2, "Krissy Karuso", "Chris Columbus", "Chicken", "Beef", 203, 1028203);

			//The following guests have not responded yet:
			Single dwightShrute = new Single (false, false, false, 1, "Dwight Shrute", "", "", "", 104, 1028104);
			Single harryPotter = new Single (false, false, false, 1, "Harry Potter", "", "", "", 105, 1028105);
			Couple pamJim = new Couple (false, false, 2, "Pam Beesley", "Jim Halper", "", "", 204, 1028204);
			Couple saraBob = new Couple (false, false, 2, "Sara James", "Bob James", "", "", 205, 1028205);

			//Adds Entries to Lits:
			coupleList.Add(ashleyDan);
			coupleList.Add(billChristine);
			coupleList.Add(krissyChris);
			coupleList.Add(pamJim);
			coupleList.Add(saraBob);
			singleList.Add(johnSmith);
			singleList.Add(kellyWatson);
			singleList.Add(kevinDolan);
			singleList.Add(dwightShrute);
			singleList.Add(harryPotter);

		}

		//The run() method. This is the first run which will build the list data before running the menus.
		public static void run() {

			fillGuestLists();
			titlePrompt();

			string firstAns = introPrompt ();

			if (firstAns == "A") {

				//SECURITY: The following loops check to make sure the login ID and invitation # are both valid, and match. 
				bool coupleIdCheck = false;
				bool singleIdCheck = false;
				int gAns1 = 0;
				int coupleIndex = -1;
				int singleIndex = -1;

				while (coupleIdCheck == false && singleIdCheck == false) {
					gAns1 = guestPrompt1 ();

					for (int i = 0; i < coupleList.Count; i++) {
						if (gAns1 == coupleList [i].getLogin ()) {
							coupleIdCheck = true;
							coupleIndex = i;
							break;
						} else {
							coupleIdCheck = false;
						}
					}
					for (int i = 0; i < singleList.Count; i++) {
						if (gAns1 == singleList [i].getLogin ()) {
							singleIdCheck = true;
							singleIndex = i;
							break;
						} else {
							singleIdCheck = false;
						}
					}
					if (coupleIdCheck == false && singleIdCheck == false) {
						Console.WriteLine ("The Login ID you entered, is invalid. Please check your " +
						"invitation, and try again.");
					}

				}
				bool coupleInvCheck = false;
				bool singleInvCheck = false;
				int gAns2 = 0;
				int coupleIndex2 = -1;
				int singleIndex2 = -1;

				while (coupleInvCheck == false && singleInvCheck == false) {
					gAns2 = guestPrompt2 ();

					for (int i = 0; i < coupleList.Count; i++) {
						if (gAns2 == coupleList [i].getInvNum ()) {
							coupleInvCheck = true;
							coupleIndex2 = i;
							break;
						} else {
							coupleInvCheck = false;
						}
					}
					for (int i = 0; i < singleList.Count; i++) {
						if (gAns2 == singleList [i].getInvNum ()) {
							singleInvCheck = true;
							singleIndex2 = i;
							break;
						} else {
							singleInvCheck = false;
						}
					}
					if (coupleInvCheck == false && singleInvCheck == false) {
						Console.WriteLine ("The invitation # you entered, is either invalid, or does not match your Login ID." +
						" Please check your invitation, and try again.");
					} else if (gAns1 - 1028000 != gAns2) {
						coupleInvCheck = false;
						singleInvCheck = false;
						Console.WriteLine ("The invitation # you entered, is either invalid, or does not match your Login ID." +
						" Please check your invitation, and try again.");
					}

				}
				// Get couple or single invitee based on index found:
				string guestName1;
				string guestName2;
				int whichList;

				if (coupleIndex >= 0) {
					finalIndex = coupleIndex;
					whichList = 2;
					guestName1 = coupleList [finalIndex].getName1 ();
					guestName2 = coupleList [finalIndex].getName2 ();
				} else {
					finalIndex = singleIndex;
					whichList = 1;
					guestName1 = singleList [finalIndex].getName1 ();
					guestName2 = singleList [finalIndex].getName2 ();
				}
				if (guestName2 == "") {
					Console.WriteLine ("\nWelcome " + guestName1 + "!");
				} 
				else {
					Console.WriteLine ("\nWelcome " + guestName1 + " and " + guestName2 + "!");
				}
				if (whichList == 1) {
					singleGuestMenu ();
				} else {
					coupleGuestMenu ();
				}

			}

			//Admin login option: calls adminPrompt() method. 
			else
				adminPrompt();
			
		}
		//This method is almost identical to the run() method, except it does not include the initial build of lists.
		//This allows the program to continue to update it's data without resetting everytime the user loops back to 
		//the main menu. 
		public static void reRun() {
			titlePrompt();

			string firstAns = introPrompt ();

			if (firstAns == "A") {

				bool coupleIdCheck = false;
				bool singleIdCheck = false;
				int gAns1 = 0;
				int coupleIndex = -1;
				int singleIndex = -1;

				while (coupleIdCheck == false && singleIdCheck == false) {
					gAns1 = guestPrompt1 ();

					for (int i = 0; i < coupleList.Count; i++) {
						if (gAns1 == coupleList [i].getLogin ()) {
							coupleIdCheck = true;
							coupleIndex = i;
							break;
						} else {
							coupleIdCheck = false;
						}
					}
					for (int i = 0; i < singleList.Count; i++) {
						if (gAns1 == singleList [i].getLogin ()) {
							singleIdCheck = true;
							singleIndex = i;
							break;
						} else {
							singleIdCheck = false;
						}
					}
					if (coupleIdCheck == false && singleIdCheck == false) {
						Console.WriteLine ("The Login ID you entered, is invalid. Please check your " +
							"invitation, and try again.");
					}

				}
				bool coupleInvCheck = false;
				bool singleInvCheck = false;
				int gAns2 = 0;
				int coupleIndex2 = -1;
				int singleIndex2 = -1;

				while (coupleInvCheck == false && singleInvCheck == false) {
					gAns2 = guestPrompt2 ();

					for (int i = 0; i < coupleList.Count; i++) {
						if (gAns2 == coupleList [i].getInvNum ()) {
							coupleInvCheck = true;
							coupleIndex2 = i;
							break;
						} else {
							coupleInvCheck = false;
						}
					}
					for (int i = 0; i < singleList.Count; i++) {
						if (gAns2 == singleList [i].getInvNum ()) {
							singleInvCheck = true;
							singleIndex2 = i;
							break;
						} else {
							singleInvCheck = false;
						}
					}
					if (coupleInvCheck == false && singleInvCheck == false) {
						Console.WriteLine ("The invitation # you entered, is either invalid, or does not match your Login ID." +
							" Please check your invitation, and try again.");
					} else if (gAns1 - 1028000 != gAns2) {
						coupleInvCheck = false;
						singleInvCheck = false;
						Console.WriteLine ("The invitation # you entered, is either invalid, or does not match your Login ID." +
							" Please check your invitation, and try again.");
					}

				}
				// Get couple or single invitee based on index found:
				string guestName1;
				string guestName2;
				int whichList;

				if (coupleIndex >= 0) {
					finalIndex = coupleIndex;
					whichList = 2;
					guestName1 = coupleList [finalIndex].getName1 ();
					guestName2 = coupleList [finalIndex].getName2 ();
				} else {
					finalIndex = singleIndex;
					whichList = 1;
					guestName1 = singleList [finalIndex].getName1 ();
					guestName2 = singleList [finalIndex].getName2 ();
				}
				if (guestName2 == "") {
					Console.WriteLine ("\nWelcome " + guestName1 + "!");
				} 
				else {
					Console.WriteLine ("\nWelcome " + guestName1 + " and " + guestName2 + "!");
				}
				if (whichList == 1) {
					singleGuestMenu ();
				} 
				else {
					coupleGuestMenu ();
				}

			}

			//Admin login option: Calls the adminPrompt() method.
			else
				adminPrompt();

		}

		//initial title of program
		public static void titlePrompt(){
			Console.WriteLine("***********************************");
			Console.WriteLine("Welcome to the Wedding RSVP Portal!");
			Console.WriteLine("***********************************");
			Console.WriteLine ("\n\n ***Kayla & Brian 10/28/2017***\n\n");
		}

		//initial prompt of program, choose between invitation recipient or admin.
		public static void printPrompt() {
			Console.WriteLine ("Are you responding to an invitation, or are you the administrator?");
			Console.WriteLine ("A) Responding to an invitation. \nB) I'm the administrator.\nType EXIT to leave.\n\n Type A,B or EXIT.");
		}

		//invitee choice selected:
		public static string introPrompt() {

			bool answerCheck = false;
			string answer = null;

			//do loop checks for valid input:
			do {
				printPrompt();
				answer = Console.ReadLine();
				answer = answer.ToUpper();

				if (answer == "A" || answer == "B") {
					answerCheck = true;
				}
				else if (answer == "EXIT") {
					Console.WriteLine("\nGoodbye!\n");
					answerCheck = true;
					Environment.Exit(0);
				}
				else {
					Console.WriteLine ("\nThat was not a valid respone, please try again:\n");
					answerCheck = false;
				}
			}
			while(answerCheck == false);

			return answer;
		}

		public static int guestPrompt1() {

			bool validInput = false;
			int loginID = 0;

			do {
				Console.WriteLine ("Please enter your login ID: ");
				validInput = true;

				try {
					loginID = Convert.ToInt32 (Console.ReadLine ());
				} catch (FormatException) {
					Console.WriteLine ("Invalid.");
					validInput = false;
				}
			} while(validInput == false);
			return loginID;
		}
		public static int guestPrompt2() {

			bool validInput = false;
			int invNum = 0;

			do {
				Console.WriteLine ("Please enter your invitation #: ");
				validInput = true;

				try {
					invNum = Convert.ToInt32 (Console.ReadLine ());
				} catch (FormatException e) {
					Console.WriteLine ("Invalid");
					validInput = false;
				}
			} while (validInput == false);
			return invNum;
		}

		//once logged in, guest menu for single invitees:
		public static void singleGuestMenu(){

			string attending;
			string responded;
			string guestAttend;
			int choice = 0; //initialized
			string convChoice;

			Console.WriteLine("**********MENU**********\n");

			if (singleList [finalIndex].isAttending () == true) {
				attending = "Yes";
			} else {
				attending = "No";
			}
			if (singleList [finalIndex].getResponded () == true) {
				responded = "Yes";
			} else {
				responded = "No";
			}
			if (singleList [finalIndex].isBringingGuest () == true) {
				guestAttend = "Yes";
			} else {
				guestAttend = "No";
			}

			Console.WriteLine("Responded: " + responded + "\n");
			Console.WriteLine("1) Attending: " + attending);
			Console.WriteLine ("2) Guest Attending: " + guestAttend); 
			Console.WriteLine("3) Guest 1: " + singleList[finalIndex].getName1());
			Console.WriteLine("4) Guest 2: " + singleList[finalIndex].getName2());
			Console.WriteLine("5) Food 1: " + singleList[finalIndex].getFood1());
			Console.WriteLine("6) Food 2: " + singleList[finalIndex].getFood2());
			Console.WriteLine("7) Home Menu");
			Console.WriteLine("8) Exit");
			Console.WriteLine ("\n-If you need to make an adjustment, please type the corresponding number from the list.");

			//catches non integer input and handles exception. 
			try {
				choice = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException e) {
				Console.WriteLine ("Invalid Response.");
				singleGuestMenu();
			}

			//switch statement to choose what user would like to update:
			switch (choice) {

			//Attending
			case 1: 
				Console.WriteLine ("Will you be attending the wedding?\nType YES or NO:");
				string answer1 = Console.ReadLine ();
				answer1 = answer1.ToUpper ();

				if (answer1 == "YES") {
					singleList [finalIndex].setAttending (true);
					singleList [finalIndex].setResponded (true);
					Console.WriteLine ("Great! Are you bringing a guest?\nType YES or NO:");
					string answer11 = Console.ReadLine ();
					answer11 = answer11.ToUpper ();

					if (answer11 == "YES") {
						singleList [finalIndex].setGuestCount (2);
						Console.WriteLine ("Awesome! Please type your guest's first and last name: ");
						singleList[finalIndex].setName2(Console.ReadLine());
						singleList [finalIndex].changeBringingGuest (true);
						singleList [finalIndex].setGuestCount (2);
						Console.WriteLine ("Great! Your guest has been added! Don't forget to choose food if you haven't " +
						"already!");
						singleGuestMenu ();

					} else if (answer11 == "NO") {
						singleList [finalIndex].setGuestCount (1);
						singleList [finalIndex].setName2 ("");
						singleList [finalIndex].setFood2 ("");
						Console.WriteLine ("OK. Thank you!");
						singleGuestMenu ();
					} 
					else {
						Console.WriteLine ("Invalid Response");
						singleGuestMenu ();
					}
				} else if (answer1 == "NO") {
					singleList [finalIndex].setAttending (false);
					singleList [finalIndex].setResponded (true);
					singleList [finalIndex].setGuestCount (1);
					singleList [finalIndex].setFood1 ("");
					singleList [finalIndex].setFood2 ("");
					singleList [finalIndex].setName2 ("");
					singleList [finalIndex].changeBringingGuest (false);
					Console.WriteLine ("Sorry to hear you can't make it! Thank you for replying.");
					singleGuestMenu ();
				} else {
					Console.WriteLine ("Invalid Response");
					singleGuestMenu ();
				}
				break;

			//Guest Attending
			case 2: 
				if (guestAttend == "Yes" && attending == "Yes") {
					Console.WriteLine ("Would you like to remove your guest?\nType YES or NO:");
					string answer2 = Console.ReadLine ();
					answer2 = answer2.ToUpper ();

					if (answer2 == "YES") {
						singleList [finalIndex].setGuestCount (1);
						singleList [finalIndex].setName2 ("");
						singleList [finalIndex].changeBringingGuest (false);
						singleList [finalIndex].setFood2 ("");
						Console.WriteLine ("Thank you. Your guest has been removed.");
						singleGuestMenu ();
					} else if (answer2 == "NO") {
						Console.WriteLine ("Your guest information will remain the same.");
						singleGuestMenu ();
					} else {
						Console.WriteLine ("Invalid Response.");
						singleGuestMenu ();
					}
				} else if (guestAttend == "No" && attending == "Yes") {
					Console.WriteLine ("Would you like to add a guest?\nType YES or NO:");
					string answer21 = Console.ReadLine ();
					answer21 = answer21.ToUpper ();

					if (answer21 == "YES") {
						singleList [finalIndex].setGuestCount (2);
						singleList [finalIndex].changeBringingGuest (true);
						Console.WriteLine ("What is your guest's first and last name?");
						singleList [finalIndex].setName2 (Console.ReadLine ());
						Console.WriteLine ("Thank you, don't forget to choose food at the menu!");
						singleGuestMenu ();
					} else if (answer21 == "NO") {
						Console.WriteLine ("Ok. No guest has been added");
						singleGuestMenu ();
					} else {
						Console.Write ("Invalid entry.");
						singleGuestMenu ();
					}
				} 
				else {
					Console.WriteLine ("You can't edit guests if you are not attending the wedding");
					singleGuestMenu();
				}
				break;

			//Name 1
			case 3:
				Console.WriteLine ("Please enter your first and last name: ");
				singleList [finalIndex].setName1 (Console.ReadLine ());
				Console.WriteLine ("Thank you! Your name has been updated.");
				singleGuestMenu ();
				break;
			
			//Name 2
			case 4:
				if (guestAttend == "No") {
					Console.WriteLine("Please add a guest in the menu first.");
					singleGuestMenu();
				}
				else {
					Console.WriteLine ("Please enter your guest's first and last name: ");
					singleList [finalIndex].setName2 (Console.ReadLine ());
					Console.WriteLine ("Thank you! Your guest's name has been updated.");
					singleGuestMenu ();}
				break;
			
			//Food 1
			case 5: 
				if (attending == "No") {
					Console.WriteLine ("You must be attending the wedding to choose food.");
					singleGuestMenu ();
				} else {
					Console.WriteLine ("Please choose either CHICKEN or BEEF.\nType CHICKEN or BEEF");
					string answer5 = Console.ReadLine ();
					answer5 = answer5.ToUpper ();

					if (answer5 == "CHICKEN") {
						singleList [finalIndex].setFood1 (answer5);
						Console.WriteLine ("Your food choice has been updated. Thank you.");
						singleGuestMenu ();
					} else if (answer5 == "BEEF") {
						singleList [finalIndex].setFood1 (answer5);
						Console.WriteLine ("Your food choice has been updated. Thank you.");
						singleGuestMenu ();
					} else {
						Console.WriteLine ("Invalid response.");
						singleGuestMenu ();
					}
				}
				break;

			//Food 2
			case 6:
				if (guestAttend == "No") {
					Console.WriteLine ("You must add a guest first at the Menu.");
					singleGuestMenu ();
				} else {
					Console.WriteLine ("Please choose either CHICKEN or BEEF.\nType CHICKEN or BEEF");
					string answer6 = Console.ReadLine ();
					answer6 = answer6.ToUpper ();

					if (answer6 == "CHICKEN") {
						singleList [finalIndex].setFood2 (answer6);
						Console.WriteLine ("Your guest's food choice has been updated. Thank you.");
						singleGuestMenu ();
					} else if (answer6 == "BEEF") {
						singleList [finalIndex].setFood2 (answer6);
						Console.WriteLine ("Your food choice has been updated. Thank you.");
						singleGuestMenu ();
					} else {
						Console.WriteLine ("Invalid response.");
						singleGuestMenu ();
					}
				}
				break;
			
			//Home Menu
			case 7: 
				reRun ();
				break;


			//Exit
			case 8:
				Console.WriteLine ("GoodBye!");
				Environment.Exit (0);
				break;

			//Default
			default:
				Console.WriteLine ("Invalid Entry");
				singleGuestMenu ();
				break;
			}
	}	

		//Couples invitee menu:
		public static void coupleGuestMenu(){

			string attending;
			string responded;
			int choice = 0; //initialized

			Console.WriteLine("**********MENU**********\n");

			if (coupleList [finalIndex].isAttending () == true) {
				attending = "Yes";
			} else {
				attending = "No";
			}
			if (coupleList [finalIndex].getResponded () == true) {
				responded = "Yes";
			} else {
				responded = "No";
			}


			Console.WriteLine("Responded: " + responded + "\n");
			Console.WriteLine("1) Attending: " + attending);
			Console.WriteLine("2) Guest 1: " + coupleList[finalIndex].getName1());
			Console.WriteLine("3) Guest 2: " + coupleList[finalIndex].getName2());
			Console.WriteLine("4) Food 1: " + coupleList[finalIndex].getFood1());
			Console.WriteLine("5) Food 2: " + coupleList[finalIndex].getFood2());
			Console.WriteLine("6) Home Menu");
			Console.WriteLine("7) Exit");
			Console.WriteLine ("\n-If you need to make an adjustment, please type the corresponding number from the list.");

			//catches non integer input and handles exception. 
			try {
				choice = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException e) {
				Console.WriteLine ("Invalid Response.");
				coupleGuestMenu();
			}

			//switch statement allows user to choose what to update:
			switch (choice) {

			//Attending
			case 1: 
				Console.WriteLine ("Will you be attending the wedding?\nType YES or NO:");
				string answer1 = Console.ReadLine ();
				answer1 = answer1.ToUpper ();

				if (answer1 == "YES") {
					coupleList [finalIndex].setAttending (true);
					coupleList [finalIndex].setResponded (true);
					Console.WriteLine ("Great! Thank you for your response!");
					coupleList [finalIndex].setGuestCount (2);
					coupleList[finalIndex].setGuestCount (2);
					Console.WriteLine ("Don't forget to choose food if you haven't already!");
					coupleGuestMenu ();

				} else if (answer1 == "NO") {
					coupleList [finalIndex].setAttending (false);
					coupleList [finalIndex].setResponded (true);
					coupleList [finalIndex].setGuestCount (2);
					coupleList [finalIndex].setFood1 ("");
					coupleList [finalIndex].setFood2 ("");
					Console.WriteLine ("Sorry to hear you can't make it! Thank you for replying.");
					coupleGuestMenu ();
				} else {
					Console.WriteLine ("Invalid Response");
					coupleGuestMenu ();
				}
				break;

			//Name 1
			case 2:
				Console.WriteLine ("Please enter your first and last name: ");
				coupleList [finalIndex].setName1 (Console.ReadLine ());
				Console.WriteLine ("Thank you! Your name has been updated.");
				coupleGuestMenu ();
				break;

				//Name 2
			case 3:
				if (attending == "No") {
					Console.WriteLine("You must be attending the wedding to update Guest info");
					coupleGuestMenu();
				}
				else {
					Console.WriteLine ("Please enter your guest's first and last name: ");
					coupleList[finalIndex].setName2 (Console.ReadLine ());
					Console.WriteLine ("Thank you! Your guest's name has been updated.");
					coupleGuestMenu ();}
				break;

				//Food 1
			case 4: 
				if (attending == "No") {
					Console.WriteLine ("You must be attending the wedding to choose food.");
					coupleGuestMenu ();
				} 
				else {
					Console.WriteLine ("Please choose either CHICKEN or BEEF.\nType CHICKEN or BEEF");
					string answer5 = Console.ReadLine ();
					answer5 = answer5.ToUpper ();

					if (answer5 == "CHICKEN") {
						coupleList [finalIndex].setFood1 (answer5);
						Console.WriteLine ("Your food choice has been updated. Thank you.");
						coupleGuestMenu ();
					} else if (answer5 == "BEEF") {
						coupleList [finalIndex].setFood1 (answer5);
						Console.WriteLine ("Your food choice has been updated. Thank you.");
						coupleGuestMenu ();
					} else {
						Console.WriteLine ("Invalid response.");
						coupleGuestMenu ();
					}
				}
				break;

				//Food 2
			case 5:
				Console.WriteLine ("Please choose either CHICKEN or BEEF.\nType CHICKEN or BEEF");
				string answer6 = Console.ReadLine ();
				answer6 = answer6.ToUpper ();

				if (answer6 == "CHICKEN") {
					coupleList [finalIndex].setFood2 (answer6);
					Console.WriteLine ("Your guest's food choice has been updated. Thank you.");
					coupleGuestMenu ();
				} 
				else if (answer6 == "BEEF") {
					coupleList [finalIndex].setFood2 (answer6);
					Console.WriteLine ("Your food choice has been updated. Thank you.");
					coupleGuestMenu ();
					} 
				else {
					Console.WriteLine ("Invalid response.");
					coupleGuestMenu ();
					}

				break;

				//Home Menu
			case 6: 
				reRun ();
				break;


				//Exit
			case 7:
				Console.WriteLine ("GoodBye!");
				Environment.Exit (0);
				break;

				//Default
			default:
				Console.WriteLine ("Invalid Entry");
				coupleGuestMenu ();
				break;
			}
		}

		//adminPrompt() method: Login screen for administrator. Login and pass must match constants at beginning of this
		//file.
		public static void adminPrompt(){
			Console.WriteLine ("**********************\n Administrator Login\n**********************");
			Console.WriteLine ("\nEnter Login ID: ");
			string inputLogin = Console.ReadLine();
			Console.WriteLine ("Enter Password: ");
			string inputPass = Console.ReadLine();

			if (inputLogin == adminLogin && inputPass == adminPass) {
				adminMenu ();
			} 
			else {
				Console.WriteLine ("\nINVALID, Restarting...");
				reRun();

			}
		}

		//After successfully verified, administrator menu:
		public static void adminMenu() {
			Console.WriteLine ("********************\n   Welcome Brian!\n********************");
			Console.WriteLine ("\n******************** Current Guest List ********************");
			Console.WriteLine("\nTotal Attending: " + getAttendCount());
			Console.WriteLine ("Total Declined: " + listDeclined ());
			Console.WriteLine ("No Response: " + listNoRespond ());
			Console.WriteLine("Number of Chicken Dinners: " + numChick());
			Console.WriteLine("Number of Beef Dinners: " + numBeef() + "\n\n");

			Console.WriteLine ("Attending Guests:\n********************");
			for (int i = 0; i < singleList.Count; i++) {
				Console.WriteLine (listSingAttendNames (i));
			}

			for (int i2 = 0; i2 < coupleList.Count; i2++) {
				Console.WriteLine (listCoupleAttendNames (i2));
			}

			Console.WriteLine ("\nDeclined Guests:\n**********************");
			for (int i = 0; i < singleList.Count; i++) {
				Console.WriteLine (listSingDeclineNames (i));
			}

			for (int i2 = 0; i2 < coupleList.Count; i2++) {
				Console.WriteLine (listCoupleDeclineNames (i2));
			}

			Console.WriteLine ("\nNo Response:\n*********************");
			for (int i = 0; i < singleList.Count; i++) {
				Console.WriteLine (listNoRespSingNames(i));
			}

			for (int i2 = 0; i2 < coupleList.Count; i2++) {
				Console.WriteLine (listNoRespCoupleNames(i2));
			}
			Console.WriteLine("\n\n****VERSION 1.0, more admin controls to come in the future! *****");
			Console.WriteLine ("Type HOME to return to the home screen. Or type EXIT to close the program.");
			string answer = Console.ReadLine ();
			answer = answer.ToUpper ();

			if (answer == "HOME") {
				reRun ();
			} else if (answer == "EXIT") {
				Console.WriteLine ("\nGoodbye!");
				Environment.Exit (0);
			} 
			else {
				Console.WriteLine ("Invalid Response... returning to Home Menu");
				reRun ();
			}
		}

/***************************************************************
 * CALCULATION METHODS FOR ADMINSTRATOR MENU***
 * *************************************************************/

		//gets count of attending guests
		public static int getAttendCount() {
			int runningSingleTotal = 0;
			int runningCoupleTotal = 0;
			int total;

			for (int i = 0; i < singleList.Count; i++) {
				if (singleList [i].isAttending () == true) {
					runningSingleTotal += singleList [i].getGuestCount ();
				}
			}
			for (int i2 = 0; i2 < singleList.Count; i2++) {
				if (coupleList [i2].isAttending () == true) {
					runningCoupleTotal += coupleList [i2].getGuestCount ();
				}
			}
			total = runningSingleTotal + runningCoupleTotal;
			return total;
		}

		//gets count of declined guests:
		public static int listDeclined() {
			int runningSingleTotal = 0;
			int runningCoupleTotal = 0;
			int total;

			for (int i = 0; i < singleList.Count; i++) {
				if (singleList [i].isAttending () == false && singleList[i].getResponded() == true) {
					runningSingleTotal += singleList [i].getGuestCount ();
				}
			}
			for (int i2 = 0; i2 < singleList.Count; i2++) {
				if (coupleList [i2].isAttending () == false && coupleList[i2].getResponded() == true) {
					runningCoupleTotal += coupleList [i2].getGuestCount ();
				}
			}
			total = runningSingleTotal + runningCoupleTotal;
			return total;
		}

		//gets count of guests who haven't responded:
		public static int listNoRespond() {
			int runningSingleTotal = 0;
			int runningCoupleTotal = 0;
			int total;

			for (int i = 0; i < singleList.Count; i++) {
				if (singleList [i].getResponded () == false) {
					runningSingleTotal += singleList [i].getGuestCount ();
				}
			}
			for (int i2 = 0; i2 < singleList.Count; i2++) {
				if (coupleList [i2].getResponded () == false) {
					runningCoupleTotal += coupleList [i2].getGuestCount ();
				}
			}
			total = runningSingleTotal + runningCoupleTotal;
			return total;
		}

		//gets count of chicken dinners ordered:
		public static int numChick() {
			int runningSingleTotal = 0;
			int runningCoupleTotal = 0;
			int total;

			for (int i = 0; i < singleList.Count; i++) {
				if (singleList [i].getFood1 () == "Chicken" || singleList [i].getFood1 () == "CHICKEN") {
					runningSingleTotal++;
				}
				if (singleList [i].getFood2 () == "Chicken" || singleList [i].getFood2 () == "CHICKEN") {
					runningSingleTotal++;
				}
			}
			for (int i2 = 0; i2 < singleList.Count; i2++) {
					if (coupleList [i2].getFood1 () == "Chicken" || coupleList[i2].getFood1() == "CHICKEN") {
						runningSingleTotal++;
					}
					if (coupleList [i2].getFood2 () == "Chicken" || coupleList[i2].getFood2() == "CHICKEN") {
						runningCoupleTotal++;
			}
			}
			total = runningSingleTotal + runningCoupleTotal;
			return total;
	}

		//gets count of beef dinners ordered:
		public static int numBeef() {
			int runningSingleTotal = 0;
			int runningCoupleTotal = 0;
			int total;

			for (int i = 0; i < singleList.Count; i++) {
				if (singleList [i].getFood1 () == "Beef" || singleList [i].getFood1 () == "BEEF") {
					runningSingleTotal++;
				}
				if (singleList [i].getFood2 () == "Beef" || singleList [i].getFood2 () == "BEEF") {
					runningSingleTotal++;
				}
			}
			for (int i2 = 0; i2 < singleList.Count; i2++) {
				if (coupleList [i2].getFood1 () == "Beef" || coupleList[i2].getFood1() == "BEEF") {
					runningSingleTotal++;
				}
				if (coupleList [i2].getFood2 () == "Beef" || coupleList[i2].getFood2() == "BEEF") {
					runningCoupleTotal++;
				}
			}
			total = runningSingleTotal + runningCoupleTotal;
			return total;
		}

		// lists the names of attendees from the single invitation list:
		public static string listSingAttendNames(int i) {
			if (singleList [i].isAttending() == true) {
				string display = singleList [i].getName1 () + ", " + singleList [i].getName2 ();
				return display;
			} else
				return null;
		}

		//lists the names of attendees from the couples invitation list:
		public static string listCoupleAttendNames(int i) {
			if (coupleList [i].isAttending () == true) {
				string display = coupleList [i].getName1 () + ", " + coupleList [i].getName2 ();
				return display;
			} else
				return null;
		}

		//lists the names of guests who have declined from the single invitation list:
		public static string listSingDeclineNames(int i) {
			if (singleList [i].isAttending() == false && singleList[i].getResponded() == true) {
				string display = singleList [i].getName1 () + ", " + singleList [i].getName2 ();
				return display;
			} else
				return null;
		}

		// lists the names of guests who have declined from the couples invitation list:
		public static string listCoupleDeclineNames(int i) {
			if (coupleList [i].isAttending () == false && coupleList[i].getResponded() == true) {
				string display = coupleList [i].getName1 () + ", " + coupleList [i].getName2 ();
				return display;
			} else
				return null;
		}

		//lists the names of guests who haven't responded, from the single inviation list:
		public static string listNoRespSingNames(int i) {
			if (singleList[i].getResponded() == false) {
				string display = singleList [i].getName1 () + ", " + singleList [i].getName2 ();
				return display;
			} else
				return null;
		}

		//lists the names of guests of who haven't responded, from the couples invitation list:
		public static string listNoRespCoupleNames(int i) {
			if (coupleList[i].getResponded() == false) {
				string display = coupleList [i].getName1 () + ", " + coupleList [i].getName2 ();
				return display;
			} else
				return null;
		}
	}
}
