using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : MonoBehaviour
{   
     struct point2D{

       public  point2D(int colc,int linc){
             col = colc;
             lin = linc;
         }  
	public int col;
	public int lin;
    }

    public struct StateS
{
	//public GameObject g;
	public float value;
	public bool isWalkable;
	public bool isBReward;
	public char direction;
};
  
	
   static StateS[,,] S = new StateS[1000, 100, 100];
    public GameObject[] grid;

	public GameObject startPoint;
	int moveCol;
	int moveLin;
    private Transform el;

	static public Vector3[] points;
    private int col =20 ;
    private int lin =20;
    private float recompensa = -0.04f;

	void setMovement(int k)
	{
		el = startPoint.GetComponent<Transform>();
        moveCol = (int)el.position.x ;
        moveLin = (int)el.position.z ;
		int iterator = 1;
		points = new Vector3[65];
		points[0] = new Vector3 (0,0,0);
		do
		{
			if(S[k,moveCol,moveLin].direction=='L'&&S[k,moveCol,moveLin].isWalkable)
			{	
				points[iterator] = new Vector3(-1,0,0);
				iterator++;
				moveCol -= 1;
			}
			if(S[k,moveCol,moveLin].direction=='R'&&S[k,moveCol,moveLin].isWalkable)
			{	
			
				points[iterator] = new Vector3(1,0,0);
				iterator++;
				moveCol += 1;
			}
			if(S[k,moveCol,moveLin].direction=='U'&&S[k,moveCol,moveLin].isWalkable)
			{
				points[iterator] = new Vector3(0,0,1);
				iterator++;
				moveLin +=1;
			}
			if(S[k,moveCol,moveLin].direction=='D'&&S[k,moveCol,moveLin].isWalkable)
			{
				points[iterator] = new Vector3(0,0,-1);
				iterator++;
				moveLin -=1;
			}

			
		} while (S[k,moveCol,moveLin].direction!='F');
		
	}


    public void initializare()
    {   
       
         for(int i = 0;i<grid.Length;i++)
        {   
            el = grid[i].GetComponent<Transform>(); 
              int x = (int)el.position.x ;
              int y = (int)el.position.z ;
            //Debug.Log("Asta e "+x.ToString()+"de ["+i+"]"+"Se numeste:"+ grid[i].name);
            //Debug.Log("Asta e "+y.ToString()+"de ["+i+"]");
			//grid[i].GetComponent<State>().value = i;
            
            //S[0,x,y].value = val;

            if(grid[i].GetComponent<State>().isWalkable == true)
            {   //S[0,x,y].value = 0;
                for (int k = 0; k < 200; k++)
                {
                S[k,x,y].isWalkable = true;
                }
            }
            else
            {
                 for (int k = 0; k < 200; k++)
                {
			
                S[k,x,y].isWalkable = false;
                }
            }

            if(grid[i].GetComponent<State>().isBValue == true)
            {
                 for (int k = 0; k < 200; k++)
                {
                S[k,x,y].isBReward = true;
				S[k,x,y].value = grid[i].GetComponent<State>().value;
                }
            }
            else
            {
                 for (int k = 0; k < 200; k++)
                {
                S[k,x,y].isBReward = false;
                }
            }

        }

    }

	 public void generateVI()
	{	
		Debug.Log("Am generat");
        initializare();
		calculateValues();
	}
	public void reset()
	{	Debug.Log(grid.Length);
		for(int i = 0 ;i<grid.Length;i++)
		{
			grid[i].GetComponent<State>().value = 0;
			Debug.Log("SET value to 0");
			 el = grid[i].GetComponent<Transform>(); 
              int x = (int)el.position.x ;
              int y = (int)el.position.z ;
			  S[0,x,y].value = 0;
			  S[1,x,y].value = 0;
			  S[2,x,y].value = 0;
		}
	}
    public void calculateValues()
    {  
       int k=0;
	   float old = 0.0f;
	   float nou = 0.0f;
	   //float immReward = 0.0f;
	   do
	   {
		   k++;
	   		//Debug.Log("Iteratia:"+k);
	   for(int i = 0 ; i<=19;i++)
	   {
		   for(int j=0;j<=19;j++)
		   {
			   if(S[k,j,i].isWalkable && !S[k,j,i].isBReward)
			   {
				   old = S[k-1,j,i].value;
				   //immReward = Mathf.Max(Mathf.Max(reward(k - 1, j, i, "up"), reward(k - 1, j, i, "down")), Mathf.Max(reward(k - 1, j, i, "left"), reward(k - 1, j, i, "right")));
				   //Debug.Log("ASTA E REWARDU imediat "+immReward.ToString()+"Pentru iteratia "+ k);
				   S[k,j,i].value = recompensa + 1*Mathf.Max(Mathf.Max(reward(k - 1, j, i, "up"), reward(k - 1, j, i, "down")), Mathf.Max(reward(k - 1, j, i, "left"), reward(k - 1, j, i, "right")));
				   nou = S[k,j,i].value;
			   }
		   }
	   }
	   }while (Mathf.Abs(nou-old)>0.0000001f);

	   computeDirections(k);
	   setMovement(k);

	   for(int i = 0 ;i<grid.Length;i++)
	   {	
		   el = el = grid[i].GetComponent<Transform>(); 
		   int x = (int)el.position.x ;
        	int y = (int)el.position.z ;

		   grid[i].GetComponent<State>().value = S[k,x,y].value;
		   grid[i].GetComponent<State>().dire = S[k,x,y].direction;
	   }
    }

       float reward(int k, int col, int lin, string direction)
{
	/*1, 1 - origin;*/

	point2D origin;
    origin.col = col;
    origin.lin = lin;

	float reward = 0.0f;

	if (direction == "up") {
		point2D up = new point2D (origin.col ,origin.lin + 1 );
		point2D right = new point2D ( origin.col +1 ,origin.lin  );
		point2D left = new point2D ( origin.col - 1 , origin.lin );

		if(up.col != -1 &&up.col != 20 &&up.lin != -1&& up.lin != 20)
		{
				if (S[k,up.col,up.lin].isWalkable == true  || S[k,up.col,up.lin].isBReward== true )
		{
			reward += 0.8f * S[k,up.col,up.lin].value;
		}
		else {
			reward += 0.8f * S[k,col,lin].value;
		}
		}
		
		
		if(right.col != -1 &&right.col != 20 &&right.lin != -1&& right.lin != 20)
		{

		if (S[k,right.col,right.lin].isWalkable == true ||S[k,right.col,right.lin].isBReward== true )
		{
			reward += 0.1f * S[k,right.col,right.lin].value;
		}
		else {
			reward += 0.1f * S[k,col,lin].value;
		}
		}

		if(left.col != -1 &&left.col != 20 &&left.lin != -1&& left.lin != 20)
		{

		if (S[k,left.col,left.lin].isWalkable == true || S[k,left.col,left.lin].isBReward == true )
		{
			reward += 0.1f * S[k,left.col,left.lin].value;
		}
		else {
			reward += 0.1f * S[k,col,lin].value;
		}
		}






		/*cout << "\nI AM AT: [" << origin.col << "," << origin.lin<<"]" << "and decided to go :" << direction << endl;
		cout << "UP: " << " "<< up.col << " " << up.lin << endl;
		cout << "RIGHT: " << " " << right.col << " " << right.lin << endl;
		cout << "LEFT: " << " " << left.col << " " << left.lin << endl;*/
	}
	/*1,2 - up
	2,1 - right
	0,1 - left (not walkable by out of bounds)*/

	//RIGHT
	if (direction == "right") {
		//point2D up{ origin.col + 1 ,origin.lin };
		//point2D right{ origin.col  ,origin.lin -1 };
		//point2D left{ origin.col  , origin.lin + 1 };

        point2D up = new point2D (origin.col + 1,origin.lin );
		point2D right = new point2D ( origin.col  ,origin.lin -1 );
		point2D left = new point2D ( origin.col  , origin.lin + 1 );

		/*cout << "\nI AM AT: [" << origin.col << "," << origin.lin << "]" << "and decided to go :"<<direction<<endl;
		cout << "UP: " << " " << up.col << " " << up.lin << endl;
		cout << "RIGHT: " << " " << right.col << " " << right.lin << endl;
		cout << "LEFT: " << " " << left.col << " " << left.lin << endl;*/

		if(up.col != -1 &&up.col != 20 &&up.lin != -1&& up.lin != 20)
		{
			if (S[k,up.col,up.lin].isWalkable == true  || S[k,up.col,up.lin].isBReward== true  )
		{
			reward += 0.8f * S[k,up.col,up.lin].value;
		}
			else {
			reward += 0.8f * S[k,col,lin].value;
		}
		}

		if(right.col != -1 &&right.col != 20 &&right.lin != -1&& right.lin != 20)
		{
			if (S[k,right.col,right.lin].isWalkable == true ||S[k,right.col,right.lin].isBReward== true)
		{
			reward += 0.1f * S[k,right.col,right.lin].value;
		}
			else {
			reward += 0.1f * S[k,col,lin].value;
		}
		}


		if(left.col != -1 &&left.col != 20 &&left.lin != -1&& left.lin != 20)
		{
			if (S[k,left.col,left.lin].isWalkable == true || S[k,left.col,left.lin].isBReward == true)
		{
			reward += 0.1f * S[k,left.col,left.lin].value;
		}
			else {
			reward += 0.1f * S[k,col,lin].value;
		}
		}
	}

	/*2,1 - up
	1,0 - right ( not walkable by out of bounds)
	1,2 - left*/

	//DOWN
	if (direction == "down") {
		// point2D up{ origin.col  ,origin.lin -1};
		// point2D right{ origin.col -1  ,origin.lin };
		// point2D left{ origin.col +1 , origin.lin  };

        point2D up = new point2D (origin.col  ,origin.lin -1 );
		point2D right = new point2D ( origin.col -1  ,origin.lin  );
		point2D left = new point2D (  origin.col +1 , origin.lin );
		/*cout << "\nI AM AT: [" << origin.col << "," << origin.lin << "]" << "and decided to go :" << direction << endl;
		cout << "UP: " << " " << up.col << " " << up.lin << endl;
		cout << "RIGHT: " << " " << right.col << " " << right.lin << endl;
		cout << "LEFT: " << " " << left.col << " " << left.lin << endl;*/

		if(up.col != -1 &&up.col != 20 &&up.lin != -1&& up.lin != 20)
		{

			if (S[k,up.col,up.lin].isWalkable == true  || S[k,up.col,up.lin].isBReward== true )
		{
			reward += 0.8f * S[k,up.col,up.lin].value;
		}
			else {
			reward += 0.8f * S[k,col,lin].value;
		}
		}


		if(right.col != -1 &&right.col != 20 &&right.lin != -1&& right.lin != 20)
		{
			if (S[k,right.col,right.lin].isWalkable == true ||S[k,right.col,right.lin].isBReward== true )
		{
			reward += 0.1f * S[k,right.col,right.lin].value;
		}
			else {
			reward += 0.1f * S[k,col,lin].value;
		}
		}

		if(left.col != -1 &&left.col != 20 &&left.lin != -1&& left.lin != 20)
		{
			if (S[k,left.col,left.lin].isWalkable == true || S[k,left.col,left.lin].isBReward == true )
		{
			reward += 0.1f * S[k,left.col,left.lin].value;
		}
			else {
			reward += 0.1f * S[k,col,lin].value;
		}
		}
	}
	/*1,0 - up(not walkable by out of bounds)
	0,1 - right(not walkable by out of bounds)
	2,1 - left*/

	//LEFT
	if (direction == "left") {
		// point2D up{ origin.col -1  ,origin.lin  };
		// point2D right{ origin.col   ,origin.lin +1};
		// point2D left{ origin.col  , origin.lin - 1};

        point2D up = new point2D (origin.col -1  ,origin.lin );
		point2D right = new point2D ( origin.col   ,origin.lin +1  );
		point2D left = new point2D (  origin.col  , origin.lin - 1 );

		/*cout << "\nI AM AT: [" << origin.col << "," << origin.lin << "]" << "and decided to go :" << direction << endl;
		cout << "UP: " << " " << up.col << " " << up.lin << endl;
		cout << "RIGHT: " << " " << right.col << " " << right.lin << endl;
		cout << "LEFT: " << " " << left.col << " " << left.lin << endl;*/

		if(up.col != -1 &&up.col != 20 &&up.lin != -1&& up.lin != 20)
		{
			if (S[k,up.col,up.lin].isWalkable == true || S[k,up.col,up.lin].isBReward== true)
		{
			reward += 0.8f * S[k,up.col,up.lin].value;
		}
			else {
			reward += 0.8f * S[k,col,lin].value;
		}
		}

		if(right.col != -1 &&right.col != 20 &&right.lin != -1&& right.lin != 20)
		{
			if (S[k,right.col,right.lin].isWalkable == true ||S[k,right.col,right.lin].isBReward== true)
		{
			reward += 0.1f * S[k,right.col,right.lin].value;
		}
			else {
			reward += 0.1f * S[k,col,lin].value;
		}
		}

		if(left.col != -1 &&left.col != 20 &&left.lin != -1&& left.lin != 20)
		{
			if (S[k,left.col,left.lin].isWalkable == true || S[k,left.col,left.lin].isBReward == true )
		{
			reward += 0.1f * S[k,left.col,left.lin].value;
		}
			else {
			reward += 0.1f * S[k,col,lin].value;
		}
		}

		
	}
	

	return reward;

}

void computeDirections(int k)
{	
	
	char direction = '0';
	double max ;

	for ( int i = 0; i < lin; i++) {
		//cout << endl;
		for ( int j = 0; j < col; j++)
		{
			 max = 0.0;
			point2D origin= new point2D( j,i );
			point2D up = new point2D ( origin.col ,origin.lin + 1 );
			point2D right= new point2D ( origin.col + 1 ,origin.lin );
			point2D left = new point2D ( origin.col - 1 , origin.lin );
			point2D down = new point2D( origin.col ,origin.lin - 1 );


			// if(up.lin !=20 && right.col !=20 && left.col != -1 && down.lin != -1)
			// {
			if(i==0) down.lin = origin.lin;
			if(j==0) left.col = origin.col;
			if(i==19) up.lin = origin.lin;
			if(j==19) right.col = origin.col; 




			if (S[k,j,i].isWalkable && !S[k,j,i].isBReward) {
				if (S[k,up.col,up.lin].isWalkable == true)
				{
					if (S[k,up.col,up.lin].value > max) {
						max = S[k,up.col,up.lin].value;
						direction = 'U';
					}
				}


				if (S[k,right.col,right.lin].isWalkable == true)
				{
					if (S[k,right.col,right.lin].value > max) {
						max = S[k,right.col,right.lin].value;
						direction = 'R';
					}
				}


				if (S[k,left.col,left.lin].isWalkable == true)
				{
					if (S[k,left.col,left.lin].value > max) {
						max = S[k,left.col,left.lin].value;
						direction = 'L';
					}
				}

				if (S[k,down.col,down.lin].isBReward == true&& S[k,down.col,down.lin].value > 0 )
				{
					if (S[k,down.col,down.lin].value > max) {
						max = S[k,down.col,down.lin].value;
						direction = 'D';
					}
				}
				if (S[k,down.col,down.lin].isWalkable == true )
				{
					if (S[k,down.col,down.lin].value > max) {
						max = S[k,down.col,down.lin].value;
						direction = 'D';
					}
				}

				S[k,j,i].direction = direction; 
				//cout << setw(10) << std::left << setfill('*') << showpos << direction;
			} 	
			
		}
	}
	S[k,0,18].direction ='F';
}

//End of class
}
