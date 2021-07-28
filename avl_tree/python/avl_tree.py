class Node:
    def __init__(self, data, parent):
        self.data = data
        self.left_node = None
        self.right_node = None
        self.parent = parent
        self.height = 0

class AVLTree:
    def __init__(self):
        self.root = None

    def remove(self, data):
        if self.root:
            self.remove_node(data, self.root)
    
    def insert(self, data):
        if self.root is None:
            self.root = Node(data, None)
        else:
            self.insert_node(data, self.root)
        
    def insert_node(self, data, node):
        if data < node.data:
            if node.left_node:
                self.insert_node(data, node.left_node)
            else:
                node.left_node = Node(data, node)
                node.height = max(self.calc_height(node.left_node), 
                    self.calc_height(node.right_node)) + 1
        else:
            if node.right_node:
                self.insert_node(data, node.right_node)
            else:
                node.right_node = Node(data, node)
                node.height = max(self.calc_height(node.left_node), 
                    self.calc_height(node.right_node)) + 1
        
        # after every insertion, check whether the avl properties are violated
        self.handle_violation(node)
    
    def remove_node(self, data, node):
        if node is None:
            return
        
        if data < node.data:
            self.remove_node(data, node.left_node)
        elif data > node.data:
            self.remove_node(data, node.right_node)
        else:
            # found node to remove
            # if node is a leaf node
            if node.left_node is None and node.right_node is None:
                print("removing a leaf node... %d" % node.data)
                parent = node.parent

                if parent is not None and parent.left_node == node:
                    parent.left_node = None
                if parent is not None and parent.right_node == node:
                    parent.right_node = None
                if parent is None:
                    self.root = None
                
                del node

                self.handle_violation(node)
            
            # if node has a single child
            elif node.left_node is None and node.right_node is not None:
                print("removing a node with a single right child...")
                parent = node.parent

                if parent is not None:
                    if parent.left_node == node:
                        parent.left_node = node.left_node
                    if parent.right_node == node:
                        parent.right_node =  node.right_node
                else:
                    self.root = node.right_node
                
                node.right_node.parent = parent
                del node

                self.handle_violation(node)

            elif node.right_node is None and node.left_node is not None:
                print("removing a node with a single left child...")
                parent = node.parent

                if parent is not None:
                    if parent.left_node == node:
                        parent.left_node = node.left_node
                    if parent.right_node == node:
                        parent.right_node =  node.right_node
                else:
                    self.root = node.left_node
                
                node.left_node.parent = parent
                del node

                self.handle_violation(parent)
            
            # if node has 2 children
            else:
                print('removing node with 2 children')

                predecessor = self.get_predecessor(node.left_node)

                temp = predecessor.data
                predecessor.data = node.data
                node.data = temp

                self.remove_node(data, predecessor)
    
    def get_predecessor(self, node):
        if node.right_node:
            return self.get_predecessor(node.right_node)
        
        return node