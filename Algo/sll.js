// Node class

class Node {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class SinglyLinkedList {
    constructor() {
        this.head = null;
    }
    isEmpty() {
        if (this.head == null) {
            return true
        } else {
            return false
        }
    }
    print() {
        if (this.isEmpty()) {
            console.log("The List Is Empty");
        } else {
            // print the values of all nodes 
            let runner = this.head;
            while (runner) {
                console.log(runner.value);
                runner = runner.next;
            }
        }
    }
    length() {
        if (this.isEmpty()) {
            return 0;
        } else {
            let count = 1;
            let runner = this.head;
            while (runner.next) {
                count++
                runner = runner.next
            }
            return count
        }
    }
    removeAtFront() {
        if (this.isEmpty()) {
            return false;
        } else {
            this.head = this.head.next;
            return this;
        }
    }
    removeAtBack() {
        if (this.isEmpty()) {
            return false;
        } else {
            // 1-  Search for the last Node in the SLL
            let runner = this.head;
            while (runner.next) {
                if (runner.next.next != null) {
                    runner = runner.next
                }
                runner.next = null
                return this
            }
        }
    }
    addToFront(value) {
        let newNode = new Node(value);
        if (this.isEmpty() == true) {
            this.head = newNode;
            return this;
        } else {
            newNode.next = this.head;
            this.head = newNode;
            return this;
        }
    }
    addToBack(value) {
        let newNode = new Node(value);
        // if the SLL is Empty add the new node to the head
        if (this.isEmpty()) {
            this.head = newNode;
        } else {
            // search for the last node
            // the last node has a next = null
            let runner = this.head;
            while (runner.next != null) {
                runner = runner.next;
            }
            // add the newNode
            runner.next = newNode;
        }
    }
    find(value) {
        if (this.isEmpty()) {
            return false
        } else {
            // Search for the node that has value equals to the introduced value from thr user
            let runner = this.head;
            while (runner) {
                if (runner.value == value) {
                    return true
                }
                runner = runner.next
            }
            return false
        }
    }
    delete(value) {
        if (this.isEmpty()) {
            return false
        } else if (this.head.value == value) {
            this.removeAtFront()
            return this
        } else {
            let runner = this.head;
            while (runner.next) {
                if (runner.next.value == value) {
                    runner.next = runner.next.next
                    return this
                }
                runner = runner.next
            }
        }
    }
    // Bonus Weekend : Reverse if completed +1 BeltExam 😁🤡
    reverse() {
        if (this.isEmpty()) {
            return false
        } else {
            const sllReversed = new SinglyLinkedList()
            let runner = this.head
            while (runner) {
                sllReversed.addToFront(runner.value)
                runner = runner.next
            }
            return sllReversed
        }
    }
}

let nodeOne = new Node(10);
let nodeTwo = new Node(-2);
let sll = new SinglyLinkedList()
let sllTwo = new SinglyLinkedList()
nodeOne.next = nodeTwo;
sll.head = nodeOne;
sll.addToBack(7);
// sll.print()
// console.log("------------------------------------");
// sll.removeAtBack2()
// sll.print()

// sll.removeAtFront()
// sll.print()
// let nodeThree = new Node(7);
// console.log("SLL Before :", sll);
// console.log("SLL Two Before :", sllTwo);
// sll.addToFront(7)
// sllTwo.addToFront(7)
// console.log("SLL After :", sll);
// console.log("SLL Two After :", sllTwo);
// // console.log(nodeOne.next);
// console.log("First SLL isEmpty ?  => ",sll.isEmpty());
// console.log("Second SLL isEmpty ?  => ",sllTwo.isEmpty());

// let x  = 1;
// while (x<6) {
//     console.log("The Value is : ", x);
//     x++
// }
// let arr = []
// arr.

// sll.print();
// sllTwo.print();

// console.log(sll.length());
// console.log(sllTwo.length());
// const arr = [1, 2, 3, 5, 8, 88, 2, 99]
// arr.includes(7) // ==> false
// arr.includes(99) // ==> true

// console.log("Searching for -2 : ",sll.find(-2))
// console.log("Searching for 9 : ",sll.find(9))
sll.print()
console.log("--------------------------");
// sll.delete(10);
sll = sll.reverse();
sll.print();