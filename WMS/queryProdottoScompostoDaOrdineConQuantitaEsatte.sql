SELECT 
    CASE 
        WHEN m.mpl_figlio IS NOT NULL THEN m.mpl_figlio
        ELSE o.occ_arti
    END AS prodotto,
    SUM(o.occ_qmov) AS quantita,
    SUM(m.mpl_coimp) * SUM(o.occ_qmov) AS codice_scomposizione
FROM 
    ocordic o
LEFT JOIN 
    mplegami m ON o.occ_arti = m.mpl_padre
WHERE 
    o.occ_tipo = 'P' AND o.occ_code = '6309'
GROUP BY 
    CASE 
        WHEN m.mpl_figlio IS NOT NULL THEN m.mpl_figlio
        ELSE o.occ_arti
    END;