using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace HelperFunctions {
	
	public class Math : MonoBehaviour{
		
		public static float RoundToTenths(float input){
			input *= 10f;
			float output = Mathf.Round(input);
			return output / 10f;
		}
	}
	
	public class Timing : MonoBehaviour{
		
		private static int MINUTE = 60;
		private static int HOUR = 3600;
		private static int DAY = HOUR * 24;
		private static int WEEK = DAY * 7;
		
		public static string ConvertToMS(float rawSeconds){
			float remainingSeconds = rawSeconds;
			int minutes = (int) remainingSeconds / MINUTE;
			
			return minutes + ":" + (int) remainingSeconds;
		}
		
		public static string ConvertToHM(float rawSeconds){
			float remainingSeconds = rawSeconds;
			
			int days = GetDays(remainingSeconds);
			if(days > 0){
				remainingSeconds %= days;
			}
			
			int hours = (int) remainingSeconds /  HOUR;
			remainingSeconds %= HOUR;
			int minutes = (int) remainingSeconds / MINUTE;
			remainingSeconds %= MINUTE;
			
			string strHrs = hours.ToString();;
			string strMins = minutes.ToString();;
			
			if(hours < 10){
				strHrs = "0" + hours.ToString();
			}
			
			if(minutes < 10){
				strMins = "0" + minutes.ToString();
			} 
			
			return strHrs + ":" + strMins;
		}
		
		public static string ConvertToHMS(float rawSeconds){
			float remainingSeconds = rawSeconds;
			
			int days = GetDays(remainingSeconds);
			if(days > 0){
				remainingSeconds %= days;
			}
			
			int hours = (int) remainingSeconds /  HOUR;
			remainingSeconds %= HOUR;
			int minutes = (int) remainingSeconds / MINUTE;
			remainingSeconds %= MINUTE;
			
			return hours + ":" + minutes + ":" + (int) remainingSeconds;
		}
		
		public static int GetDays(float rawSeconds){
			float remainingSeconds = rawSeconds;
			int days = (int) remainingSeconds /  DAY;
			
			return days;
		}
		
		public static string GetProductionTime(float rawSeconds){
			string productionTime = ParseProductionTime(rawSeconds);
			
			string verticalizedText = "";
			
			for(int i = 0; i < productionTime.Length; i++){
					verticalizedText += productionTime[i] + "\n";
			}
			
			Debug.Log(verticalizedText);
			
			return verticalizedText;
		}
		
		public static string ParseProductionTime(float rawSeconds){
			int timeLeft = (int) rawSeconds;
			
			string strTime;
			
			if(timeLeft > WEEK){
				int weeks = timeLeft / WEEK;
				timeLeft %= WEEK;
				
				strTime = string.Format("{0}W", weeks);
				
				return strTime;
			}
			
			if(timeLeft > DAY){
				int days = timeLeft / DAY;
				timeLeft %= DAY;
		
				strTime = string.Format("{0}D", days);
				
				return strTime;
			}
			
			if(timeLeft > HOUR){
				int hours = timeLeft / HOUR;
				timeLeft %= HOUR;
		
				strTime = string.Format("{0}H", hours);
				
				return strTime;
			}
			
			if(timeLeft > MINUTE){
				int minutes = timeLeft / MINUTE;
				timeLeft %= MINUTE;
				
				
				return string.Format("{0}M", minutes);
			}
			
			// Debug.Log(timeLeft);
			
			strTime = string.Format("{0}S", timeLeft);
			
			return strTime;
		}
		
		// Get days, hours, minutes from raw seconds in game time
		// public string ConvertToDHM(float rawSeconds){
			// float remainingSeconds = rawSeconds;
			// int hours = (int) remainingSeconds /  HOUR;
			// remainingSeconds %= HOUR;
			// int minutes = (int) remainingSeconds / MINUTE;
			// remainingSeconds %= MINUTE;
			
			// return hours + ":" + minutes + ":" + (int) remainingSeconds;
		// }
		
		// Get days, hours, minutes, seconds from raw seconds in game time
		// public string ConvertToDHMS(float rawSeconds){
			// float remainingSeconds = rawSeconds;
			// int days = (int) remainingSeconds / DAY;
			// remainingSeconds %= DAY;
			// int hours = (int) remainingSeconds /  HOUR;
			// remainingSeconds %= HOUR;
			// int minutes = (int) remainingSeconds / MINUTE;
			// remainingSeconds %= MINUTE;
			
			// return days + hours + ":" + minutes + ":" + (int) remainingSeconds;
		// }
	}
	
	public class MoneyParsing : MonoBehaviour{
		private static int MILLION = 1000000; // 1,000,000
		private static int BILLION = 1000000000; // 1,000,000,000
		
		public static string ParseMoney(float money){
			float moneyLeft = money;
			string strMoney = moneyLeft.ToString("#,#.00");
			
			if(moneyLeft >= BILLION){
				int billions = (int)((int)moneyLeft / BILLION);
				int millions = 0;
				moneyLeft %= BILLION;
				
				if(moneyLeft >= MILLION){
					millions = (int)((int)moneyLeft / MILLION);
					moneyLeft %= MILLION;
					strMoney = string.Format("{0}.{1} B", billions, millions.ToString()[0]);
					return "$" + strMoney;
				} 
				strMoney = string.Format("{0} B", billions);
				return "$" + strMoney;
			} 
		
			if(moneyLeft >= MILLION){
				int millions = (int) ((int)moneyLeft / MILLION);
				
				moneyLeft %= MILLION;
				strMoney = string.Format("{0}.{1} M", millions, moneyLeft.ToString()[0]);
				return "$" + strMoney;
			} 
			
			return "$" + strMoney;
		}
		
		public static string ParseMoneyWithoutDecimals(float money){
			float moneyLeft = money;
			string strMoney = moneyLeft.ToString();
			
			if(moneyLeft >= BILLION){
				int billions = (int)((int)moneyLeft / BILLION);
				int millions = 0;
				moneyLeft %= BILLION;
				
				if(moneyLeft >= MILLION){
					millions = (int)((int)moneyLeft / MILLION);
					moneyLeft %= MILLION;
					strMoney = string.Format("{0}.{1} B", billions, millions.ToString()[0]);
					return "$" + strMoney;
				} 
				strMoney = string.Format("{0} B", billions);
				return "$" + strMoney;
			} 
		
			if(moneyLeft >= MILLION){
				int millions = (int) ((int)moneyLeft / MILLION);
				
				moneyLeft %= MILLION;
				strMoney = string.Format("{0}.{1} M", millions, moneyLeft.ToString()[0]);
				return "$" + strMoney;
			} 
			
			if(moneyLeft > 99999){
				return "$" + strMoney[0] + strMoney[1] + strMoney[2] + "," + strMoney[3] + strMoney[4] + strMoney[5];
			} else if(moneyLeft > 9999){
				return "$" + strMoney[0] + strMoney[1] + "," + strMoney[2] + strMoney[3] + strMoney[4];
			} else if(moneyLeft > 999){
				return "$" + strMoney[0] + "," + strMoney[1] + strMoney[2] + strMoney[3];
			} 
			
			return "$" + strMoney;
		}
	}
}
