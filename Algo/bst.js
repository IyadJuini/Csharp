// Binary Search Tree

class Node {
    constructor(value) {
        this.value = value;
        this.left = null;
        this.right = null
    }
}

class BinarySearchTree {
    constructor() {
        this.root = null
    }
    isEmpty() {
        return this.root == null;
    }
    min() {
        if(this.isEmpty()) {
            return false
        }else {
            let runner =  this.root;
            let minValue = this.root.value;
            while(runner.left) {
                minValue = runner.left.value;
                runner = runner.left;
            }
            return minValue;
        }
    }
    max() {
        if(this.isEmpty()) {
            return false
        }else {
            let runner =  this.root;
            let maxValue = this.root.value;
            while(runner.right) {
                maxValue = runner.right.value;
                runner = runner.right;
            }
            return maxValue;
        } 
    }
}

let nodeOne = new Node(10);
let nodeTwo = new Node(-2);
let nodeThree = new Node(7);
let nodeFour = new Node(20);
nodeOne.left = nodeTwo;
nodeTwo.right = nodeThree;
nodeOne.right = nodeFour;
let nodeFive = new Node(-5);
nodeTwo.left = nodeFive;
const bst = new BinarySearchTree()
bst.root = nodeOne;
console.log(bst);
console.log("Min Value : ", bst.min());
console.log("Max Value : ",bst.max());