INSERT INTO wms_items (id_art, id_mov, locat, qta, fornitore) 
VALUES ("ciao", "231", "A100", 10, "cia1") AS new_data 
ON DUPLICATE KEY UPDATE wms_items.qta = new_data.qta + wms_items.qta;
