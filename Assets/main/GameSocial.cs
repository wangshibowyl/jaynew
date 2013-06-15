using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;

public class GameSocial
{
#region Singleton variables and functions
	private static GameSocial instance;
	
	public static GameSocial Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameSocial();
				//instance.Initialize();
			}
			return instance;
		}
	}
#endregion
	
	private IAchievement[] achievements;
	
	public GameSocial (){}
	
	public void Initialize()
	{
		//if(!IsUserAuthenticated())
		//{
			Social.localUser.Authenticate (success=>
			{
				if(success)
				{
					string userInfo = "Authentication successful Username: " + Social.localUser.userName + 
			            " User ID: " + Social.localUser.id + 
			            " IsUnderage: " + Social.localUser.underage;
			        Debug.Log (userInfo);
					MainUI.getSingleton().SetTitle(Social.localUser.userName);
		
		            LoadAchievements();
					GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);	
				}
				else
				{
					Debug.Log ("Failed to authenticate");
				}
			});
		//}
	}	
	public bool IsUserAuthenticated()
	{
		if(Social.localUser.authenticated)
		{
			return true;
		}
		else
		{
			//Debug.Log("User not Authenticated");
			Initialize();
			return false;
		}
	}	
	public void ShowAchievementUI()
	{
		if(IsUserAuthenticated())
		{
			Social.ShowAchievementsUI();
		}
	}
	public void ShowLeaderboardUI(string leaderboardID)
	{
		if(IsUserAuthenticated())
		{
			GameCenterPlatform.ShowLeaderboardUI(leaderboardID,TimeScope.AllTime);
			//Social.ShowLeaderboardUI();
		}
	}	
	public bool AddAchievementProgress(string achievementID, float percentageToAdd)
	{
		IAchievement a = GetAchievement(achievementID);
		if(a != null)
		{
			return ReportAchievementProgress(achievementID, ((float)a.percentCompleted + percentageToAdd));
		}
		else
		{
			return ReportAchievementProgress(achievementID, percentageToAdd);
		}
	}	
	public bool ReportAchievementProgress(string achievementID, float progressCompleted)
	{
		if(Social.localUser.authenticated)
		{
			if(!IsAchievementComplete(achievementID))
			{
				bool success = false;
				Social.ReportProgress(achievementID, progressCompleted, result => 
				{
		    		if (result)
					{
						success = true;
						LoadAchievements();
		        		Debug.Log ("Successfully reported progress");
					}
		    		else
					{
						success = false;
		        		Debug.Log ("Failed to report progress");
					}
				});
				
				return success;
			}
			else
			{
				return true;	
			}
		}
		else
		{
			Debug.Log("ERROR: GameCenter user not authenticated");
			return false;
		}
	}
	public void ResetAchievements()
	{
		GameCenterPlatform.ResetAllAchievements(ResetAchievementsHandler);	
	}
	
	void LoadAchievements()
	{
		Social.LoadAchievements (achievements=>
		{
			//Clear the list
			if(this.achievements != null)
			{
				this.achievements = null;	
			}
			
	        if (achievements.Length == 0)
			{
	            Debug.Log ("Error: no achievements found");
			}
	        else
			{
	            Debug.Log ("Got " + achievements.Length + " achievements");
				this.achievements = achievements;
			}
		});
	}
	
	bool IsAchievementComplete(string achievementID)
	{
		if(achievements != null)
		{
			foreach(IAchievement a in achievements)
			{
				if(a.id == achievementID && a.completed)
				{
					return true;	
				}
			}
		}
		
		return false;
	}
	IAchievement GetAchievement(string achievementID)
	{
		if(achievements != null)
		{
			foreach(IAchievement a in achievements)
			{
				if(a.id == achievementID)
				{
					return a;	
				}
			}
		}
		return null;
	}
	void ResetAchievementsHandler(bool status)
	{
		if(status)
		{
			//Clear the list
			if(this.achievements != null)
			{
				this.achievements = null;	
			}
			
			LoadAchievements();
			
			Debug.Log("Achievements successfully resetted!");
		}
		else
		{
			Debug.Log("Achievements reset failure!");
		}
	}
}
