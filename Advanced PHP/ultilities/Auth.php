<?php 

    class Auth {
        public static function loggedIn() { 
            //return a boolean value
            if($_SESSION['logged_in']) {
                return true;
            } else { 
                return false;
            }
        }
    }

?>