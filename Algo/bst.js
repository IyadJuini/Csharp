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
        if (this.isEmpty()) {
            return false
        } else {
            let runner = this.root;
            let minValue = this.root.value;
            while (runner.left) {
                minValue = runner.left.value;
                runner = runner.left;
            }
            return minValue;
        }
    }
    max() {
        if (this.isEmpty()) {
            return false
        } else {
            let runner = this.root;
            let maxValue = this.root.value;
            while (runner.right) {
                maxValue = runner.right.value;
                runner = runner.right;
            }
            return maxValue;
        }
    }
    insert(value) {
        let newNode = new Node(value);
        if (this.isEmpty()) {
            this.root = newNode;
            return this
        } else {
            let runner = this.root;
            while (runner) {
                // if(2) if(nodeOne) => true
                // if(null) if("") => false
                if (runner.value > value) {
                    if (runner.left) {
                        runner = runner.left
                    } else {
                        runner.left = newNode
                        return this
                    }
                } else {
                    if (runner.right) {
                        runner = runner.right;
                    } else {
                        runner.right = newNode;
                        return this
                    }
                }
            }
        }
    }
}

// let nodeOne = new Node(10);
// let nodeTwo = new Node(-2);
// let nodeThree = new Node(7);
// let nodeFour = new Node(20);
// nodeOne.left = nodeTwo;
// nodeTwo.right = nodeThree;
// nodeOne.right = nodeFour;
// let nodeFive = new Node(-5);
// nodeTwo.left = nodeFive;
const bst = new BinarySearchTree()
console.log("1 - ", bst);
bst.insert(10);
console.log("2 - ", bst);
bst.insert(-2)
console.log("3 - ", bst);
bst.insert(7)
console.log("4 - ", bst);
bst.insert(20)
console.log("5 - ", bst);
bst.insert(21).insert(5).insert(-10)
console.log("6 - ", bst);

//  bst.root = nodeOne;
//  console.log(bst);
//  console.log("Min Value : ", bst.min());
//  console.log("Max Value : ",bst.max());