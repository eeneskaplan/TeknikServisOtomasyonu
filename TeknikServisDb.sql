--
-- PostgreSQL database dump
--

\restrict 17OuAYv9aZuudfXJHlZArwM0EWhzrjlonswc4ZxLbyhnhdxaXVFcb79bVLgtuD0

-- Dumped from database version 18.0
-- Dumped by pg_dump version 18.0

-- Started on 2025-12-21 18:19:34

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 229 (class 1255 OID 17659)
-- Name: fn_durumguncelle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn_durumguncelle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- İşlem yapılan arıza kaydının durumunu 'İşlemde' yap
    UPDATE ArizaKayitlari
    SET AnlikDurum = 'İşlemde'
    WHERE ArizaID = NEW.ArizaID;
    
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.fn_durumguncelle() OWNER TO postgres;

--
-- TOC entry 230 (class 1255 OID 17661)
-- Name: sp_borchesapla(integer, numeric); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_borchesapla(IN p_arizaid integer, INOUT toplam_tutar numeric)
    LANGUAGE plpgsql
    AS $$
BEGIN
    SELECT COALESCE(SUM(ParcaUcreti + IscilikUcreti), 0)
    INTO toplam_tutar
    FROM IslemDetaylari
    WHERE ArizaID = p_ArizaID;
END;
$$;


ALTER PROCEDURE public.sp_borchesapla(IN p_arizaid integer, INOUT toplam_tutar numeric) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 226 (class 1259 OID 17622)
-- Name: arizakayitlari; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.arizakayitlari (
    arizaid integer NOT NULL,
    cihazid integer,
    personelid integer,
    giristarihi date DEFAULT CURRENT_DATE,
    anlikdurum character varying(30) DEFAULT 'Bekliyor'::character varying
);


ALTER TABLE public.arizakayitlari OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 17621)
-- Name: arizakayitlari_arizaid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.arizakayitlari_arizaid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.arizakayitlari_arizaid_seq OWNER TO postgres;

--
-- TOC entry 5068 (class 0 OID 0)
-- Dependencies: 225
-- Name: arizakayitlari_arizaid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.arizakayitlari_arizaid_seq OWNED BY public.arizakayitlari.arizaid;


--
-- TOC entry 224 (class 1259 OID 17609)
-- Name: cihazlar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cihazlar (
    cihazid integer NOT NULL,
    musteriid integer,
    marka character varying(50),
    model character varying(50),
    serino character varying(50)
);


ALTER TABLE public.cihazlar OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 17608)
-- Name: cihazlar_cihazid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.cihazlar_cihazid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.cihazlar_cihazid_seq OWNER TO postgres;

--
-- TOC entry 5069 (class 0 OID 0)
-- Dependencies: 223
-- Name: cihazlar_cihazid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.cihazlar_cihazid_seq OWNED BY public.cihazlar.cihazid;


--
-- TOC entry 228 (class 1259 OID 17642)
-- Name: islemdetaylari; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.islemdetaylari (
    islemid integer NOT NULL,
    arizaid integer,
    yapilanislem text,
    parcaucreti numeric(10,2) DEFAULT 0,
    iscilikucreti numeric(10,2) DEFAULT 0,
    islemtarihi timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.islemdetaylari OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 17641)
-- Name: islemdetaylari_islemid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.islemdetaylari_islemid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.islemdetaylari_islemid_seq OWNER TO postgres;

--
-- TOC entry 5070 (class 0 OID 0)
-- Dependencies: 227
-- Name: islemdetaylari_islemid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.islemdetaylari_islemid_seq OWNED BY public.islemdetaylari.islemid;


--
-- TOC entry 222 (class 1259 OID 17597)
-- Name: musteriler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.musteriler (
    musteriid integer NOT NULL,
    adsoyad character varying(100) NOT NULL,
    telefon character varying(15),
    adres text,
    kayittarihi date DEFAULT CURRENT_DATE
);


ALTER TABLE public.musteriler OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 17596)
-- Name: musteriler_musteriid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.musteriler_musteriid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.musteriler_musteriid_seq OWNER TO postgres;

--
-- TOC entry 5071 (class 0 OID 0)
-- Dependencies: 221
-- Name: musteriler_musteriid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.musteriler_musteriid_seq OWNED BY public.musteriler.musteriid;


--
-- TOC entry 220 (class 1259 OID 17586)
-- Name: personel; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.personel (
    personelid integer NOT NULL,
    adsoyad character varying(100) NOT NULL,
    kullaniciadi character varying(50),
    sifre character varying(50),
    rol character varying(20)
);


ALTER TABLE public.personel OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 17585)
-- Name: personel_personelid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.personel_personelid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.personel_personelid_seq OWNER TO postgres;

--
-- TOC entry 5072 (class 0 OID 0)
-- Dependencies: 219
-- Name: personel_personelid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.personel_personelid_seq OWNED BY public.personel.personelid;


--
-- TOC entry 4882 (class 2604 OID 17625)
-- Name: arizakayitlari arizaid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.arizakayitlari ALTER COLUMN arizaid SET DEFAULT nextval('public.arizakayitlari_arizaid_seq'::regclass);


--
-- TOC entry 4881 (class 2604 OID 17612)
-- Name: cihazlar cihazid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cihazlar ALTER COLUMN cihazid SET DEFAULT nextval('public.cihazlar_cihazid_seq'::regclass);


--
-- TOC entry 4885 (class 2604 OID 17645)
-- Name: islemdetaylari islemid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islemdetaylari ALTER COLUMN islemid SET DEFAULT nextval('public.islemdetaylari_islemid_seq'::regclass);


--
-- TOC entry 4879 (class 2604 OID 17600)
-- Name: musteriler musteriid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musteriler ALTER COLUMN musteriid SET DEFAULT nextval('public.musteriler_musteriid_seq'::regclass);


--
-- TOC entry 4878 (class 2604 OID 17589)
-- Name: personel personelid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel ALTER COLUMN personelid SET DEFAULT nextval('public.personel_personelid_seq'::regclass);


--
-- TOC entry 5060 (class 0 OID 17622)
-- Dependencies: 226
-- Data for Name: arizakayitlari; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.arizakayitlari (arizaid, cihazid, personelid, giristarihi, anlikdurum) FROM stdin;
2	2	1	2025-12-14	Tamamlandı
3	3	1	2025-12-14	Tamamlandı
4	4	1	2025-12-21	Tamamlandı
5	5	1	2025-12-21	Tamamlandı
6	6	1	2025-12-21	İşlemde
\.


--
-- TOC entry 5058 (class 0 OID 17609)
-- Dependencies: 224
-- Data for Name: cihazlar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.cihazlar (cihazid, musteriid, marka, model, serino) FROM stdin;
2	6	Apple	Iphone 11	321993
3	7	Samsung	S20+	231492
4	8	Şayomi	Redmi Note 8 PRO	3128310
5	8	Samsung	A24	213421
6	9	Apple	Iphone 5s	353152
\.


--
-- TOC entry 5062 (class 0 OID 17642)
-- Dependencies: 228
-- Data for Name: islemdetaylari; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.islemdetaylari (islemid, arizaid, yapilanislem, parcaucreti, iscilikucreti, islemtarihi) FROM stdin;
4	2	Şarj Soketi Değişikliği	800.00	750.00	2025-12-14 16:38:48.535649
5	2	Ekran Değişimi	1000.00	500.00	2025-12-14 16:39:15.94257
6	3	Ekran Değişimi	1000.00	750.00	2025-12-14 16:39:47.907426
7	3	Ekran Değişimi	1000.00	750.00	2025-12-21 17:52:06.801536
8	4	Ekran Değişimi	800.00	500.00	2025-12-21 17:59:57.334277
9	5	Format Atıldı	0.00	250.00	2025-12-21 18:01:15.683334
10	6	Tuşu düzeltilidi	300.00	1000.00	2025-12-21 18:06:26.397037
\.


--
-- TOC entry 5056 (class 0 OID 17597)
-- Dependencies: 222
-- Data for Name: musteriler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.musteriler (musteriid, adsoyad, telefon, adres, kayittarihi) FROM stdin;
6	Enes Kaplan	05010140680	Tahsin Banguoğlu KYK Öğrenci Yurdu	2025-12-14
7	Arda Akyürek	05053123041	Akarsu Yokuş Sokak 3/4	2025-12-14
8	Nehir Uzunçakmak	05342123521	Dİyarbakır	2025-12-21
9	Atahan Er Topoğlu	0505213531	Kemeraltı limonata sokak no21	2025-12-21
\.


--
-- TOC entry 5054 (class 0 OID 17586)
-- Dependencies: 220
-- Data for Name: personel; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.personel (personelid, adsoyad, kullaniciadi, sifre, rol) FROM stdin;
1	Admin User	admin	1234	Yonetici
\.


--
-- TOC entry 5073 (class 0 OID 0)
-- Dependencies: 225
-- Name: arizakayitlari_arizaid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.arizakayitlari_arizaid_seq', 6, true);


--
-- TOC entry 5074 (class 0 OID 0)
-- Dependencies: 223
-- Name: cihazlar_cihazid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.cihazlar_cihazid_seq', 6, true);


--
-- TOC entry 5075 (class 0 OID 0)
-- Dependencies: 227
-- Name: islemdetaylari_islemid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.islemdetaylari_islemid_seq', 10, true);


--
-- TOC entry 5076 (class 0 OID 0)
-- Dependencies: 221
-- Name: musteriler_musteriid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.musteriler_musteriid_seq', 9, true);


--
-- TOC entry 5077 (class 0 OID 0)
-- Dependencies: 219
-- Name: personel_personelid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.personel_personelid_seq', 1, true);


--
-- TOC entry 4898 (class 2606 OID 17630)
-- Name: arizakayitlari arizakayitlari_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.arizakayitlari
    ADD CONSTRAINT arizakayitlari_pkey PRIMARY KEY (arizaid);


--
-- TOC entry 4896 (class 2606 OID 17615)
-- Name: cihazlar cihazlar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cihazlar
    ADD CONSTRAINT cihazlar_pkey PRIMARY KEY (cihazid);


--
-- TOC entry 4900 (class 2606 OID 17653)
-- Name: islemdetaylari islemdetaylari_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islemdetaylari
    ADD CONSTRAINT islemdetaylari_pkey PRIMARY KEY (islemid);


--
-- TOC entry 4894 (class 2606 OID 17607)
-- Name: musteriler musteriler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.musteriler
    ADD CONSTRAINT musteriler_pkey PRIMARY KEY (musteriid);


--
-- TOC entry 4890 (class 2606 OID 17595)
-- Name: personel personel_kullaniciadi_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel
    ADD CONSTRAINT personel_kullaniciadi_key UNIQUE (kullaniciadi);


--
-- TOC entry 4892 (class 2606 OID 17593)
-- Name: personel personel_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel
    ADD CONSTRAINT personel_pkey PRIMARY KEY (personelid);


--
-- TOC entry 4905 (class 2620 OID 17660)
-- Name: islemdetaylari trg_islemgirildi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trg_islemgirildi AFTER INSERT ON public.islemdetaylari FOR EACH ROW EXECUTE FUNCTION public.fn_durumguncelle();


--
-- TOC entry 4902 (class 2606 OID 17631)
-- Name: arizakayitlari arizakayitlari_cihazid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.arizakayitlari
    ADD CONSTRAINT arizakayitlari_cihazid_fkey FOREIGN KEY (cihazid) REFERENCES public.cihazlar(cihazid) ON DELETE CASCADE;


--
-- TOC entry 4903 (class 2606 OID 17636)
-- Name: arizakayitlari arizakayitlari_personelid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.arizakayitlari
    ADD CONSTRAINT arizakayitlari_personelid_fkey FOREIGN KEY (personelid) REFERENCES public.personel(personelid);


--
-- TOC entry 4901 (class 2606 OID 17616)
-- Name: cihazlar cihazlar_musteriid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cihazlar
    ADD CONSTRAINT cihazlar_musteriid_fkey FOREIGN KEY (musteriid) REFERENCES public.musteriler(musteriid) ON DELETE CASCADE;


--
-- TOC entry 4904 (class 2606 OID 17654)
-- Name: islemdetaylari islemdetaylari_arizaid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islemdetaylari
    ADD CONSTRAINT islemdetaylari_arizaid_fkey FOREIGN KEY (arizaid) REFERENCES public.arizakayitlari(arizaid) ON DELETE CASCADE;


-- Completed on 2025-12-21 18:19:35

--
-- PostgreSQL database dump complete
--

\unrestrict 17OuAYv9aZuudfXJHlZArwM0EWhzrjlonswc4ZxLbyhnhdxaXVFcb79bVLgtuD0

