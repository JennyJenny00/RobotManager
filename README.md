# RobotManager
## Instructions
### How to run it?
1. Download and run RobotsManager using Visual Studio (or other IDE). When succeed, you will see this greeting page: `http://localhost:5000/api/robots/welcome`

2. Open Postman locally, choose `POST` method and paste this link: `http://localhost:5000/api/robots/closest` in the address box.
Then, in the "Body" tab, select "JSON" format and paste the following json:
```
{
    "loadId": 231, 
    "x": 0, 
    "y": 0 
} 
```
hit "Send" and then this response body is supposed to show up: 
```
{
    "robotId": 4,
    "distanceToGoal": 7.280109889280518,
    "batteryLevel": 37
}
```

### How do we prove the correctness?
1. Intuitively, it would be a great idea if we can see all the robots on the axis then we may have a better idea about their locations. To achieve this (in a limited time) please go to this address `http://localhost:5000/api/robots/findAll` using `GET`, on the right side of "Body", select "Tests" and copy the content in `RobotManagerTest/PostManTest` to it, press "Send", and in the response body section, select "Visualize" and voila, Postman will show up all our 100 robots!

	In this case, we can check out the target location and eyeball it for the nearest robot easier.

2. This is just so much fun to explore but we still need unit tests to enable out test-driven development and protect against future bugs, so please go check RobotsControllerTests class under RobotManagerTests folder for it.

## What's next?
1. Can we make it faster? 
The time complexity is `O(n)` and I spend some time trying to find a faster algorithm that suits our case, but since we are using Euclidean distance rather than Manhattan distance (may or may not using Binary search to reduce the time complexity depending on the problem description), this might be the best solution for now.

2. Can we use it in other circumstance?  
	If the target stays in one place, and all other 100 robots are keep moving, how could we know who is the nearest? In this case I would suggest using a Priority Queue data structure(specifically a min heap) to keep track of the nearest robot. Whenever a robot moves, we update this Priority Queue and if we want to look up for the nearest, just pop up the top of it.
3. If there is more time, I do want to improve the front end so that we can see where the target is and all robots in the same chart.