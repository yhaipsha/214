using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class Export
{

	[MenuItem("Assets/Export")]
	public static void Execute ()
	{
		//实例化SysData
		SystemData sd = ScriptableObject.CreateInstance<SystemData> ();//.CreateInstance<SystemData>();
		sd.arrInt = new List<string>();
		
		#region Normal Mode	
		//		sd.arrInt.Add("");		
		sd.arrInt.Add("2,4");
		sd.arrInt.Add("2,2,2");
		sd.arrInt.Add("2,2,2,2");
		sd.arrInt.Add("2,4,2");
		sd.arrInt.Add("2,4,2,2");
		
		sd.arrInt.Add("3,3,4");		
		sd.arrInt.Add("2,2,2,2,2,2");
		sd.arrInt.Add("2,2,2,2,4");
		sd.arrInt.Add("2,4,2,4");
		sd.arrInt.Add("2,4,2,2,2,2");		

		sd.arrInt.Add("2,4,4,2,2");//11
		sd.arrInt.Add("3,4,3,4");
		sd.arrInt.Add("2,2,2,2,2,6");
		sd.arrInt.Add("3,3,3,3,4");
		sd.arrInt.Add("4,4,4,4");
		
		sd.arrInt.Add("2,2,2,2,2,2,6");
		sd.arrInt.Add("3,3,3,3,3,3");
		sd.arrInt.Add("3,3,3,3,6");
		sd.arrInt.Add("4,4,4,6");
		sd.arrInt.Add("2,2,2,2,4,4,4");
		
		sd.arrInt.Add("3,3,3,3,4,4");//21
		sd.arrInt.Add("4,4,4,4,4");
		sd.arrInt.Add("5,5,5,5,5");
		sd.arrInt.Add("3,3,3,3,3,3,4");
		sd.arrInt.Add("3,3,4,4,4,4");
		
		sd.arrInt.Add("4,4,5,5,5");
		sd.arrInt.Add("5,5,6,6");
		sd.arrInt.Add("3,3,3,3,3,3,3,3");
		sd.arrInt.Add("3,3,3,3,4,4,4");
		sd.arrInt.Add("4,4,4,4,4,4");
		
		sd.arrInt.Add("4,5,5,5,5");		//31
		sd.arrInt.Add("3,3,3,3,3,3,3,5");		
		sd.arrInt.Add("3,3,3,3,4,5,5");		
		sd.arrInt.Add("4,4,4,4,5,5");		
		sd.arrInt.Add("5,5,5,6,5");		
		sd.arrInt.Add("6,6,7,7");		
		sd.arrInt.Add("3,3,3,3,4,4,4,4");		
		sd.arrInt.Add("4,4,4,4,4,4,4");		
		sd.arrInt.Add("4,4,5,5,5,5");		
		sd.arrInt.Add("5,5,5,6,7");		
				
		sd.arrInt.Add("5,5,6,4,4,4");		//41
		sd.arrInt.Add("3,3,3,4,4,4,5,5");		
		sd.arrInt.Add("4,4,4,4,4,4,6");		
		sd.arrInt.Add("5,5,5,5,5,5");		
		sd.arrInt.Add("6,6,6,6,6");		
		sd.arrInt.Add("7,7,8,8");		
		sd.arrInt.Add("3,3,3,3,4,4,4,4,4");		
		sd.arrInt.Add("4,4,4,4,4,4,4,4");		
		sd.arrInt.Add("4,4,4,5,5,5,5");		
		sd.arrInt.Add("5,5,5,5,6,6");	
		#endregion
		
		sd.secondInt = new List<string>();
		sd.secondInt.Add("2,4");
		sd.secondInt.Add("2,2,2");
		sd.secondInt.Add("2,2,4");
		sd.secondInt.Add("2,2,2,2");
		sd.secondInt.Add("2,4,2,2");//5
		sd.secondInt.Add("2,2,2,2,2");
		sd.secondInt.Add("2,4,4,2");
		sd.secondInt.Add("2,2,2,2,4");
		sd.secondInt.Add("2,2,2,2,2,2");
		sd.secondInt.Add("2,4,2,2,4");
		
		sd.secondInt.Add("2,4,2,2,2,2");
		sd.secondInt.Add("2,2,2,2,2,2,2");
		sd.secondInt.Add("2,2,2,2,2,6");
		sd.secondInt.Add("2,2,2,2,2,4,2");
		sd.secondInt.Add("2,2,2,2,2,2,2,2");//15
		sd.secondInt.Add("2,2,2,2,2,2,6");
		sd.secondInt.Add("2,2,2,2,2,2,4,2");
		sd.secondInt.Add("2,2,2,2,2,2,2,2,2");
		sd.secondInt.Add("2,2,2,2,2,2,4,4");
		sd.secondInt.Add("2,2,2,2,2,2,2,2,4");
		//关卡经典
		#region 关卡经典
		int[] box2_1 = {1,1,1,1,1,1};
		int[] ask2_1 = {2,4};    
		int[] box2_2 = {1,1,1,1,1,1};
		int[] ask2_2 = {2,2,2};    		
		int[] box2_3 = {1,1,1,1,1,1,1,1};
		int[] ask2_3 = {2,2,4};    
		int[] box2_4 = {1,1,1,1,1,1,1,1};
		int[] ask2_4 = {2,2,2,2};   		
		int[] box2_5 = {1,1,1,1,1,1,1,1,1,1};
		int[] ask2_5 = {2,4,2,2};    
		int[] box2_6 = {1,1,1,1,1,1,1,1,1,1};
		int[] ask2_6 = {2,2,2,2,2};    		
		int[] box2_7 = {1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask2_7 = {2,4,4,2};    
		int[] box2_8 = {1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask2_8 = {2,2,2,2,4};    
		int[] box2_9 = {1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask2_9 = {2,2,2,2,2,2};
		int[] box2_10 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask2_10 = {2,4,2,2,4};    
		int[] box2_11 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask2_11 = {2,4,2,2,2,2};    
		int[] box2_12 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask2_12 = {2,2,2,2,2,2,2};
    
		int[] box2_13 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0};
		int[] ask2_13 = {2,2,2,2,2,6};    
		int[] box2_14 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0};
		int[] ask2_14 = {2,2,2,2,2,4,2};    
		int[] box2_15 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0};
		int[] ask2_15 = {2,2,2,2,2,2,2,2};
    
		int[] box2_16 = {
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1};
		int[] ask2_16 = {2,2,2,2,2,2,6};
    
		int[] box2_17 = {
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1};
    
		int[] ask2_17 = {2,2,2,2,2,2,4,2};
    
		int[] box2_18 = {
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1};
    
		int[] ask2_18 = {2,2,2,2,2,2,2,2,2};
    
		int[] box2_19 = {
        1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,
        1,1};
    
		int[] ask2_19 = {2,2,2,2,2,2,4,4};
    
		int[] box2_20 = {
        1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,
        1,1};
		int[] ask2_20 = {2,2,2,2,2,2,2,2,4};
    		#endregion
		
		int[] box2_21 = {
        1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,
        1,1};
		int[] ask2_21 = {2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_22 = {1,1,
        1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,
        1,1};
    
		int[] ask2_22 = {2,2,2,2,2,2,2,4,4};
    
		int[] box2_23 = {1,1,
        1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,
        1,1};
		int[] ask2_23 = {2,2,2,2,2,2,2,2,2,4};
    
		int[] box2_24 = {1,1,
        1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,
        1,1};
		int[] ask2_24 = {2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_25 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_25 = {2,2,2,2,4,4,4,4};
    
		int[] box2_26 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1};
    
		int[] ask2_26 = {2,2,2,2,2,2,2,2,4,4};
    
		int[] box2_27 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1};
    
		int[] ask2_27 = {2,2,2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_28 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};

		int[] ask2_28 = {2,2,2,2,2,2,4,4,4,2};
    
		int[] box2_29 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_29 = {2,2,2,2,2,2,2,2,2,4,4};
    
		int[] box2_30 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};

		int[] ask2_30 = {2,2,2,2,2,2,2,2,2,2,2,4};
    
		int[] box2_31 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};

		int[] ask2_31 = {2,2,2,2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_32 = {1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_32 = {2,2,2,2,2,2,4,4,4,4};
    
		int[] box2_33 = {1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_33 = {2,2,2,2,2,2,2,2,2,2,4,4};
    
		int[] box2_34 = {1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_34 = {2,2,2,2,2,2,2,2,2,2,2,2,4};
    
		int[] box2_35 = {1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1};
    
		int[] ask2_35 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_36 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_36 = {2,2,2,2,2,2,2,4,4,4,4};
    
		int[] box2_37 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_37 = {2,2,2,2,2,2,2,2,4,4,4,2};
    
		int[] box2_38 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_38 = {2,2,2,2,2,2,2,2,2,4,4,2,2};
    
		int[] box2_39 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_39 = {2,2,2,2,2,2,2,2,2,2,2,2,2,4};
    
		int[] box2_40 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_40 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_41 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_41 = {4,4,4,4,4,4,4,4};
    
		int[] box2_42 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_42 = {4,4,4,4,4,4,4,2,2};
    
		int[] box2_43 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_43 = {4,4,4,4,4,4,2,2,2,2};
    
		int[] box2_44 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_44 = {4,4,4,4,4,2,2,2,2,2,2};
    
		int[] box2_45 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};

		int[] ask2_45 = {4,4,4,4,2,2,2,2,2,2,2,2};
    
		int[] box2_46 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
    
		int[] ask2_46 = {4,4,4,2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_47 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};

		int[] ask2_47 = {4,4,2,2,2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_48 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_48 = {4,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_49 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
		int[] ask2_49 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
    
		int[] box2_50 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1};
    
		int[] ask2_50 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
    
		//挑战关卡
    
		int[] box3_1 = {1,1,1,1,1,1,1};
		int[] ask3_1 = {2,2,2};
		int[] box3_2 = {1,1,1,1,1,1,1,1,2};
		int[] ask3_2 = {2,2,2,2};
		int[] box3_3 = {1,1,1,1,1,1,1,1,1,1,2};
		int[] ask3_3 = {2,2,2,2,2};
		int[] box3_4 = {1,1,1,1,1,1,1,1,1,1,1,1,3};
		int[] ask3_4 = {2,2,2,2,2,2};
		int[] box3_5 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,3};
		int[] ask3_5 = {2,2,2,2,2,2,2};
		int[] box3_6 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4};
		int[] ask3_6 = {2,2,2,2,2,2,2,2};
		int[] box3_7 = {
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,4};
		int[] ask3_7 = {2,2,2,2,2,2,2,2,2};
    
		int[] box3_8 = {
        1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,
        1,1,5};
    
		int[] ask3_8 = {2,2,2,2,2,2,2,2,2,2};
		int[] box3_9 = {1,1,
        1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,
        1,1,5};
    
		int[] ask3_9 = {2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_10 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,6};
		int[] ask3_10 = {2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_11 = {
        1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,6};
    
		int[] ask3_11 = {2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_12 = {1,1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,1,7};
		int[] ask3_12 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_13 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,7};
		int[] ask3_13 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_14 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,7};
		int[] ask3_14 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_15 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,6};
		int[] ask3_15 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_16 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,5};
		int[] ask3_16 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_17 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,4};
		int[] ask3_17 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_18 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,3};
		int[] ask3_18 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_19 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,2};
		int[] ask3_19 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		int[] box3_20 = {1,1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,
        1,1,1,1,1,1,1,1};
		int[] ask3_20 = {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
		
		
		/*
		sd.arrInt= new List<int[]>();
		//arrInt.Add(new int[]{});
		sd.arrInt.Add(new int[]{2,4});
		
		int[] box1_1 = {1,1,1,1,1,1};
		int[] ask1_1 = {2,4};    
		int[] box1_2 = {1,1,1,1,1,1};
		int[] ask1_2 = {2,2,2};
    
		int[] box1_3 = {1,1,1,1,1,1,1,1};
		int[] ask1_3 = {2,2,2,2};    
		int[] box1_4 = {1,1,1,1,1,1,1,1};
		int[] ask1_4 = {2,4,2};
    
		int[] box1_5 = {1,1,1,1,1,1,1,1,1,1};
		int[] ask1_5 = {2,4,2,2};    
		int[] box1_6 = {1,1,1,1,1,1,1,1,1,1};
		int[] ask1_6 = {3,3,4};
    
		int[] box1_7 = {1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_7 = {2,2,2,2,2,2};    
		int[] box1_8 = {1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_8 = {2,2,2,2,4};    
		int[] box1_9 = {1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_9 = {2,4,2,4};    
		
		int[] box1_10 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_10 = {2,4,2,2,2,2};    
		int[] box1_11 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_11 = {2,4,4,2,2};    
		int[] box1_12 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_12 = {3,4,3,4};
    
		int[] box1_13 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_13 = {2,2,2,2,2,6};    
		int[] box1_14 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_14 = {3,3,3,3,4};    
		int[] box1_15 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_15 = {4,4,4,4};
    
		int[] box1_16 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_16 = {2,2,2,2,2,2,6};    
		int[] box1_17 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_17 = {3,3,3,3,3,3};    
		int[] box1_18 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_18 = {3,3,3,3,6};    
		int[] box1_19 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_19 = {4,4,4,6};
    
		int[] box1_20 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_20 = {2,2,2,2,4,4,4};
    
		int[] box1_21 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_21 = {3,3,3,3,4,4};    
		int[] box1_22 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_22 = {4,4,4,4,4};    
		int[] box1_23 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_23 = {5,5,5,5,5};    
		
		int[] box1_24 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_24 = {3,3,3,3,3,3,4};    
		int[] box1_25 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_25 = {3,3,4,4,4,4};    
		int[] box1_26 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_26 = {4,4,5,5,5};    
		int[] box1_27 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_27 = {5,5,6,6};    
		
		int[] box1_28 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_28 = {3,3,3,3,3,3,3,3};    
		int[] box1_29 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_29 = {3,3,3,3,4,4,4};    
		int[] box1_30 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_30 = {4,4,4,4,4,4};    
		int[] box1_31 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_31 = {4,5,5,5,5};
    
		int[] box1_32 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_32 = {3,3,3,3,3,3,3,5};    
		int[] box1_33 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_33 = {3,3,3,3,4,5,5};    
		int[] box1_34 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_34 = {4,4,4,4,5,5};    
		int[] box1_35 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_35 = {5,5,5,6,5};    
		int[] box1_36 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_36 = {6,6,7,7};
		
		int[] box1_37 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_37 = {3,3,3,3,4,4,4,4};    
		int[] box1_38 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_38 = {4,4,4,4,4,4,4};    
		int[] box1_39 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_39 = {4,4,5,5,5,5};    
		int[] box1_40 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_40 = {5,5,5,6,7};
		
    	int[] box1_41 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_41 = {5,5,6,4,4,4};
    
		int[] box1_42 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_42 = {3,3,3,4,4,4,5,5};    
		int[] box1_43 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_43 = {4,4,4,4,4,4,6};    
		int[] box1_44 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_44 = {5,5,5,5,5,5};    
		int[] box1_45 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_45 = {6,6,6,6,6};    
		int[] box1_46 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_46 = {7,7,8,8};    
		
		int[] box1_47 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_47 = {3,3,3,3,4,4,4,4,4};    
		int[] box1_48 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_48 = {4,4,4,4,4,4,4,4};    
		int[] box1_49 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int[] ask1_49 = {4,4,4,5,5,5,5};    
		int[] box1_50 = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};    
		int[] ask1_50 = {5,5,5,5,6,6};   */
    		
		
		//随便设置一些数据给content
		sd.content = new List<Vector3> ();
		sd.content.Add (new Vector3 (1, 2, 3));
		sd.content.Add (new Vector3 (4, 5, 6));
		string p = "Assets/SystemData.asset";
		AssetDatabase.CreateAsset (sd, p);
		Object o = AssetDatabase.LoadAssetAtPath (p, typeof(SystemData));
		BuildPipeline.BuildAssetBundle (o, null, "Assets/Fruit/Data/SystemData.assetbundle");
		AssetDatabase.DeleteAsset (p);            
	}
}
