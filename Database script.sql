CREATE DATABASE restaurant_db;
USE restaurant_db;


-- Create Cities table
CREATE TABLE City (
    CityId INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL
);

-- Create Restaurants table
CREATE TABLE Restaurant (
    RestaurantId INT PRIMARY KEY IDENTITY(1,1), 
	Name VARCHAR(50) NOT NULL,
    Address VARCHAR(100) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    CityId INT NOT NULL,
    FOREIGN KEY (CityId) REFERENCES City(CityId) ON DELETE CASCADE
);


-- Create MenuItems table
CREATE TABLE MenuItems (
    MenuItemId INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    RestaurantId INT NOT NULL,
    Image VARCHAR(200),
    FOREIGN KEY (RestaurantId) REFERENCES Restaurant(RestaurantId) ON DELETE CASCADE
);


-- Create Orders table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME NOT NULL,
    CustomerName VARCHAR(50) NOT NULL,
    CustomerPhone VARCHAR(20) NOT NULL,
    CustomerEmail VARCHAR(100) NOT NULL,
    CustomerAddress VARCHAR(100) NOT NULL,
    RestaurantId INT NOT NULL,
    FOREIGN KEY (RestaurantId) REFERENCES Restaurant(RestaurantId) ON DELETE CASCADE
);


-- Create OrderItems table
CREATE TABLE OrderItems (
    OrderId INT NOT NULL,
    MenuItemId INT NOT NULL,
    Quantity INT NOT NULL,
    PRIMARY KEY (OrderId, MenuItemId),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
    FOREIGN KEY (MenuItemId) REFERENCES MenuItems(MenuItemId) 
);

INSERT INTO City (Name) VALUES ('Cairo');
INSERT INTO City (Name) VALUES ('Alexandria');
INSERT INTO City (Name) VALUES ('Giza');
INSERT INTO City (Name) VALUES ('Sharm El-Sheikh');
INSERT INTO City (Name) VALUES ('Luxor');
 

INSERT INTO Restaurant (Name, Address, Phone, CityId) VALUES ('Abou Shakra', '35 El Hegaz St., Heliopolis', '02 24188381', 1);
INSERT INTO Restaurant (Name, Address, Phone, CityId) VALUES ('Koshary El-Tahrir', '15 Talaat Harb St., Downtown', '02 23936267', 1);
INSERT INTO Restaurant(Name, Address, Phone, CityId) VALUES ('Fish Market', 'Marina, San Stefano', '03 5460004', 2);
INSERT INTO Restaurant(Name, Address, Phone, CityId) VALUES ('Andrea', '26 July St., Giza', '02 33027987', 3);
INSERT INTO Restaurant (Name, Address, Phone, CityId) VALUES ('Fares Seafood', 'El-Salam Rd., Sharm El-Sheikh', '069 3661090', 4);
INSERT INTO Restaurant (Name, Address, Phone, CityId) VALUES ('Sunflower', 'Dahab Island, Luxor', '0102 3037370', 5);

INSERT INTO MenuItems (Name,  Price, RestaurantId, Image)
VALUES
  -- Restaurant 1
  ('Koshari', 20, 1, 'Koshari.jpg'),
  ('Ful Medames', 15, 1, 'Ful-medames.jpg'),
  ('Hawawshi', 25, 1, 'Hawawshi.jpg'),

  -- Restaurant 2
  ('Molokhia', 30, 2, 'Molokhia.jpg'),
  ('Kebda Eskandarani', 35, 2, 'Kebda-eskandarani.jpg'),
  ('Mahshi', 40, 2, 'Mahshi.jpg'),

  -- Restaurant 3
  ('Fatta', 50, 3, 'Fatta.jpg'),
  ('Roz Bel Laban', 25, 3, 'Roz-bel-laban.jpg'),
  ('Bamya', 30, 3, 'Bamya.jpg'),

  -- Restaurant 4
  ('Taameya', 10, 4, 'Taameya.jpg'),
  ('Kofta', 35, 4, 'Kofta.jpg'),
  ('Shawarma', 30, 4, 'Shawarma.jpg'),

  -- Restaurant 5
  ('Mansaf', 60, 5, 'Mansaf.jpg'),
  ('Falafel', 20, 5, 'Falafel.jpg'),
  ('Fattoush', 15, 5, 'Fattoush.jpg')

 
 INSERT INTO Restaurant (Name, Address, Phone, CityId) VALUES
('Koshari El-Tahrir', 'Tahrir Square, Downtown, Cairo', '02-23921147', 1),
('Zooba', '26th of July St., Zamalek, Cairo', '02-27353295', 1),
('Felfela', '15 Hoda Shaarawy St., Bab El-Louk, Cairo', '02-23933727', 1),
('Abou Tarek', '16 Champollion St., Downtown, Cairo', '02-23936249', 1),
('Mandarine Koueider', '8 El-Gezira St., Zamalek, Cairo', '02-27351176', 1),
('Abou Ashraf', '32 Safiya Zaghloul St., Roushdy, Alexandria', '03-4872844', 2),
('Fish Market', 'Sheraton Road, Hurghada, Red Sea', '065-3440153', 2),
('Kababgy El-Tahrir', '25 El-Mahrousa St., Raml Station, Alexandria', '03-4875307', 2),
('Maison Thomas', '11 El-Ghorfa El-Togaria St., Kafr Abdou, Alexandria', '03-5460878', 2),
('Mori Sushi', 'Sheikh Zayed St., 6th of October, Giza', '02-38209182', 3),
('Andrea', 'Giza Pyramids Road, Giza', '010-0000-0001', 3),
('Carlos', '3 Bahr El-Ghazal St., Mohandeseen, Giza', '02-37610192', 3),
('Little Buddha', 'Soho Square, Sharm El-Sheikh, South Sinai', '069-3603500', 4),
('Fish Restaurant', 'El Hadaba, Sharm El-Sheikh, South Sinai', '010-0000-0002', 4),
('Luxor Waffle & Ice Cream', 'El-Mahata St., Luxor City, Luxor', '010-0000-0003', 5),
('Abou El-Sid', 'Khaled Ibn El-Waleed St., Luxor City, Luxor', '010-0000-0004', 5),
('Al-Sahaby Lane', 'Marriott Hotel, Luxor City, Luxor', '010-0000-0005', 5);

ALTER TABLE Restaurant
ADD Image VARCHAR(50) ;

INSERT INTO MenuItems (Name, Price, Image, RestaurantId)
VALUES
('Koshary', 20, 'koshary.jpg', 6),
('Molokhia', 25, 'molokhia.jpg', 6),
('Shawerma', 30, 'shawerma.jpg', 6),
('Falafel', 15, 'falafel.jpg', 7),
('Kebab', 35, 'kebab.jpg', 7),
('Hummus', 18, 'hummus.jpg', 7),
('Fatta', 22, 'fatta.jpg', 8),
('Mahshi', 28, 'mahshi.jpg', 8),
('Sayadeya', 40, 'sayadeya.jpg', 8),
('Kofta', 30, 'kofta.jpg', 9),
('Foul', 15, 'foul.jpg', 9),
('Taameya', 20, 'taameya.jpg', 9),
('Bamia', 25, 'bamia.jpg', 10),
('Mansaf', 45, 'mansaf.jpg', 10),
('Shakshuka', 35, 'shakshuka.jpg', 10),
('Koshary', 20, 'koshary.jpg', 11),
('Molokhia', 25, 'molokhia.jpg', 11),
('Shawerma', 30, 'shawerma.jpg', 11),
('Falafel', 15, 'falafel.jpg', 12),
('Kebab', 35, 'kebab.jpg', 12),
('Hummus', 18, 'hummus.jpg', 12),
('Fatta', 22, 'fatta.jpg', 13),
('Mahshi', 28, 'mahshi.jpg', 13),
('Sayadeya', 40, 'sayadeya.jpg', 13),
('Kofta', 30, 'kofta.jpg', 14),
('Foul', 15, 'foul.jpg', 14),
('Taameya', 20, 'taameya.jpg', 14),
('Bamia', 25, 'bamia.jpg', 15),
('Mansaf', 45, 'mansaf.jpg', 15),
('Shakshuka', 35, 'shakshuka.jpg', 15),
('Koshary', 20, 'koshary.jpg', 16),
('Molokhia', 25, 'molokhia.jpg', 16),
('Shawerma', 30, 'shawerma.jpg', 16),
('Falafel', 15, 'falafel.jpg', 17),
('Kebab', 35, 'kebab.jpg', 17),
('Hummus', 18, 'hummus.jpg', 17),
('Fatta', 22, 'fatta.jpg', 18),
('Mahshi', 28, 'mahshi.jpg', 18),
('Sayadeya', 40, 'sayadeya.jpg', 18),
('Kofta', 30, 'kofta.jpg', 19),
('Foul', 15, 'foul.jpg', 19),
('Taameya', 20, 'taameya.jpg', 19),
('Bamia', 25, 'bamia.jpg', 20);

---insert more data in the database 
INSERT INTO MenuItems (Name, Price, RestaurantId, Image)
VALUES('Falafel', 18, 1, 'Falafel.jpg'),
    ('Shawarma', 30, 1, 'Shawarma.jpg'),
    ('Molokhia', 23, 1, 'Molokhia.jpg'),
    ('Kofta', 28, 1, 'Kofta.jpg'),
    ('Fattah', 35, 1, 'Fattah.jpg'),
	('Fatta', 40, 2, 'Fatta.jpg'),
  ('Kofta', 35, 2, 'Kofta.jpg'),
  ('Koshaf', 10, 2, 'Koshaf.jpg'),
  ('Fatta', 50, 3, 'Fatta.jpg'),
  ('Roz Bel Laban', 25, 3, 'Roz-bel-laban.jpg'),
  ('Bamya', 30, 3, 'Bamya.jpg'),
  ('Shawerma', 35, 3, 'Shawerma.jpg'),
  ('Kofta', 40, 3, 'Kofta.jpg'),
  ('Kofta bel Seneya', 45, 3, 'Kofta-bel-seneya.jpg'),
  ('Samak Taouk', 50, 3, 'Samak-taouk.jpg'),
  ('Molokhia bel Riz', 30, 3, 'Molokhia-bel-riz.jpg'),
  ('Makarona bel Bashamel', 35, 3, 'Makarona-bel-bashamel.jpg'),
  ('Fiteer', 40, 3, 'Fiteer.jpg'),
  ('Ful w Taamia', 15, 4, 'Ful-w-Taamia.jpg'),
  ('Koshari', 20, 4, 'Koshari.jpg'),
  ('Hummus', 12, 4, 'Hummus.jpg'),
  ('Tabbouleh', 15, 5, 'Tabbouleh.jpg'),
  ('Hummus', 12, 5, 'Hummus.jpg'),
  ('Moutabal', 14, 5, 'Moutabal.jpg');

  INSERT INTO MenuItems (Name, Price, Image, RestaurantId)
VALUES('Fattah', 40, 'fattah.jpg', 6),
('Mahshi', 35, 'mahshi.jpg', 6),
('Hawawshi', 30, 'hawawshi.jpg', 6),
('Mansaf', 60, 'mansaf.jpg', 8),
  ('Maqluba', 40, 'maqluba.jpg', 8),
  ('Shakshouka', 30, 'shakshouka.jpg', 8),
  ('Knafeh', 25, 'knafeh.jpg', 8),
  ('Manakeesh', 15, 'manakeesh.jpg', 9),
  ('Lahm Bi Ajeen', 35, 'lahm-bi-ajeen.jpg', 9),
  ('Tabbouleh', 20, 'tabbouleh.jpg', 9),
  ('Fattoush', 22, 'fattoush.jpg', 9),
  ('Lamb Chops', 50, 'lamb-chops.jpg', 10),
  ('Biryani', 30, 'biryani.jpg', 10),
  ('Tandoori Chicken', 35, 'tandoori-chicken.jpg', 10),
  ('Palak Paneer', 25, 'palak-paneer.jpg', 10);

  INSERT INTO MenuItems (Name, Price, RestaurantId, Image)
VALUES

  ('Zooba Bowl', 35, 2, 'zooba-bowl.jpg'),
('Hawawshi Sandwich', 28, 2, 'hawawshi-sandwich.jpg'),
('Koshari', 20, 2, 'koshari.jpg'),
('Fava Bean Taameya', 15, 2, 'fava-bean-taameya.jpg'),
('Molokhia', 30, 2, 'molokhia.jpg'),
('Fresh Juice', 12, 2, 'fresh-juice.jpg'),
('Felfela Mix Grill', 60, 3, 'felfela-mix-grill.jpg'),
('Foul & Falafel', 12, 3, 'foul-falafel.jpg'),
('Taameya', 15, 3, 'taameya.jpg'),
('Koshari', 18, 3, 'koshari.jpg'),
('Molokhia', 35, 3, 'molokhia.jpg'),
('Fresh Juice', 10, 3, 'fresh-juice.jpg'),
('Koshari', 12, 4, 'koshari.jpg'),
('Foul & Falafel', 8, 4, 'foul-falafel.jpg'),
('Taameya', 10, 4, 'taameya.jpg'),
('Hawawshi', 18, 4, 'hawawshi.jpg'),
('Molokhia', 22, 4, 'molokhia.jpg'),
('Fresh Juice', 7, 4, 'fresh-juice.jpg'),
('Mandarine Koueider Mix', 40, 5, 'mandarine-koueider-mix.jpg'),
('Eclairs', 15, 5, 'eclairs.jpg'),
('Cookies', 12, 5, 'cookies.jpg'),
('Kababgy Mixed Grill', 50, 6, 'kababgy-mixed-grill.jpg'),
('Kofta', 30, 6, 'kofta.jpg'),
('Koshari', 10, 6, 'koshari.jpg'),
('Sayadeya Rice', 45, 7, 'sayadeya-rice.jpg'),
('Grilled Fish', 35, 7, 'grilled-fish.jpg'),
('Seafood Soup', 25, 7, 'seafood-soup.jpg'),
('Kababgy Mixed Grill', 55, 8, 'kababgy-mixed-grill.jpg'),
('Meat Sambousak', 20, 8, 'meat-sambousak.jpg'),
('Fattoush', 18, 8, 'fattoush.jpg'),
('Mezza Platter', 30, 9, 'mezza-platter.jpg');

SELECT DISTINCT Name FROM MenuItems;