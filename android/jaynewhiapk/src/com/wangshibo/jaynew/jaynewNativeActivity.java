package com.wangshibo.jaynew;

import com.google.android.gms.games.GamesClient;
import com.google.android.gms.games.Player;
import com.google.example.games.basegameutils.GameHelper;
import com.tencent.mm.sdk.openapi.IWXAPI;
import com.tencent.mm.sdk.openapi.SendMessageToWX;
import com.tencent.mm.sdk.openapi.WXAPIFactory;
import com.tencent.mm.sdk.openapi.WXMediaMessage;
import com.tencent.mm.sdk.openapi.WXTextObject;
import com.umeng.analytics.MobclickAgent;
import com.umeng.fb.FeedbackAgent;
import com.umeng.update.UmengUpdateAgent;
import com.unity3d.player.*;
import android.app.NativeActivity;
import android.content.Intent;
import android.content.res.Configuration;
import android.graphics.Bitmap;
import android.graphics.PixelFormat;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Toast;

public class jaynewNativeActivity extends NativeActivity implements
		UpdatePointsNotifier, GameHelper.GameHelperListener {
	protected UnityPlayer mUnityPlayer; // don't change the name of this
										// variable; referenced from native code
	protected static jaynewNativeActivity single;

	private IWXAPI wxapi;

	// The game helper object. This class is mainly a wrapper around this
	// object.
	protected GameHelper mHelper;
	// We expose these constants here because we don't want users of this class
	// to have to know about GameHelper at all.
	public static final int CLIENT_GAMES = GameHelper.CLIENT_GAMES;
	public static final int CLIENT_APPSTATE = GameHelper.CLIENT_APPSTATE;
	public static final int CLIENT_PLUS = GameHelper.CLIENT_PLUS;
	public static final int CLIENT_ALL = GameHelper.CLIENT_ALL;
	// Requested clients. By default, that's just the games client.
	protected int mRequestedClients = CLIENT_GAMES;
	
	private static final int MESSAGE_LOGIN = 0;
	private static final int MESSAGE_LOGOUT = 1;
	private static final int MESSAGE_CHONGZHI = 2;
	private static final int MESSAGE_ACHIEVEMENT = 3;
	private static final int MESSAGE_LEADERBOARD = 4;
	private static final int MESSAGE_SHARE = 5;
	private static final int MESSAGE_HASCHONGZHI = 6;
	
    // request codes we use when invoking an external activity
    final int RC_RESOLVE = 5000, RC_UNUSED = 5001;
    
	private Handler mHandler = new Handler()
	{
        @Override
        public void handleMessage(Message msg) 
        {
            switch (msg.what) 
            {
                case MESSAGE_LOGIN: 
                {
                	mHelper.beginUserInitiatedSignIn();
                    break;
                }
                case MESSAGE_LOGOUT:
                {
                	mHelper.signOut();
                	break;
                }
                case MESSAGE_CHONGZHI:
                {
                	Toast.makeText(single, "杰伦偷偷告诉你:\n推荐软件安装后不必注册或试用\n即可成功领取杰伦币",Toast.LENGTH_LONG).show();
                	break;
                }
                case MESSAGE_ACHIEVEMENT:
                {
            		if (mHelper.isSignedIn()) {
                        startActivityForResult(getGamesClient().getAchievementsIntent(), RC_UNUSED);
                    } else {
                    	mHelper.showAlert(getString(R.string.achievements_not_available));
                    }
            		break;
                }
                case MESSAGE_LEADERBOARD:
                {
            		if (mHelper.isSignedIn()) {
                        startActivityForResult(getGamesClient().getAllLeaderboardsIntent(), RC_UNUSED);
                    } else {
                    	mHelper.showAlert(getString(R.string.leaderboards_not_available));
                    }
            		break;
                }
                case MESSAGE_SHARE:
                {
            		WXTextObject textObj = new WXTextObject();
            		textObj.text = "hahahahaha";

            		WXMediaMessage wxmsg = new WXMediaMessage();
            		wxmsg.mediaObject = textObj;
            		wxmsg.description = "bucuohahaha";

            		SendMessageToWX.Req req = new SendMessageToWX.Req();
            		req.transaction = String.valueOf(System.currentTimeMillis());
            		req.message = wxmsg;
            		// req.scene = (wxapi.getWXAppSupportAPI() > 0x21020001) ?
            		// SendMessageToWX.Req.WXSceneTimeline :
            		// SendMessageToWX.Req.WXSceneSession;

            		wxapi.sendReq(req);
                	break;
                }
                case MESSAGE_HASCHONGZHI:
                {
                	Toast.makeText(single, "成功领取"+msg.arg1+"杰币!",Toast.LENGTH_LONG).show();
                	break;
                }
                default:
                    break;
            }
         }
     };

	// UnityPlayer.init() should be called before attaching the view to a
	// layout.
	// UnityPlayer.quit() should be the last thing called; it will terminate the
	// process and not return.
	protected void onCreate(Bundle savedInstanceState) {
		mUnityPlayer = new UnityPlayer(this);
		single = this;

		requestWindowFeature(Window.FEATURE_NO_TITLE);

		super.onCreate(savedInstanceState);

		getWindow().takeSurface(null);
		setTheme(android.R.style.Theme_NoTitleBar_Fullscreen);
		getWindow().setFormat(PixelFormat.RGB_565);

		if (mUnityPlayer.getSettings().getBoolean("hide_status_bar", true))
			getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,
					WindowManager.LayoutParams.FLAG_FULLSCREEN);

		int glesMode = mUnityPlayer.getSettings().getInt("gles_mode", 1);
		boolean trueColor8888 = false;
		mUnityPlayer.init(glesMode, trueColor8888);

		View playerView = mUnityPlayer.getView();
		setContentView(playerView);
		playerView.requestFocus();

		AppConnect.getInstance(this);
		AppConnect.getInstance(this).initAdInfo();

		wxapi = WXAPIFactory.createWXAPI(this, "wx407d72209b276c9a", true);

		mHelper = new GameHelper(this);
		mHelper.setup(this, mRequestedClients);
		//mHelper.enableDebugLog(true, ":::::::::::::");
		
		setSignInMessages(getString(R.string.signing_in),
				getString(R.string.signing_out));
		
		FeedbackAgent agent = new FeedbackAgent(this);
	    agent.sync();
	    
	    UmengUpdateAgent.setUpdateOnlyWifi(false);
	    UmengUpdateAgent.update(this);
	}

	@Override
	protected void onStart() {
		super.onStart();
		mHelper.onStart(this);
	}

	@Override
	protected void onStop() {
		super.onStop();
		mHelper.onStop();
	}

	@Override
	protected void onActivityResult(int request, int response, Intent data) {
		super.onActivityResult(request, response, data);
		mHelper.onActivityResult(request, response, data);
	}

	@Override
	protected void onDestroy() {
		super.onDestroy();
		mUnityPlayer.quit();
		AppConnect.getInstance(this).finalize();
	}

	// onPause()/onResume() must be sent to UnityPlayer to enable pause and
	// resource recreation on resume.
	@Override
	protected void onPause() {
		super.onPause();
		mUnityPlayer.pause();
		if (isFinishing())
			mUnityPlayer.quit();
		MobclickAgent.onPause(this);

	}

	@Override
	protected void onResume() {
		super.onResume();
		AppConnect.getInstance(this).getPoints(this);
		mUnityPlayer.resume();
		MobclickAgent.onResume(this);
	}

	@Override
	public void onConfigurationChanged(Configuration newConfig) {
		super.onConfigurationChanged(newConfig);
		mUnityPlayer.configurationChanged(newConfig);
	}

	@Override
	public void onWindowFocusChanged(boolean hasFocus) {
		super.onWindowFocusChanged(hasFocus);
		mUnityPlayer.windowFocusChanged(hasFocus);
	}

	@Override
	public boolean dispatchKeyEvent(KeyEvent event) {
		if (event.getAction() == KeyEvent.ACTION_MULTIPLE)
			return mUnityPlayer.onKeyMultiple(event.getKeyCode(),
					event.getRepeatCount(), event);
		return super.dispatchKeyEvent(event);
	}

	public void getUpdatePoints(String arg0, int arg1) {
		if (arg1 != 0) {
			AppConnect.getInstance(this).spendPoints(arg1, this);
			UnityPlayer.UnitySendMessage("Main", "AddMoney", arg1 + "");
			Message msg = new Message();
			msg.what = MESSAGE_HASCHONGZHI;
			msg.arg1 = arg1;
			mHandler.sendMessage(msg);
		}
	}

	public void getUpdatePointsFailed(String arg0) {
		// TODO Auto-generated method stub
	}
	
	private void chongzhi() 
	{
		if (AppConnect.getInstance(this).getConfig("IS_WHITE_USER").equals("true"))
		{
			return;
		}
		mHandler.sendEmptyMessage(MESSAGE_CHONGZHI);
		AppConnect.getInstance(this).showOffers(this);
		// Log.e("jaynew","111111111");
	}

	private void feedback() {
		//AppConnect.getInstance(this).showFeedback();
		FeedbackAgent agent = new FeedbackAgent(this);
	    agent.startFeedbackActivity();

	}

	private void getCustomAd() {
		if (AppConnect.getInstance(this).getConfig("IS_WHITE_USER").equals("true"))
		{
			return;
		}
		AdInfo adInfo = AppConnect.getInstance(this).getAdInfo();// 每次调用将自动轮换广告
		if (adInfo != null) {
			String adId = adInfo.getAdId(); // 广告id
			String adName = adInfo.getAdName(); // 广告标题
			String adText = adInfo.getAdText(); // 广告语文字
			Bitmap adIcon = adInfo.getAdIcon(); // 广告图标(48*48像素)
			int adPoint = adInfo.getAdPoints(); // 广告积分
			String description = adInfo.getDescription(); // 应用描述
			String version = adInfo.getVersion(); // 程序版本
			String filesize = adInfo.getFilesize(); // 安装包大小
			String provider = adInfo.getProvider(); // 应用提供商
			String[] imageUrls = adInfo.getImageUrls(); // 应用截图的url数组，每个应用2张截图
			String adPackage = adInfo.getAdPackage();// 广告应用包名
			String action = adInfo.getAction(); // 用于存储“安装”或“注册”的字段

			UnityPlayer.UnitySendMessage("SayPop", "retGetCustomAd", adId + "|"
					+ adName + "|" + adText + "|" + adPoint);
			// Toast.makeText(this,
			// adId.toString()+" "+adName+" "+adText+" "+adPoint,
			// Toast.LENGTH_LONG).show();
		}
	}

	private void getCustomAdDesc(String id) {
		AppConnect.getInstance(this).clickAd(id);
	}

	private void duanxin(String name) {
		Uri uri = Uri.parse("smsto:18660518351");
		Intent it = new Intent(Intent.ACTION_SENDTO, uri);
		it.putExtra("sms_body", name + "我十分喜欢杰伦喊饿3D,我很期待王士博的正在开发中的杰伦喊饿online");
		startActivity(it);
	}

	private void appbbs() {
		mHandler.sendEmptyMessageDelayed(MESSAGE_SHARE, 0);
	}

	private void achievement() 
	{
		Log.e("jaynew", "achievement");
		mHandler.sendEmptyMessageDelayed(MESSAGE_ACHIEVEMENT, 0);
	}
	
	private void updateAchievement(String id)
	{
		if (mHelper.isSignedIn())
		{
			int aid = Integer.parseInt(id);
			String[] achievements = getResources().getStringArray(R.array.achievements);
			if (aid >= 0 && aid < achievements.length)
			{
				Log.i("Unity","unlockAchievement: "+achievements[aid]);
				getGamesClient().unlockAchievement(achievements[aid]);
			}
		}
	}
	
	private void incrementAchievement(String id)
	{
		if (mHelper.isSignedIn())
		{
			int aid = Integer.parseInt(id);
			String[] achievements = getResources().getStringArray(R.array.achievements);
			if (aid >= 0 && aid < achievements.length)
			{
				Log.i("Unity","incrementAchievement: "+achievements[aid]);
				getGamesClient().incrementAchievement(achievements[aid],1);
			}
		}
	}

	private void leaderboard() 
	{
		Log.e("jaynew", "leaderboard");
		mHandler.sendEmptyMessageDelayed(MESSAGE_LEADERBOARD, 0);
	}
	
	private void updateLeaderboard(String type,String score)
	{
		if (mHelper.isSignedIn())
		{
			if (Integer.parseInt(type) == 0)
			{
				getGamesClient().submitScore(getString(R.string.leaderboard_exp),Integer.parseInt(score));
			}
			else
			{
				getGamesClient().submitScore(getString(R.string.leaderboard_money),Integer.parseInt(score));
			}
		}
	}

	private void onSignInButtonClicked() {
		Log.e("jaynew", "beginUserInitiatedSignIn");
		mHandler.sendEmptyMessageDelayed(MESSAGE_LOGIN, 0);
	}

	private void onSignOutButtonClicked() {
		Log.e("jaynew", "signOut");
		mHandler.sendEmptyMessageDelayed(MESSAGE_LOGOUT, 0);
	}

	public void onSignInFailed() {
		Log.e("jaynew", "login failed");
		Toast.makeText(this, "尚未登录,无法查看排行榜和成就.", Toast.LENGTH_LONG).show();
		UnityPlayer.UnitySendMessage("Main", "onSignInFailed", "");
	}

	protected GamesClient getGamesClient() {
		return mHelper.getGamesClient();
	}

	public void onSignInSucceeded() {
		// Set the greeting appropriately on main menu
		Player p = getGamesClient().getCurrentPlayer();
		String displayName = "";
		if (p == null) {
			Log.w("jaynew", "mGamesClient.getCurrentPlayer() is NULL!");
			displayName = "???";
		} else {
			Log.e("jaynew", "onSignInSucceeded displayName");
			displayName = p.getDisplayName();
		}
		UnityPlayer.UnitySendMessage("Main", "onSignInSucceeded", displayName);
	}

	protected void setSignInMessages(String signingInMessage,
			String signingOutMessage) {
		mHelper.setSigningInMessage(signingInMessage);
		mHelper.setSigningOutMessage(signingOutMessage);
	}
}
