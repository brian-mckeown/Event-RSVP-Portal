/*
***EVENT RSVP PORTAL***
*Author: Brian McKeown
*August 2016
*
*Abstract Class: Invitee
*This class sets up like-qualities between the single and couple invitation classes. 
*/
using System;

namespace EventRSVPportal
{
	public abstract class Invitee
	{
		protected bool attending;
		protected int invNum;
		protected int login;
		protected bool responded;
		}
}

