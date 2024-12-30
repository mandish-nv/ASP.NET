//Shop Interface System
#include <iostream>
#include <string>
#include <fstream>
#include<iomanip>
#include<cstdio>
#include <ctime>
#include<cstdlib>
#pragma warning(disable : 4996)

using namespace std;


class Shop {
protected:
    int price=0,item_counter=0;
    string holder, item_code, item_name, brand_name;
    fstream view_list, put_item,temp_file;

public:
    void home_page(int&);
	void item_list();
    void go_to_home_page();
};

void Shop::home_page(int& opt1) {
    cout << "------------------------SHOP INTERFACE SYSTEM-------------------------" << endl;
    cout << "1. Admin" << endl;
    cout << "2. Customer" << endl;
    cout << "3. Exit" << endl << endl;
    cout << "Choose an option: ";
    cin >> opt1;

    system("CLS");
}

void Shop::go_to_home_page() {
    cout << "\nPress ENTER to go to home page";
    holder = getc(stdin);
    holder = getc(stdin);
    system("CLS");
}

void Shop:: item_list() {
        view_list.open("Items.txt", ios::in);
        cout << left << setw(15) << "ITEM_CODE" << setw(15) << "ITEM_NAME" << setw(20) << "BRAND_NAME" << setw(5) << right << "PRICE" << endl<<endl;
        if (view_list.is_open()) {
            while (!view_list.eof()) {         
                view_list >> item_code >> item_name >> brand_name >> price;
                cout << left << setw(15) << item_code << setw(15) << item_name << setw(20) << brand_name << setw(2) << right <<"Rs."<< price << endl;
            }
            view_list.close();
        }
        else {
            cout << "FILE NOT FOUND" << endl;
        }
}



class Admin :public Shop {
private:
    string ynopt,input_pwd,current_pwd,new_pwd;
    fstream pwd,bill_view;
public:
    void go_to_admin_page();
    bool password();
    void admin_option(int&);
    void add_item();
    void remove_item();
    void view_bills();
    void change_password();
};

void Admin::go_to_admin_page() {
    cout << "\nPress ENTER to go to admin page";
    holder = getc(stdin);
    holder = getc(stdin);
    system("CLS");
}

bool Admin::password() {
    system("CLS");
    pwd.open("Password.bin", ios::in);
    getline(pwd, current_pwd);
    pwd.close();
    cout << "Password: ";
    cin >> input_pwd;
    if (input_pwd == current_pwd) {
        return 1;
    }
    else {
        return 0;
    }
}

void Admin::admin_option(int& opt2) {
    system("CLS");
    cout << "-------------------------SHOP INTERFACE SYSTEM-------------------------" << endl;
    cout << "1. View Item List" << endl;
    cout << "2. Add Items" << endl;
    cout << "3. Remove Items" << endl;
    cout << "4. View Bills" << endl;
    cout << "5. Change admin password" << endl;
    cout << "6. Go to home screen" << endl << endl;
    cout << "Choose an option: ";
    cin >> opt2;

    system("CLS");
}

void Admin:: add_item() {
    put_item.open("Items.txt", ios::out | ios_base::app);
    Again:
    if (put_item.is_open()) {
        cout << "Enter Item code: ";
        cin >> item_code;
        cout << "Enter Item name: ";
        cin >> item_name;
        cout << "Enter Brand name: ";
        cin >> brand_name;
        cout << "Enter Price of item: ";
        cin >> price;

        put_item << "\n"<<item_code << " " << item_name << " " << brand_name << " " << price;
        cout << "Do you want to add more? (y/n) ";
        cin >> ynopt;
        if (ynopt == "y") {
            goto Again;
        }
        put_item.close();
    }
    else {
        cout << "FILE NOT FOUND" << endl;
    }
}

void Admin::remove_item()  {
    string option;
    view_list.open("Items.txt", ios::in);
    temp_file.open("temp.txt", ios::out);
    cout << "Enter code number of item to remove: ";
    cin >> option;
    if (view_list.is_open()) {
        while (!view_list.eof()) {
            view_list >> item_code >> item_name >> brand_name >> price;
            if (item_code != option) {
                temp_file << "\n"<<item_code << " " << item_name << " " << brand_name << " " << price;
            }
            else if (item_code == option) {
                continue;
            }
        }
        view_list.close();
        temp_file.close();
        remove("Items.txt");
        rename("temp.txt", "Items.txt");
    }
    else {
        cout << "FILE NOT FOUND" << endl;
    }
}

void Admin::view_bills() {
    int bill_no,sn,quant;
    string day,month,date,time,year;
    double total, dperc, dtotal;
    bill_view.open("Bill.txt", ios::in);
    cout << "------------------------BILL-------------------------\n" << endl;
    if (bill_view.is_open()) {
        while (!bill_view.eof()) {
            bill_view >> item_counter >> bill_no>>day>>month>>date>>time>>year;
            cout << "Bill no.:  " << bill_no << endl;
            cout << "Date and Time:  " << day <<" " << month<<" " << date <<" " << time <<" " << year << endl;
            cout << "\n\n";
            cout << left << setw(8) << "S.No." << setw(15) << "ITEM_NAME" << setw(15) << "QUANTITY" << setw(5) << right << "PRICE" << endl << endl;
            while (item_counter != 0) {
                bill_view >> sn >> item_name >> quant >> price;
                cout << left << setw(8) << sn << setw(15) << item_name << setw(15) << quant << setw(2) << "Rs." << price << endl;
                item_counter--;
            }
            bill_view >> total >> dperc >> dtotal;
            cout << "\nTotal:  " << "Rs." << total << endl;
            cout << "Discount:  " << dperc << "%" << endl;
            cout << "Total with discount:  " << "Rs." << dtotal << endl;
            cout << "\n-----------------------------------------------------\n\n" << endl;
        }
        bill_view.close();
    }
    else {
        cout << "FILE NOT FOUND" << endl;
    }

}

void Admin::change_password() {
    pwd.open("Password.bin", ios::in);
    getline(pwd, current_pwd);
    pwd.close();
    cout << "Enter previous password: ";
    cin >> input_pwd;
    if (input_pwd != current_pwd) {
        cout << "INCORRECT PASSWORD";
    }
    else {
        pwd.open("Password.bin", ios::out);
        cout << "Enter new password: ";
        cin >> new_pwd;
        pwd << new_pwd;
        cout << "Password changed successfully";
        pwd.close();
    }
}



class Customer :public Shop {
private:
    int quant[20];
    string buy[20];
    string dcode;
    int i = 0;
    double total=0,dtotal=0, discount=0;
    fstream store_bill;
public:
    void buy_item();
    void discount_code();
    void calculate();
    void bill();
};

void Customer::buy_item() {
    bool check=0;
    view_list.open("Items.txt", ios::in);
    cout << "\nWhat do you want to buy? (Enter item code):  ";
    while (buy[i] != "DONE") {
        bool check = 0;
        cin >> buy[i];
        if (buy[i] == "0")
            break;
        item_counter++;
        while (!view_list.eof()) {
            view_list>> item_code >> item_name >> brand_name >> price;
            if (item_code == buy[i]) {
                check = 1;
                break;
            }
        }
        if (!check) {
            item_counter--;
        }
        cout << "Enter quantity:  ";
        cin >> quant[i];
        i++;
        cout << "\nAnother item:  " ;
    }
    view_list.close();
}

void Customer::discount_code() {
    cout << "\nEnter discount code: ";
    cin >> dcode;
    if (dcode == "Hello1" || dcode == "Hello2" || dcode == "Hello3") {
        discount = 0.05;
        cout << "You received a 5% discount!!"<<endl;
    }
    else {
        cout << "INVALID CODE" << endl;
    }
}

void Customer :: calculate() {
    view_list.open("Items.txt", ios::in);
    if (view_list.is_open()) {
        while (!view_list.fail()) {
            view_list >> item_code >> item_name >> brand_name >> price ;
            for (i = 0; i < 20; i++) {
                if (buy[i] == item_code) {
                    total = total + (price * quant[i]);
                    break;
                }
            }
        }
        view_list.close();
    }
    else {
        cout << "FILE NOT FOUND" << endl;
    }
    dtotal = total - discount * total;
}

void Customer::bill() {
    store_bill.open("Bill.txt", ios::out | ios::app);
    time_t now = time(0);
    char* dt = ctime(&now);
    srand(time(0));
    int bill_no = rand();
    int i = 0,sn;

    cout << "------------------------BILL-------------------------" << endl;
    cout << "\nBill no.:  " << bill_no <<endl;
    cout << "Date and Time:  " <<dt << endl;
    store_bill << "\n\n\n" << item_counter<<"\n"<<bill_no << "\n" << dt << "\n";
    cout << "\n";
    cout << left << setw(8) << "S.No." << setw(15) << "ITEM_NAME" << setw(15) << "QUANTITY" << setw(5) << right << "PRICE" << endl << endl;
    
    while (buy[i] != "0") {
        view_list.open("Items.txt", ios::in);
        sn = i + 1;
        cout <<left<<setw(8)<< sn ;
            while (!view_list.eof()) {
                view_list >> item_code >> item_name >> brand_name >> price;
                if (buy[i] == item_code) {
                    cout << setw(15) << item_name << setw(15) << quant[i] << setw(2) << "Rs."<<price<<endl;
                    store_bill << sn << " " << item_name << " " << quant[i] << " " << price << "\n";
                    break;
                }
            }
            i++;
            view_list.close();
    }
    cout << "\n\nTotal:  " <<"Rs." <<total<< endl;
    double dperc = discount * 100;
    cout << "Discount:  " << dperc << "%" << endl;
    cout << "Total with discount:  " << "Rs." << dtotal << endl;

    store_bill << total << "\n" << dperc << "\n" << dtotal ;
    store_bill.close();
    
}



int main() {
    Shop shop;
    Admin admin;
    Customer customer;
    int option1,option2;
    string holder;

    Home:
    shop.home_page(option1);
    
    switch (option1) {
    //ADMIN
    case 1: {
        //admin password
        if (!admin.password()) {
            cout << "INCORRECT PASSWORD"<<endl;
            shop.go_to_home_page();
            goto Home;
        }
        else {
        Admin:
            //admin page
            admin.admin_option(option2);
            switch (option2) {
            //view list
            case 1: {
                admin.item_list();
                admin.go_to_admin_page();
                goto Admin;
                break;
            }
            //add items
            case 2: {
                admin.add_item();
                admin.go_to_admin_page();
                goto Admin;
                break;
            }
            //remove items
            case 3: {
                admin.item_list();
                cout << "\n\n\n";
                admin.remove_item();
                admin.go_to_admin_page();
                goto Admin;
                break;
            }
            //view bills
            case 4: {
                admin.view_bills();
                admin.go_to_admin_page();
                goto Admin;
                break;
            }
            //change password
            case 5: {
                admin.change_password();
                shop.go_to_home_page();
                goto Home;
                break;
            }
            //go to home page
            case 6: {
                goto Home;
                break;
            }
            }
        }
            break;
        
    }

    //CUSTOMER
    case 2: {
        customer.item_list();
        cout << "\nEnter 0 if you are done shopping.\n" << endl;
        customer.buy_item();
        customer.discount_code();
        customer.calculate();
        system("CLS");
        customer.bill();
        break;
    }
    //exit
    case 3: {
        return 0;
    }

    default: {
        cout << "<<<<<<<<<<<<< INVALID OPTION >>>>>>>>>>>>" << endl;
        goto Home;
    }
    
    }

    cout << "\nTHANK YOU FOR SHOPPING!!! :)\n";
	return 0;
}