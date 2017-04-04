using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonAmulet_Demo
{
    public static class Utilites
    {
        //public static Random rand = new Random();

        //public static void attack(ref _1GameWorld world, string loc, string fromid, string toid, string magic = "", bool answer = true)
        //{
        //    // только игроки и нпс
        //    if ((fromid.Substring(0, 5) != "user." && fromid.Substring(0, 4) != "npc.") || (toid.Substring(0, 5) != "user." && toid.Substring(0, 4) != "npc.")) return;

        //    if (!world.players.ContainsKey(fromid) || world.players[fromid].location != loc) return;
        //    _1Player from = world.players[fromid];
        //    if (from.ghost) return;
        //    //проверим время отдыха (кроме когда отвечаем)
        //    if (!answer && DateTime.Now <= from.time_speed) return;
        //    Dictionary<string, string> fromwar = new Dictionary<string, string>();
        //    if (!String.IsNullOrWhiteSpace(magic)) SetWarArray(ref fromwar, magic); else fromwar = from.war; //if ($magic) $fromwar=split("\|",$magic); else $fromwar=split("\|",$from["war"]);

        //    if (answer) from.time_speed = DateTime.Now.AddSeconds(Convert.ToInt32(fromwar["speed"])); // время для отдыха
        //    int hit = Convert.ToInt32(fromwar["hit"]);
        //    bool b = false;

        //    _1Player to;
        //    string[] loc1 = world.loc_moves[loc].Split('|');
        //    if (world.players[toid].location != loc && Convert.ToBoolean(fromwar["ranged"]))
        //    {
        //        // если ranged и не магией, то ищем в соседних локациях
        //        for (int i = 3; i < loc1.Length; i += 2)
        //        {
        //            if (world.players[toid].location == loc1[i])
        //            {
        //                //нашли, штраф к меткости
        //                b = true;
        //                to = world.players[toid];
        //                hit -= 10;
        //                if (hit < 0) hit = 0;
        //                break;
        //            }
        //        }
        //    }

        //    if (!b && (!world.players.ContainsKey(toid) || world.players[toid].location != loc))
        //    {
        //        addjournal(ref world, fromid, "Цель недоступна");
        //        return;
        //    }
        //    to = world.players[toid];
        //    if (to.ghost) return;
        //    Dictionary<string, string> towar = to.war;

        //    int uklon, parring, shield;
        //    if (!String.IsNullOrWhiteSpace(magic))
        //    {
        //        uklon = Convert.ToInt32(towar["magic_uklon"]); // вероятность уклониться 0..100%
        //        parring = Convert.ToInt32(towar["magic_parring"]); // вероятность уменьшить урон на shield
        //        shield = Convert.ToInt32(towar["magic_shield"]);
        //    }
        //    else
        //    {
        //        uklon = Convert.ToInt32(towar["uklon"]);
        //        parring = Convert.ToInt32(towar["parring"]);
        //        shield = Convert.ToInt32(towar["shield"]);
        //    }

        //    // если напали на хорошего (не крим и не атакует вас), кроме животных вне охраняемой зоны (для охоты), то становимся кримами
        //    bool crim = (to.crim || toid.Substring(0, 9) == "npc.crim." || (toid.Substring(0, 11) == "npc.animal." && !Convert.ToBoolean(world.loc_moves[loc].Split('|')[1])));
        //    if (!crim && to.attack != fromid) docrim(ref world, fromid);

        //    // Проверим, а есть ли стрелы или что там нужно...
        //    bool needok = true;
        //    if (!String.IsNullOrWhiteSpace(fromwar["need"]))
        //    {
        //        if (from.items.ContainsKey(fromwar["need"]))
        //        {
        //            // тратим 1 патрон
        //            string[] item = from.items[fromwar["need"]].Split('|');
        //            item[1] = Convert.ToString(Convert.ToInt32(item[1]) - 1);
        //            if (Convert.ToInt32(item[1]) >= 1)
        //            {
        //                from.items[fromwar["need"]] = String.Join("|", item);
        //            }
        //            else
        //            {
        //                // патроны кончились, заново расчет параметров
        //                from.items.Remove(fromwar["need"]);
        //                from.equip.Remove("arm"); // убираем с рук
        //                CalcParam(ref from);
        //            }
        //        }
        //        else needok = false;
        //    }


        //    if (needok)
        //    {
        //        // проверим, попали ли
        //        if (rand.Next(0, 100) <= hit)
        //        {
        //            // урон
        //            int damage = rand.Next(Convert.ToInt32(fromwar["damage_min"]), Convert.ToInt32(fromwar["damage_max"]));
        //            // уклон
        //            if (rand.Next(0, 100) <= uklon)
        //            {
        //                // щит
        //                if (parring > 0 && shield > 0)
        //                {
        //                    if (rand.Next(0, 100) <= parring)
        //                    {
        //                        if (String.IsNullOrWhiteSpace(magic))
        //                        {
        //                            damage -= shield;
        //                            addjournalall(ref world, loc, to.title + " парировал щитом");
        //                        }
        //                        else
        //                        {
        //                            damage -= damage * shield / 100;
        //                            addjournalall(ref world, loc, to.title + " сопротивляется магии");
        //                        }
        //                    }
        //                }
        //                // броня
        //                if (String.IsNullOrWhiteSpace(magic) && Convert.ToInt32(towar["armor"]) > 0)
        //                    damage -= Convert.ToInt32(towar["armor"]); // есть броня, гасим на armor, но не для магии
        //                if (damage < 0) damage = 0;
        //                if (to.god) damage = 0; // режим бога
        //                // наносим урон
        //                to.life -= damage;
        //                if (to.life < 0) to.life = 0;
        //                addjournal(ref world, fromid, "Вы нанесли " + to.title + " урон " + fromwar["weaponby"] + " " + Convert.ToString(damage));
        //                addjournal(ref world, toid, from.title + " нанес вам урон " + fromwar["weaponby"] + " " + Convert.ToString(damage));
        //                addjournalall(ref world, loc, from.title + " нанес " + to.title + " урон " + fromwar["weaponby"] + " " + Convert.ToString(damage), fromid, toid);

        //                if (to.life < 1)
        //                {
        //                    //eval(implode('',file("f_kill.dat")));
        //                }
        //            }
        //            else
        //            {
        //                addjournal(ref world, toid, "Вы уклонились");
        //                addjournalall(ref world, loc, to.title + " уклонился", toid);
        //            }
        //        }
        //        else
        //        {
        //            addjournal(ref world, fromid, "Вы промахнулись");
        //            addjournalall(ref world, loc, from.title + " промахнулся", fromid);
        //        }
        //    }
        //    else addjournal(ref world, fromid, "Нет патронов: " + fromwar["needtitle"]);

        //    // если оба живы, то обороняющийся отвечает (кроме магии)
        //    if (world.players.ContainsKey(toid) && world.players[toid].location == loc && world.players.ContainsKey(fromid) && world.players[fromid].location == loc && fromid == toid)
        //    {
        //        if (String.IsNullOrWhiteSpace(to.attack)) to.attack = fromid;
        //        if (answer && String.IsNullOrWhiteSpace(magic)) attack(ref world, loc, toid, fromid, "", false);
        //    }
        //}

        //public static void docrim(ref _1GameWorld world, string login)
        //{
        //    if (world.players.ContainsKey(login)) // монстрам надпись крим не делаем
        //    {
        //        world.players[login].crim = true;
        //        world.players[login].time_crim = DateTime.Now.AddSeconds(10 * 60);
        //    }
        //}

        //public static void addjournal(ref _1GameWorld world, string to, string msg)
        //{
        //    // добавляет в журнал и следит, чтоб не переполнился
        //    if (world.players.ContainsKey(to))
        //    {
        //        world.players[to].journal.Add(msg);
        //        if (world.players[to].journal.Count > 100)
        //            world.players[to].journal.RemoveRange(0, world.players[to].journal.Count - 100);
        //    }
        //}

        //public static void addjournalall(ref _1GameWorld world, string loc, string msg, string no1 = "", string no2 = "")
        //{
        //    // добавляет запись всем в журнал, кроме no1 и no2
        //    foreach (KeyValuePair<string, _1Player> item in world.players)
        //    {
        //        if (item.Key != no1 && item.Key != no2)
        //        {
        //            if (item.Value.location == loc) addjournal(ref world, item.Key, msg);
        //        }
        //    }
        //}

        //public static void ressurect(ref _1GameWorld world, string to)
        //{
        //    if (world.players.ContainsKey(to))
        //        if (!world.players[to].ghost)
        //        {
        //            addjournal(ref world, to, "Вы не призрак");
        //            return;
        //        }
        //    world.players[to].ghost = false;
        //    world.players[to].time_regenerate = DateTime.Now;

        //    addjournalall(ref world, world.players[to].location, world.players[to].title + " воскрес!", to);
        //    addjournal(ref world, to, "Вы воскресли!");
        //}

        //public static void f_go(ref _1GameWorld world, ref _1Player player, string go)
        //{
        //    // проверим, если такой выход в локации с игроком
        //    string[] old = world.loc_moves[player.location].Split('|');

        //    if (world.loc_moves.ContainsKey(go) && old.Contains(go))
        //    {
        //        string[] neww = world.loc_moves[go].Split('|');
        //        if (!Convert.ToBoolean(old[1]) && Convert.ToBoolean(neww[1])) addjournal(ref world, player.title, "Вы на охраняемой территории");
        //        if (Convert.ToBoolean(old[1]) && !Convert.ToBoolean(neww[1])) addjournal(ref world, player.title, "Вы покинули охраняемую территорию");
        //        addjournalall(ref world, player.location, player.title + " ушел ", player.title);
        //        player.attack = "";
        //        player.location = go;
        //        addjournalall(ref world, go, "Пришел " + player.title, player.title);
        //    }
        //}

        //public static void f_use(ref _1GameWorld world, ref _1Player player, string use, string to)
        //{
        //    //linkИспользовать
        //    // если нужна цель, то задаем $list='all' и ниже выведется список целей
        //    if (player.ghost) throw new NotImplementedException("Вы призрак и поэтому не можете ничего использовать, найдите лекаря или камень воскрешения");
        //    bool scroll = false; // кастуем не со свитка, может измениться, если используем предмет-свиток
        //    if (use.Substring(0, 5) == "item.")
        //    {
        //        // использование предметов
        //        if (!player.items.ContainsKey(use)) throw new NotImplementedException("У вас нет этого предмета");
        //        if (use.Substring(0, 12) == "item.weapon." || use.Substring(0, 11) == "item.armor.")
        //        {
        //            // одеваем/снимаем оружие броню
        //            // если в руках нож и есть $to, то освежевание
        //            if (player.equip == null) player.equip = new Dictionary<string, string>();
        //            if (!String.IsNullOrWhiteSpace(to) && use.Substring(0, 17) == "item.weapon.knife" && player.equip.ContainsValue(use))
        //            {
        //                if (to.Substring(0, 16) == "item.stand.died." && world.locations[player.location].ContainsValue(to))
        //                {
        //                    /*
        //                    $died=split("\|",$game["loc"][$player["loc"]][$to]);
        //                    $items=array();
        //                    if ($died[3])
        //                    {
        //                        if ($died[2])
        //                        {
        //                            // items
        //                            $it=split(",",$died[2]);
        //                            foreach ($it as $i) if ($i)
        //                            {
        //                                $item=split("=",$i);
        //                                $items[$item[0]]=str_replace(":","|",$item[1]);
        //                            }
        //                        }
        //                        $it=split(",",$died[3]);	// osvej
        //                        foreach ($it as $i) if ($i)
        //                        {
        //                            $item=split("=",$i);
        //                            $id=$item[0];
        //                            $item=split(":",$item[1]);
        //                            // добавим предмет трупу
        //                            if (isset($items[$id]))
        //                            {
        //                                $item1=split("\|",$items[$id]);
        //                                $item[1]+=$item1[1];
        //                            }
        //                            $items[$id]=implode("|",$item);
        //                        }
        //                        // обновляем все предметы у трупа
        //                        $died[3]='';	// чтоб больше одного раза не удалось освежевать
        //                        $it="";
        //                        foreach(array_keys($items) as $i) $it.=$i."=".str_replace("|",":",$items[$i]).",";
        //                        $died[2]=$it;
        //                        $game["loc"][$player["loc"]][$to]=implode("|",$died);
        //                        addjournal($login,"Вы освежевали ".$died[0]);
        //                    }
        //                    else addjournal($login,"На трупе нет трофеев");
        //                    */
        //                }
        //                else addjournal(ref world, player.title, "Нож можно использоваться для разделки только трупов");
        //            }
        //            else
        //            {
        //                if (player.equip == null) player.equip = new Dictionary<string, string>();
        //                if (!player.equip.ContainsValue(use))
        //                {
        //                    if (use.Substring(0, 12) == "item.weapon.") if (player.equip.ContainsKey("arm")) player.equip["arm"] = use; else player.equip.Add("arm", use);
        //                    if (use.Substring(0, 15) == "item.armor.body") if (player.equip.ContainsKey("body")) player.equip["body"] = use; else player.equip.Add("body", use);
        //                    if (use.Substring(0, 15) == "item.armor.hand") if (player.equip.ContainsKey("hand")) player.equip["hand"] = use; else player.equip.Add("hand", use);
        //                    if (use.Substring(0, 14) == "item.armor.leg") if (player.equip.ContainsKey("leg")) player.equip["leg"] = use; else player.equip.Add("leg", use);
        //                    if (use.Substring(0, 15) == "item.armor.head") if (player.equip.ContainsKey("head")) player.equip["head"] = use; else player.equip.Add("head", use);
        //                    if (use.Substring(0, 17) == "item.armor.shield") if (player.equip.ContainsKey("shield")) player.equip["shield"] = use; else player.equip.Add("shield", use);
        //                    // если берем в руки нож, то просим цель для освежевания
        //                    //if (substr($use,0,17)=='item.weapon.knife') $list='all';
        //                }
        //                else if (player.equip != null) foreach (string key in player.equip.Keys) { if (player.equip[key] == use) { player.equip.Remove(key); break; } }
        //                CalcParam(ref player);

        //            }
        //        }
        //        else if (use.Substring(0, 9) == "item.note")
        //        {
        //            string[] item = player.items[use].Split('|');
        //            throw new NotImplementedException(item[3] + "\n\r" + item[0]); //msg($item[3], $item[0], 1);
        //        }
        //        else if (use.Substring(0, 12) == "item.scroll." || use.Substring(0, 10) == "item.rune.")
        //        {
        //            // свитки и руны кастуются ниже как магия, но не требует регов
        //            /*$scroll=$use;
        //            if (substr($use,0,12)=='item.scroll.') $use="magic.".substr($use,12);
        //            else $use="magic.".substr($use,10);
        //            eval(implode('',file("f_magic.dat")));	// загружаем всю магию
        //            $magic=split("\|",$arr_magic[$use]);
        //            if ($magic[6] && !$to) {$use=$scroll; $list='all'; $scroll=0;}	// чтобы вывести список целей*/
        //        }
        //        else if (use.Substring(0, 10) == "item.food." || use.Substring(0, 12) == "item.bottle.")
        //        {
        //            /*if (use.Substring(0,17) != "item.bottle.empty")
        //            {
        //                string[] item = split("\|",$player["items"][$use]);
        //                $life=$item[3];
        //                $mana=$item[4];
        //                if ($life)
        //                {
        //                    if($player["life"]+$life>$player["life_max"]) $life=$player["life_max"]-$player["life"];
        //                    $player["life"]+=$life; 
        //                    addjournal($login,'Жизнь +'.$life);
        //                }
        //                if ($mana)
        //                {
        //                    if($player["mana"]+$mana>$player["mana_max"]) $mana=$player["mana_max"]-$player["mana"];
        //                    $player["mana"]+=$mana; 
        //                    addjournal($login,'Мана +'.$mana);
        //                }
        //                // удаляем использованный предмет
        //                $item[1]-=1;
        //                if ($item[1]>0) $player["items"][$use]=implode("|",$item); else unset($player["items"][$use]);
        //                //добавляем пустую бутылку
        //                if (substr($use,0,12)=='item.bottle.')
        //                {
        //                    if (isset($player["items"]["item.bottle.empty"]))
        //                    {
        //                        $bottle=split("\|",$player["items"]["item.bottle.empty"]);
        //                        $bottle[1]+=1;
        //                        $player["items"]["item.bottle.empty"]=implode("|",$bottle);
        //                    }
        //                    else $player["items"]["item.bottle.empty"]="бутылка|1|5|0|0|";
        //                    addjournal($login,'Вы получили 1 бутылка');
        //                }
        //                addjournal(player.title, "Вы потеряли 1 " + item[0]);
        //            }
        //            else addjournal(player.title, "В бутылке ничего нет");
        //        }
        //        else addjournal(player.title,"Никакого эффекта");*/
        //        }
        //        if (use.Substring(0, 6) == "magic.")
        //        {
        //            // кастинг заклинаний
        //            /*
        //            eval(implode('',file("f_magic.dat")));	// загружаем всю магию
        //            $magic=split("\|",$arr_magic[$use]);

        //            // проверяем, нужна ли цель
        //            if (($magic[6] && $to) || !$magic[6])
        //            {
        //                // проверяем, хватает ли маны
        //                if ($player["mana"]>=$magic[1])
        //                {
        //                    $regsok=1;
        //                    if (!$scroll)
        //                    {		// проверяем и удаляем реги
        //                        if (!isset($player["magic"][$use])) msg("<p>У вас нет такого заклинания!");
        //                        $st="";
        //                        for ($i=9;$i<count($magic);$i++)
        //                        {
        //                            $reg=split(":",$magic[$i]);
        //                            if (!isset($player["items"][$reg[0]])) {$regsok=0; $st.="<br/>".$reg[2];}
        //                            else {$item=split("\|",$player["items"][$reg[0]]); if ($item[1]<$reg[1]) {$regsok=0; if ($st) $st.=", ".$reg[2]; else $st=$reg[2];}}
        //                        }
        //                    }
        //                    if ($regsok)
        //                    {
        //                        // мана и реги ок, кастуем
        //                        $skills=split("\|",$player["skills"]);
        //                        // вероятность кастинга
        //                        $cast=10*(($skills[13]+1)*2-$magic[2]);
        //                        if ($cast>0)
        //                        {
        //                            // пытаемся колдовать
        //                            // уменьшаем ману
        //                            $player["mana"]-=$magic[1];
        //                            // если требовались реги, удаляем их
        //                            if (!$scroll) for ($i=9;$i<count($magic);$i++)
        //                            {
        //                                $reg=split(":",$magic[$i]);
        //                                $item=split("\|",$player["items"][$reg[0]]);
        //                                $item[1]-=1;
        //                                if ($item[1]<1) unset($player["items"][$reg[0]]);
        //                                else $player["items"][$reg[0]]=implode("|",$item); 
        //                            }
        //                            // если кастовали со скролла, удаляем его
        //                            if ($scroll && substr($scroll,0,12)=='item.scroll.')
        //                            {
        //                                $item=split("\|",$player["items"][$scroll]);
        //                                $item[1]-=1;
        //                                if ($item[1]<1) unset($player["items"][$scroll]); else $player["items"][$scroll]=implode("|",$item); 
        //                                addjournal($login,"Вы потеряли 1 ".$item[0]);
        //                            }
        //                            // произносим заклинание
        //                            addjournalall($player["loc"],$player["title"].": ".$magic[3]);
        //                            if (rand(0,100)<=$cast)
        //                            {
        //                                // удалось!
        //                                // перебираем каждое заклинание и эффект от него
        //                                if ($use=='magic.mark')
        //                                {
        //                                    // Пометить
        //                                    if (isset($player["items"][$to]) && substr($to,0,15)=='item.recallrune')
        //                                    {
        //                                        $id="item.recallrune.".$player["loc"];
        //                                        $loc=split("\|",$locations[$player["loc"]]);
        //                                        // удаляем пустую руну
        //                                        $item=split("\|",$player["items"][$to]);
        //                                        $item[1]-=1;
        //                                        if ($item[1]<1) unset($player["items"][$to]);
        //                                        else $player["items"][$to]=implode("|",$item); 
        //                                        // добавляем новую руну
        //                                        if (isset($player["items"][$id])) $item=split("\|",$player["items"][$id]);
        //                                        else $item=split("\|","руна ".$loc[0]."|0|100");
        //                                        $item[1]+=1;
        //                                        $player["items"][$id]=implode("|",$item); 
        //                                        addjournal($login,"Руна помечена как ".$loc[0]);
        //                                    }
        //                                    else addjournal($login,"Заклинание можно использовать только на руну телепортации");
        //                                }

        //                                if ($use=='magic.recall')
        //                                {
        //                                    // Возвращение
        //                                    if (isset($player["items"][$to]) && substr($to,0,15)=='item.recallrune')
        //                                    {
        //                                        if (substr($to,0,21)!='item.recallrune.empty')
        //                                        {
        //                                            $go=substr($to,0,16);
        //                                            $old=split("\|",$locations[$player["loc"]]);
        //                                            if (isset($locations[$go]))
        //                                            {
        //                                                $new=split("\|",$locations[$go]);
        //                                                if (!$old[1] && $new[1]) addjournal($login,"Вы на охраняемой территории");
        //                                                if ($old[1] && !$new[1]) addjournal($login,"Вы покинули охраняемую территорию");
        //                                                addjournalall($player["loc"],$player["title"]." исчез ",$login);
        //                                                $game["loc"][$go][$login]=$game["loc"][$player["loc"]][$login];
        //                                                unset($game["loc"][$player["loc"]][$login]);
        //                                                unset($player);
        //                                                $player=&$game["loc"][$go][$login];
        //                                                unset($player["attack"]);
        //                                                $game["players"][$login]=$go;
        //                                                $player["loc"]=$go;
        //                                                addjournalall($go,"Появился ".$player["title"],$login);
        //                                                $page_desc = "1";	// вывести описание локации
        //                                            }
        //                                        }
        //                                        else addjournal($login,"Руна не помечена ни в одно место");
        //                                    }
        //                                    else addjournal($login,"Заклинание можно использовать только на руну телепортации");
        //                                }

        //                                if ($use=='magic.createfood')
        //                                {
        //                                    // создать еду
        //                                    $rnd=rand(0,100);
        //                                    if ($rnd<=20) {$id="item.food.apple"; $item="яблоко|1|4|2|0|";}
        //                                    if ($rnd>20 && $rnd<=35) {$id="item.food.cabbage"; $item="капуста|1|10|1|0|";}
        //                                    if ($rnd>35 && $rnd<=55) {$id="item.food.bread"; $item="хлеб|1|16|6|0|";}
        //                                    if ($rnd>55 && $rnd<=75) {$id="item.food.sandwich"; $item="бутерброд|1|15|5|0|";}
        //                                    if ($rnd>75 && $rnd<=85) {$id="item.food.mushroom"; $item="гриб|1|10|2|2|";}
        //                                    if ($rnd>85 && $rnd<=100) {$id="item.food.sausage"; $item="колбаса|1|20|9|0|";}
        //                                    // добавляем новый предмет в локацию
        //                                    if (isset($game["loc"][$player["loc"]][$id])) $item=split("\|",$game["loc"][$player["loc"]][$id]);
        //                                    else $item=split("\|",$item);
        //                                    $game["loc"][$player["loc"]][$id]=implode("|",$item);
        //                                    addjournalall($player["loc"],"Появился 1 ".$item[0]);
        //                                }
							
        //                                if (substr($use,0,10)=='magic.heal')
        //                                {
        //                                    // лечить
        //                                    if (isset($game["loc"][$player["loc"]][$to]) && (substr($to,0,4)=='npc.' || substr($to,0,5)=='user.'))
        //                                    {
        //                                        $heal=rand($magic[4],$magic[5]);	// только не повреждает, а лечит
        //                                        if ($game["loc"][$player["loc"]][$to]["life"]+$heal>$game["loc"][$player["loc"]][$to]["life_max"]) $heal=$game["loc"][$player["loc"]][$to]["life_max"]-$game["loc"][$player["loc"]][$to]["life"];
        //                                        $game["loc"][$player["loc"]][$to]["life"]+=$heal;
        //                                        addjournal($to,"Жизнь +".$heal);
        //                                        // если лечим крима, сами станомся кримом
        //                                        $crim=$game["loc"][$player["loc"]][$to]["crim"] || substr($to,0,9)=='npc.crim.';
        //                                        if ($crim) docrim($login);
        //                                    }
        //                                    else addjournal($login,"Некого лечить");
        //                                }

        //                                if ($use=='magic.ressurect')
        //                                {
        //                                    // воскресить
        //                                    if (isset($game["loc"][$player["loc"]][$to]) && substr($to,0,5)=='user.' && $game["loc"][$player["loc"]][$to]["ghost"])
        //                                    {
        //                                        ressurect($to);
        //                                    }
        //                                    else addjournal($login,"Воскресить можно только игрока");
        //                                }
							
        //                                if ($use=='magic.maddenes')
        //                                {
        //                                    // безумие
        //                                    $keys = array_keys($game["loc"][$player["loc"]]);
        //                                    $id = $keys[rand(0,count($keys)-1)];
        //                                    if (substr($id,0,5)=='user.' || substr($id,0,4)=='npc.')
        //                                    {
        //                                        $idto = $keys[rand(0,count($keys)-1)];
        //                                        if ($id!=$idto && (substr($idto,0,5)=='user.' || substr($idto,0,4)=='npc.'))
        //                                        {
        //                                            $game["loc"][$player["loc"]][$id]["attack"]=$idto;
        //                                            attack($player["loc"],$id,$idto);
        //                                        }
        //                                        else addjournal($login,"Безумие прошло, никого не тронув");
        //                                    }
        //                                    else addjournal($login,"Безумие никого не тронуло");
        //                                }
							
        //                                if ($use=='magic.silence')
        //                                {
        //                                    // тишина
        //                                    if ($game["loc"][$player["loc"]])
        //                                        foreach(array_keys($game["loc"][$player["loc"]]) as $i)
        //                                            if (substr($i,0,4)=='npc.' && $game["loc"][$player["loc"]][$i]["attack"]) {unset($game["loc"][$player["loc"]][$i]["attack"]);}
        //                                }
							
        //                                if ($use=='magic.peace')
        //                                {
        //                                    // успокоить
        //                                    if (isset($game["loc"][$player["loc"]][$to]) && substr($to,0,4)=='npc.') unset($game["loc"][$player["loc"]][$to]["attack"]);
        //                                    else addjournal($login,"Заклинание действует только на NPC");
        //                                }
							
        //                                if (substr($use,0,11)=='magic.charm')
        //                                {
        //                                    // зачаровать или привлечь
        //                                    if (isset($game["loc"][$player["loc"]][$to]))
        //                                    {
        //                                        $ok=0;
        //                                        // зачаровать до 5 минут животных animal=1, сопровождают и охраняют
        //                                        if ($use=='magic.charm' && substr($to,0,7)=='animal.') {$ok=1; $timemin=60; $timemax=5*60; $follow=1;} else addjournal($login,"Заклинание действует только на животных");
        //                                        // привлечь на свою до 20 сек - 1 минута сторону любого (кроме гардов) атакующего, защищает, но не сопровождает
        //                                        if ($use=='magic.charm.enemy' && substr($to,0,4)=='npc.' && !substr($to,0,9)=='npc.guard' && $game["loc"][$player["loc"]][$to]["attack"]) {$ok=1; $timemin=20; $timemax=1*60;  $follow=0;} else addjournal($login,"Заклинание действует только на дерущихся");
        //                                        if ($ok) {unset($game["loc"][$player["loc"]][$to]["attack"]); $game["loc"][$player["loc"]][$to]["owner"]=$login; $game["loc"][$player["loc"]][$to]["time_owner"]=time()+rand($timemin,$timemax);if ($follow) $game["loc"][$player["loc"]][$to]["follow"]=$login;$game["loc"][$player["loc"]][$to]["guard"]==$login;}
        //                                    }
        //                                    addjournal($login,"Нет цели");
        //                                }
							
        //                                if (substr($use,0,10)=='magic.all.')
        //                                {	// на всех
        //                                    // т.к. атакуем магией, то сэмулируем 'war'
        //                                    // war=hit|damage_min|damage_max|speed|ranged|armor|uklon|parring|shield|magic_uklon|magic_parring|magic_shield|weaponby|exp|need|needtitle
        //                                    $war="100|".$magic[4]."|".$magic[5]."|".$magic[8]."|0|0|0|0|0|0|0|0|магией|0||";
        //                                    if ($game["loc"][$player["loc"]]) foreach(array_keys($game["loc"][$player["loc"]]) as $i) if (substr($i,0,5)!='item.') if (!$magic[7] || ($magic[7] && ($game["loc"][$player["loc"]][$i]["crim"] || substr($i,0,9)=='npc.crim.'))) attack($player["loc"],$login,$i,$war);
        //                                    // наносим и себе урон
        //                                    if ($use=='magic.all.earthquake') attack($player["loc"],$login,$login,$war);
        //                                }
							
        //                                if (substr($use,0,10)=='magic.war.')
        //                                {	// боевые на цель
        //                                    $war="100|".$magic[4]."|".$magic[5]."|".$magic[8]."|0|0|0|0|0|0|0|0|магией|0||";
        //                                    if (isset($game["loc"][$player["loc"]][$to]) && substr($to,0,5)!='item.')
        //                                    {
        //                                        if (!$magic[7] || ($magic[7] && ($game["loc"][$player["loc"]][$to]["crim"] || substr($to,0,9)=='npc.crim.'))) attack($player["loc"],$login,$to,$war);
        //                                    }
        //                                    else addjournal($login," Заклинание действует только на существ");
        //                                }
        //                                if (substr($use,0,13)=='magic.summon.')
        //                                {
        //                                    // призывание
        //                                    // проверим, чтобы в локации не было более 3 призванных существ, остальных отпустим
        //                                    $counttmp=0;
        //                                    if ($game["loc"][$player["loc"]]) foreach (aray_keys($game["loc"][$player["loc"]]) as $i) if ($game["loc"][$player["loc"]][$i]["owner"]==$login) {$counttmp++; if ($counttmp>3) if ($game["loc"][$player["loc"]][$i]["destroyonfree"]) {addjournalall($player["loc"],$game["loc"][$player["loc"]][$i]["title"]." исчез"); addjournal($login,$game["loc"][$player["loc"]][$i]["title"]." покинул вас"); unset($game["loc"][$player["loc"]][$i]);} else {addjournal($login,$game["loc"][$player["loc"]][$i]["title"]." покинул вас"); unset($game["loc"][$player["loc"]][$i]["owner"]);unset($game["loc"][$player["loc"]][$i]["time_owner"]); unset($game["loc"][$player["loc"]][$i]["follow"]); unset($game["loc"][$player["loc"]][$i]["guard"]);}}
        //                                    if ($use=='magic.summon.wolf') $item=array(
        //                                        "title"=>"призванный волк",
        //                                        "life"=>"20",
        //                                        "life_max"=>"20",
        //                                        "war"=>"70|4|11|5|0|0|5|0|0|0|0|0|зубами|0||",
        //                                        );
        //                                    if ($use=='magic.summon.skeleton') $item=array(
        //                                        "title"=>"призванный скелет",
        //                                        "life"=>"30",
        //                                        "life_max"=>"30",
        //                                        "war"=>"65|5|12|6|0|0|10|0|0|0|0|0||0||",
        //                                        );
        //                                    if ($use=='magic.summon.golem') $item=array(
        //                                        "title"=>"призванный голем",
        //                                        "life"=>"50",
        //                                        "life_max"=>"50",
        //                                        "war"=>"90|8|14|7|0|5|10|0|0|30|50|4||0||",
        //                                        );
        //                                    if ($use=='magic.summon.demon') $item=array(
        //                                        "title"=>"призванный демон",
        //                                        "life"=>"80",
        //                                        "life_max"=>"80",
        //                                        "war"=>"95|9|18|7|0|3|10|0|0|20|70|8||0||",
        //                                        );
        //                                    srand ((float) microtime() * 10000000);
        //                                    $id=$template.rand(5,9999);
        //                                    $game["loc"][$player["loc"]][$id] = $item;
        //                                    $game["loc"][$player["loc"]][$id]["owner"] = $login;
        //                                    $game["loc"][$player["loc"]][$id]["guard"] = $login;
        //                                    if ($use!='magic.summon.demon') $game["loc"][$player["loc"]][$id]["follow"] = $login;	// демон за вами не следует :-))
        //                                    else {$game["loc"][$player["loc"]][$id]["crim"]=1;docrim($login);} 	// демон crim и создавший его становится кримом. если не от кого защищать создавшего, то нападает на игроков, в том числе на создавшего :-)
        //                                    $game["loc"][$player["loc"]][$id]["time_owner"]=time()+rand(1*60,10*60);	// до 10 минут
        //                                }
        //                            }
        //                            else addjournal($login,"Заклинание сорвалось");
        //                        }
        //                        else addjournal($login,"Слишком слабый навык магии");
        //                    }
        //                    else addjournal($login,"Не хватает реагентов: ".$st);
        //                }
        //                else addjournal($login,"Недостаточно маны");
        //            }
        //            else {$list='all';}	// нужна цель для этого заклинания
        //            */
        //        }
        //        if (use.Substring(0, 6) == "skill.")
        //        {
        //            // использование скиллов
        //            /*
        //            $skills=split("\|",$player["skills"]);
        //            if ($use=='skill.meditation')
        //            {
        //                if (rand(0,100)<=$skills[5]*15 && $player["mana"]<$player["mana_max"])
        //                {$player["mana"]+=1; addjournal($login,"Мана +1");}
        //                else addjournal($login,"Медитация прервалась");
        //            }
        //            if ($use=='skill.animaltaming')
        //            {
        //                if (!$to) {$list='all';}
        //                else
        //                {
        //                    if (!isset($game["loc"][$player["loc"]][$to]) || substr($use,0,4)=="npc.") msg("<p>Некого приручать");
        //                    if ($game["loc"][$player["loc"]][$to]["tame"])
        //                    {
        //                        $tame=10*($skills[7]+1-$game["loc"][$player["loc"]][$to]["tame"]);
        //                        if ($tame>0 && $skills[20]>0)
        //                        {
        //                            if (rand(0,100)<=$tame) {$game["loc"][$player["loc"]][$to]["owner"]=$login; $game["loc"][$player["loc"]][$to]["follow"]=$login; $game["loc"][$player["loc"]][$to]["time_owner"]=time()+60+rand(0,$skills[20]*10*60); addjournal($login,"Вы приручили ".$game["loc"][$player["loc"]][$to]["title"]);} else addjournal($login,"Не получилось приручить ".$game["loc"][$player["loc"]][$to]["title"]);
        //                        }
        //                        else addjournal($login,"Слишком низкие навыки изучения и приручения животных");
        //                    }
        //                    else addjournal($login,"Это существо невозможно приручить");
        //                }
        //            }
        //            if ($use=='skill.steal')
        //            {
        //                if (!$to) {$list='all';}
        //                else
        //                {
        //                    if ($to==$login) msg("<p>Нельзя воровать у самого себя");
        //                    if (substr($to,0,4)=='npc.') msg("<p>Воровать можно только у других игроков");
        //                    if (!isset($game["loc"][$player["loc"]][$to]) || substr($use,0,5)=="user.") msg("<p>Не у кого воровать (можно только у игроков)");
        //                    $skillsto=split("\|",$game["loc"][$player["loc"]][$to]);
        //                    if (!$id)
        //                    {
        //                        // выведем список инвентори
        //                        if (rand(0,100)<10*($skills[1]+$skills[19]-$skillsto[18])) {
        //                            if (count($game["loc"][$player["loc"]][$to]["items"])==0) msg("<p>У этого игрока ничего нет");
        //                            $stmp="<p>Предметы:";
        //                            foreach(array_keys($game["loc"][$player["loc"]][$to]["items"]) as $i) {
        //                                $stmp.="<br/><a href=\"$PHP_SELF?sid=$sid&use=skill.steal&to=".$to."&id=".$i."\">";
        //                                $k=split("\|",$game["loc"][$player["loc"]][$to]["items"][$i]);
        //                                if ($k[1]>1) $stmp.=$k[0]." (".$k[1].")"; else $stmp.=$k[0];
        //                                $stmp.="</a>";
        //                                }
        //                            msg($stmp,$game["loc"][$player["loc"]][$to]["title"]);
        //                            } else {docrim($login); addjournal($login,"Вас заметили!"); addjournal($to,$player["title"]." пытался подглядеть в ваш рюкзак!");}
        //                    }
        //                    else
        //                    {
        //                        // воруем предмет $id, причем не спрашивая кол-во
        //                        $steal=10*($skills[1]+$skills[6]-3);
        //                        if ($steal>0)
        //                        {
        //                            if (rand(0,100)<10*($skills[1]+$skills[19]-$skillsto[18]*1.5))
        //                            {
        //                                if (!isset($game["loc"][$player["loc"]][$to]["items"][$id])) msg("<p>У игрока нет такого предмета");
        //                                if (isset($player["items"][$id]))
        //                                {
        //                                        $k=split("\|",$game["loc"][$player["loc"]][$to]["items"][$id]);
        //                                        $k1=split("\|",$player["items"][$id]);
        //                                        $k1[1]+=$k[1];
        //                                        $player["items"][$id]=implode("|",$k1);
        //                                }
        //                                else $player["items"][$id]=$game["loc"][$player["loc"]][$to]["items"][$id];
        //                                unset($game["loc"][$player["loc"]][$to]["items"][$id]);
        //                                calcparam($to);
        //                            }
        //                            else
        //                            {
        //                                docrim($login);
        //                                addjournal($login,"Вас застали за воровством!");
        //                                addjournal($to,$player["title"]." пытался вас обворовать!");
        //                            }
        //                        }
        //                        else addjournal($login,"Слишком низкие навыки воровства и подглядывания");
        //                    }//воруем предмет
        //                }
        //            }//skill.steal
        //            */
        //        }
        //    }
        //}

        //public class _1GameWorld
        //{
        //    //Константные массивы данных
        //    Dictionary<string, _1Item> items = null;
        //    Dictionary<string, _1Magic> magics = null;
        //    Dictionary<string, _1NPC> npcs = null;
        //    public Dictionary<string, Dictionary<string, string>> arr_speak = null;
        //    //Все что относится к миру
        //    public Dictionary<string, Dictionary<string, Object>> locations = null;
        //    public Dictionary<string, string> loc_desc = null;
        //    public Dictionary<string, string> loc_moves = null;
        //    //Игроки в мире
        //    public Dictionary<string, _1Player> players = null;
        //    //Последнее обновление мира
        //    public DateTime lastai;

        //    public _1GameWorld()
        //    {

        //    }

        //    public _1GameWorld(bool blanklocs)
        //    {
        //        items = new Dictionary<string, _1Item>();
        //        magics = new Dictionary<string, _1Magic>();
        //        npcs = new Dictionary<string, _1NPC>();
        //        arr_speak = new Dictionary<string, Dictionary<string, string>>();

        //        locations = new Dictionary<string, Dictionary<string, Object>>();
        //        loc_desc = new Dictionary<string, string>();
        //        loc_moves = new Dictionary<string, string>();

        //        players = new Dictionary<string, _1Player>();

        //        CreateConstItems();
        //        CreateConstNPCS();
        //        CreateMagic();
        //        InitializeLocations();
        //        if (!blanklocs) SpawnStartElements();
        //        CreateLocationDesc();
        //        CreateLocationMoves();
        //        CreateDialogs();

        //        lastai = DateTime.Now;
        //    }

        //    #region Процедуры создания
        //    /// <summary>
        //    /// Шаг 1 - Создание константных элементов
        //    /// </summary>
        //    public void CreateConstItems()
        //    {
        //        items["item.bottle.empty"] = new _1Item("бутылка", 1, 5, 0, 0);
        //        items["item.bottle.life"] = new _1Item("напиток жизни", 1, 30, 15, 0);
        //        items["item.bottle.life.great"] = new _1Item("напиток великой жизни", 1, 150, 25, 0);
        //        items["item.bottle.mana"] = new _1Item("напиток маны", 1, 40, 0, 10);
        //        items["item.bottle.mana.great"] = new _1Item("напиток великой маны", 1, 150, 0, 25);
        //        items["item.bottle.health"] = new _1Item("напиток исцеления", 1, 100, 15, 10);
        //        items["item.food.meat"] = new _1Item("мясо", 1, 10, 4, 0);
        //        items["item.food.meat.fried"] = new _1Item("жаренное мясо", 1, 25, 8, 0);
        //        items["item.food.apple"] = new _1Item("яблоко", 1, 4, 2, 0);
        //        items["item.food.sandwich"] = new _1Item("бутерброд", 1, 15, 5, 0);
        //        items["item.food.sausage"] = new _1Item("колбаса", 1, 20, 9, 0);
        //        items["item.food.cabbage"] = new _1Item("капуста", 1, 10, 1, 0);
        //        items["item.food.ham"] = new _1Item("окорок", 1, 30, 13, 0);
        //        items["item.food.bread"] = new _1Item("хлеб", 1, 16, 6, 0);
        //        items["item.food.mushroom"] = new _1Item("гриб", 1, 10, 2, 2);
        //        items["item.food.mushroom.dark"] = new _1Item("темный гриб", 1, 40, 5, 5);
        //        items["item.food.healherb"] = new _1Item("лечебная трава", 1, 130, 22, 0);
        //        items["item.food.fireroot"] = new _1Item("огненный корень", 1, 160, 0, 18);

        //        items["item.armor.body.leather"] = new _1Item("кожаная броня", 1, 150, 2);
        //        items["item.armor.hand.leather"] = new _1Item("кожаные поручи", 1, 70, 1);
        //        items["item.armor.leg.leather"] = new _1Item("кожаные поножи", 1, 80, 1);
        //        items["item.armor.head.leather"] = new _1Item("кожаный шлем", 1, 70, 1);
        //        items["item.armor.body.bone"] = new _1Item("костяная броня", 1, 250, 3);
        //        items["item.armor.hand.bone"] = new _1Item("костяные поручи", 1, 90, 1);
        //        items["item.armor.body.mail"] = new _1Item("кольчуга", 1, 450, 4);
        //        items["item.armor.body.full"] = new _1Item("латный доспех", 1, 600, 5);
        //        items["item.armor.body.plate"] = new _1Item("пластинчатый доспех", 1, 1000, 6);
        //        items["item.armor.shield.wood"] = new _1Item("деревянный щит", 1, 80, 1);
        //        items["item.armor.shield.copperwood"] = new _1Item("обитый щит", 1, 150, 2);
        //        items["item.armor.shield.bronze"] = new _1Item("бронзовый щит", 1, 250, 3);
        //        items["item.armor.shield.heavy"] = new _1Item("большой щит", 1, 400, 4);

        //        items["item.weapon.knife"] = new _1Item("нож", 1, 10, 1, 3, 0, 4, "ножом", "", "");
        //        items["item.weapon.knife.hunter"] = new _1Item("охотничий нож", 1, 15, 1, 5, 0, 4, "ножом", "", "");
        //        items["item.weapon.knife.boot"] = new _1Item("нож-засапожник", 1, 20, 2, 4, 0, 4, "ножом", "", "");
        //        items["item.weapon.knife.butcher"] = new _1Item("нож мясника", 1, 25, 2, 5, 0, 5, "ножом", "", "");
        //        items["item.weapon.knife.cutlass"] = new _1Item("тесак", 1, 18, 2, 5, 2, 5, "тесаком", "", "");
        //        items["item.weapon.dagger"] = new _1Item("кинжал", 1, 22, 1, 6, 0, 4, "кинжалом", "", "");
        //        items["item.weapon.kortik"] = new _1Item("кортик", 1, 20, 1, 5, 0, 4, "кортиком", "", "");
        //        items["item.weapon.shortsword"] = new _1Item("короткий меч", 1, 30, 3, 4, 0, 5, "мечом", "", "");
        //        items["item.weapon.broadsword"] = new _1Item("широкий меч", 1, 35, 3, 5, 0, 5, "мечом", "", "");
        //        items["item.weapon.halfsword"] = new _1Item("полуторный меч", 1, 40, 4, 5, 2, 5, "мечом", "", "");
        //        items["item.weapon.longsword"] = new _1Item("длинный меч", 1, 50, 5, 7, 3, 5, "мечом", "", "");
        //        items["item.weapon.twohandsword"] = new _1Item("двуручный меч", 1, 150, 5, 12, 4, 7, "мечом", "", "");
        //        items["item.weapon.sabre"] = new _1Item("сабля", 1, 70, 3, 8, 2, 5, "саблей", "", "");
        //        items["item.weapon.crookedsword"] = new _1Item("кривой меч", 1, 60, 4, 7, 2, 6, "мечом", "", "");
        //        items["item.weapon.yatagan"] = new _1Item("ятаган", 1, 50, 2, 6, 3, 6, "ятаганом", "", "");
        //        items["item.weapon.samuraysword"] = new _1Item("самурайский меч", 1, 200, 3, 10, 0, 5, "мечом", "", "");
        //        items["item.weapon.glade"] = new _1Item("шпага", 1, 40, 1, 4, 0, 5, "шпагой", "", "");
        //        items["item.weapon.flamberg"] = new _1Item("фламберг", 1, 170, 12, 15, 5, 9, "фламбергом", "", "");
        //        items["item.weapon.spear"] = new _1Item("копье", 1, 180, 6, 11, 3, 6, "копьем", "", "");
        //        items["item.weapon.halberd"] = new _1Item("алебарда", 1, 250, 11, 17, 4, 9, "алебардой", "", "");
        //        items["item.weapon.axe"] = new _1Item("топор", 1, 90, 6, 7, 3, 7, "топором", "", "");
        //        items["item.weapon.poleaxe"] = new _1Item("секира", 1, 210, 9, 15, 4, 8, "секирой", "", "");
        //        items["item.weapon.blackjack"] = new _1Item("дубина", 1, 15, 2, 3, 2, 6, "дубиной", "", "");
        //        items["item.weapon.moningstar"] = new _1Item("утренняя звезда", 1, 120, 5, 8, 3, 8, "утренней звездой", "", "");
        //        items["item.weapon.glefa"] = new _1Item("глефа", 1, 250, 7, 11, 2, 6, "глефой", "", "");
        //        items["item.weapon.ranged.stone"] = new _1Item("камень", 1, 2, 0, 1, 0, 5, "камнем", "item.weapon.ranged.stone", "камень");
        //        items["item.weapon.ranged.surricen"] = new _1Item("сюррикен", 1, 5, 0, 1, 0, 4, "сюррикеном", "item.weapon.surricen", "сюррикен");
        //        items["item.weapon.ranged.bumerang"] = new _1Item("бумеранг", 1, 30, 1, 4, 0, 5, "бумерангом", "", "");
        //        items["item.weapon.ranged.tomahawk"] = new _1Item("томагавк", 1, 15, 2, 3, 2, 5, "сюррикеном", "item.weapon.tomahawk", "томагавк");
        //        items["item.weapon.ranged.dropknife"] = new _1Item("метательный нож", 1, 10, 1, 3, 2, 4, "метательным ножом", "item.weapon.dropknife", "метательный нож");
        //        items["item.weapon.ranged.dropspear"] = new _1Item("метательное копье", 1, 100, 7, 17, 3, 7, "метательным копьем", "item.weapon.dropspear", "метательное копье");
        //        items["item.weapon.ranged.javelin"] = new _1Item("дротик", 1, 15, 1, 5, 0, 4, "дротиком", "item.weapon.javelin", "дротик");
        //        items["item.weapon.ranged.sling"] = new _1Item("праща", 1, 30, 1, 8, 0, 6, "пращой", "item.weapon.stone", "камень");
        //        items["item.weapon.ranged.bow"] = new _1Item("лук", 1, 30, 1, 6, 0, 5, "луком", "item.misc.arrow", "стрелы");
        //        items["item.weapon.ranged.shortbow"] = new _1Item("короткий лук", 1, 30, 1, 5, 0, 5, "луком", "item.misc.arrow", "стрелы");
        //        items["item.weapon.ranged.longbow"] = new _1Item("длинный лук", 1, 50, 3, 6, 2, 5, "луком", "item.misc.arrow", "стрелы");
        //        items["item.weapon.ranged.willowbow"] = new _1Item("ивовый лук", 1, 60, 4, 6, 2, 5, "луком", "item.misc.arrow", "стрелы");
        //        items["item.weapon.ranged.birchbow"] = new _1Item("березовый лук", 1, 90, 5, 8, 3, 6, "луком", "item.misc.arrow", "стрелы");
        //        items["item.weapon.ranged.hunterbow"] = new _1Item("охотничий лук", 1, 150, 5, 10, 3, 6, "луком", "item.misc.arrow", "стрелы");
        //        items["item.weapon.ranged.compoundbow"] = new _1Item("соcтавной лук", 1, 250, 8, 13, 4, 6, "луком", "item.misc.arrow", "стрелы");
        //        items["item.weapon.ranged.crossbow.light"] = new _1Item("легкий арбалет", 1, 150, 7, 10, 0, 7, "арбалетом", "item.misc.bolt", "болты");
        //        items["item.weapon.ranged.crossbow.middle"] = new _1Item("средний арбалет", 1, 230, 10, 16, 3, 6, "арбалетом", "item.misc.bolt", "болты");
        //        items["item.weapon.ranged.crossbow.hard"] = new _1Item("тяжелый арбалет", 1, 280, 14, 17, 4, 9, "арбалетом", "item.misc.bolt", "болты");

        //        items["item.misc.money"] = new _1Item("монеты", 1, 1);
        //        items["item.misc.arrow"] = new _1Item("стрелы", 1, 1);
        //        items["item.misc.bolt"] = new _1Item("болты", 1, 1);
        //        items["item.hunter.bone"] = new _1Item("кость", 1, 5);
        //        items["item.hunter.skin"] = new _1Item("шкура", 1, 5);
        //        items["item.hunter.skin.wolf"] = new _1Item("шкура волка", 1, 10);
        //        items["item.hunter.skin.deer"] = new _1Item("шкура оленя", 1, 7);
        //        items["item.hunter.skin.sheep"] = new _1Item("шкура овцы", 1, 6);
        //        items["item.hunter.skin.troll"] = new _1Item("шкура тролля", 1, 70);
        //        items["item.hunter.skin.ogr"] = new _1Item("шкура огра", 1, 50);
        //        items["item.hunter.feather"] = new _1Item("перо", 1, 2);
        //        items["item.hunter.horn"] = new _1Item("рога", 1, 10);
        //        items["item.hunter.kop"] = new _1Item("копыта", 1, 8);
        //        items["item.hunter.claw"] = new _1Item("когти", 1, 5);
        //        items["item.hunter.teeths"] = new _1Item("клыки", 1, 8);
        //        items["item.crystal.adamant"] = new _1Item("алмаз", 1, 300);
        //        items["item.crystal.emerald"] = new _1Item("изумруд", 1, 200);
        //        items["item.crystal.ruby"] = new _1Item("рубин", 1, 150);
        //        items["item.crystal.amber"] = new _1Item("янтарь", 1, 100);
        //        items["item.ring.gold"] = new _1Item("золотое кольцо", 1, 70);
        //        items["item.ring.silver"] = new _1Item("серебрянное кольцо", 1, 50);
        //        items["item.ring.bronze"] = new _1Item("бронзовое кольцо", 1, 30);
        //        items["item.ressurect"] = new _1Item("камень воскрешения", 1, 0);
        //        items["item.scroll.war.arrow"] = new _1Item("свиток Магическая стрела", 1, 30);
        //        items["item.scroll.war.holyarrow"] = new _1Item("свиток Святая стрела", 1, 45);
        //        items["item.scroll.war.firearrow"] = new _1Item("свиток Огненная стрела", 1, 0);
        //        items["item.scroll.war.icefirst"] = new _1Item("свиток Ледяной кулак", 1, 50);
        //        items["item.scroll.war.firebolt"] = new _1Item("свиток Огненный столб", 1, 55);
        //        items["item.scroll.war.iceray"] = new _1Item("свиток Ледяной луч", 1, 60);
        //        items["item.scroll.war.firestreem"] = new _1Item("свиток Струя пламени", 1, 70);
        //        items["item.scroll.war.lighting"] = new _1Item("свиток Молния", 1, 35);
        //        items["item.scroll.all.watergross"] = new _1Item("свиток Водяной вал", 1, 60);
        //        items["item.scroll.all.godanger"] = new _1Item("свиток Гнев богов", 1, 80);
        //        items["item.scroll.all.earthquake"] = new _1Item("свиток Землетрясение", 1, 80);
        //        items["item.scroll.createfood"] = new _1Item("свиток Создать еду", 1, 20);
        //        items["item.scroll.charm"] = new _1Item("свиток Зачаровать", 1, 45);
        //        items["item.scroll.charmenemy"] = new _1Item("свиток Привлечь", 1, 70);
        //        items["item.scroll.peace"] = new _1Item("свиток Усмирить", 1, 60);
        //        items["item.scroll.silence"] = new _1Item("свиток Тишина", 1, 100);
        //        items["item.scroll.maddnes"] = new _1Item("свиток Безумие", 1, 150);
        //        items["item.scroll.summon.wolf"] = new _1Item("свиток Призвать волка", 1, 45);
        //        items["item.scroll.summon.skeleton"] = new _1Item("свиток Призвать скелета", 1, 55);
        //        items["item.scroll.summon.golem"] = new _1Item("свиток Призвать голема", 1, 60);
        //        items["item.scroll.summon.demon"] = new _1Item("свиток Призвать демона", 1, 80);
        //        items["item.scroll.heal"] = new _1Item("свиток Лечение", 1, 20);
        //        items["item.scroll.heal.great"] = new _1Item("свиток Исцеление", 1, 40);
        //        items["item.scroll.ressurect"] = new _1Item("свиток Воскрешение", 1, 200);
        //        items["item.scroll.mark"] = new _1Item("свиток Пометить", 1, 35);
        //        items["item.scroll.recall"] = new _1Item("свиток Возвращение", 1, 25);
        //        items["item.rune.war.arrow"] = new _1Item("руна Магическая стрела", 1, 200);
        //        items["item.rune.war.holyarrow"] = new _1Item("руна Святая стрела", 1, 250);
        //        items["item.rune.war.firearrow"] = new _1Item("руна Огненная стрела", 1, 300);
        //        items["item.rune.war.icefirst"] = new _1Item("руна Ледяной кулак", 1, 350);
        //        items["item.rune.war.firebolt"] = new _1Item("руна Огненный столб", 1, 400);
        //        items["item.rune.war.iceray"] = new _1Item("руна Ледяной луч", 1, 450);
        //        items["item.rune.war.firestreem"] = new _1Item("руна Струя пламени", 1, 500);
        //        items["item.rune.war.lighting"] = new _1Item("руна Молния", 1, 300);
        //        items["item.rune.all.watergross"] = new _1Item("руна Водяной вал", 1, 500);
        //        items["item.rune.all.godanger"] = new _1Item("руна Гнев богов", 1, 600);
        //        items["item.rune.all.earthquake"] = new _1Item("руна Землетрясение", 1, 650);
        //        items["item.rune.createfood"] = new _1Item("руна Создать еду", 1, 400);
        //        items["item.rune.charm"] = new _1Item("руна Зачаровать", 1, 300);
        //        items["item.rune.charmenemy"] = new _1Item("руна Привлечь", 1, 500);
        //        items["item.rune.peace"] = new _1Item("руна Усмирить", 1, 400);
        //        items["item.rune.silence"] = new _1Item("руна Тишина", 1, 450);
        //        items["item.rune.maddnes"] = new _1Item("руна Безумие", 1, 800);
        //        items["item.rune.summon.wolf"] = new _1Item("руна Призвать волка", 1, 700);
        //        items["item.rune.summon.skeleton"] = new _1Item("руна Призвать скелета", 1, 800);
        //        items["item.rune.summon.golem"] = new _1Item("руна Призвать голема", 1, 900);
        //        items["item.rune.summon.demon"] = new _1Item("руна Призвать демона", 1, 1000);
        //        items["item.rune.heal"] = new _1Item("руна Лечение", 1, 600);
        //        items["item.rune.heal.great"] = new _1Item("руна Исцеление", 1, 800);
        //        items["item.rune.ressurect"] = new _1Item("руна Воскрешение", 1, 800);
        //        items["item.rune.mark"] = new _1Item("руна Пометить", 1, 600);
        //        items["item.rune.recall"] = new _1Item("руна Возвращение", 1, 500);
        //        items["item.recallrune.empty"] = new _1Item("руна перемещения", 1, 100);
        //        items["item.magic.sulphur"] = new _1Item("сера", 1, 4);
        //        items["item.magic.coal"] = new _1Item("уголь", 1, 2);
        //        items["item.magic.silk"] = new _1Item("паутина", 1, 4);
        //        items["item.magic.pearl"] = new _1Item("жемчуг", 1, 10);
        //        items["item.magic.wormwood"] = new _1Item("полынь", 1, 2);
        //        items["item.magic.moss"] = new _1Item("мох", 1, 2);
        //    }

        //    /// <summary>
        //    /// Шаг 2 - Создание константных NPC
        //    /// </summary>
        //    public void CreateConstNPCS()
        //    {
        //        //animals
        //        npcs["npc.summon.wolf"] = new _1NPC("волк", 20, 20, "70|4|11|5|0|0|5|0|0|0|0|0|зубами|0||");

        //        npcs["npc.summon.skeleton"] = new _1NPC("скелет", 30, 30, "65|5|12|6|0|0|10|0|0|0|0|0||0||");

        //        npcs["npc.summon.golem"] = new _1NPC("голем", 50, 50, "90|8|14|7|0|5|10|0|0|30|50|4||0||");

        //        npcs["npc.summon.demon"] = new _1NPC("демон", 80, 80, "95|9|18|7|0|3|10|0|0|20|70|8||0||");

        //        npcs["npc.animal.deer"] = new _1NPC("олень", 20, 20, "70|2|6|4|0|0|5|0|0|0|0|0|рогами|6||");
        //        npcs["npc.animal.deer"].tame = 1;
        //        npcs["npc.animal.deer"].osvej["item.food.meat"] = "мясо|3|10|4:0:";
        //        npcs["npc.animal.deer"].osvej["item.hunter.skin.deer"] = "шкура оленя|1|7";
        //        npcs["npc.animal.deer"].osvej["item.hunter.horn"] = "рога|1|10";

        //        npcs["npc.animal.sheep"] = new _1NPC("овца", 7, 7, "60|0|3|6|0|0|5|0|0|0|0|0|копытами|2||");
        //        npcs["npc.animal.sheep"].tame = 1;
        //        npcs["npc.animal.sheep"].osvej["item.food.meat"] = "мясо|1|10|4:0:";
        //        npcs["npc.animal.sheep"].osvej["item.hunter.skin.sheep"] = "шкура овцы|1|6";
        //        npcs["npc.animal.sheep"].osvej["item.hunter.kop"] = "копыта|1|8";

        //        npcs["npc.animal.cow"] = new _1NPC("корова", 7, 7, "70|0|6|8|0|0|5|0|0|0|0|0||5||");
        //        npcs["npc.animal.cow"].tame = 1;
        //        npcs["npc.animal.cow"].osvej["item.food.meat"] = "мясо|4|10|4:0:";
        //        npcs["npc.animal.cow"].osvej["item.hunter.kop"] = "копыта|1|8";

        //        npcs["npc.animal.hen"] = new _1NPC("курица", 2, 2, "60|0|3|4|0|0|5|0|0|0|0|0|клювом|1||");
        //        npcs["npc.animal.hen"].tame = 1;
        //        npcs["npc.animal.hen"].osvej["item.food.meat"] = "мясо|1|10|4:0:";
        //        npcs["npc.animal.hen"].osvej["item.hunter.feather"] = "перо|4|2";

        //        npcs["npc.animal.pig"] = new _1NPC("свинья", 4, 4, "40|1|5|4|0|0|5|0|0|0|0|0||2||");
        //        npcs["npc.animal.pig"].tame = 1;
        //        npcs["npc.animal.pig"].osvej["item.food.meat"] = "мясо|2|10|4:0";

        //        npcs["npc.animal.wildboar"] = new _1NPC("кабан", 12, 12, "80|4|6|6|0|0|5|0|0|0|0|0||4||");
        //        npcs["npc.animal.wildboar"].tame = 2;
        //        npcs["npc.animal.wildboar"].osvej["item.food.meat"] = "мясо|1|10|4:0:";
        //        npcs["npc.animal.wildboar"].osvej["item.hunter.skin"] = "шкура|1|5";

        //        npcs["npc.animal.dove"] = new _1NPC("голубь", 1, 1, "20|1|5|4|0|0|5|0|0|0|0|0|клювом|1||");
        //        npcs["npc.animal.dove"].osvej["item.hunter.feather"] = "перо|2|2";

        //        npcs["npc.animal.crow"] = new _1NPC("ворона", 4, 4, "80|0|3|4|0|0|5|0|0|0|0|0|клювом|2||");
        //        npcs["npc.animal.crow"].osvej["item.hunter.feather"] = "перо|3|2";

        //        npcs["npc.animal.hare"] = new _1NPC("заяц", 5, 5, "50|0|1|4|0|0|5|0|0|0|0|0||2||");
        //        npcs["npc.animal.hare"].tame = 1;
        //        npcs["npc.animal.hare"].osvej["item.food.meat"] = "мясо|2|10|4:0:";

        //        npcs["npc.animal.fox"] = new _1NPC("лиса", 15, 15, "50|3|5|4|0|0|5|0|0|0|0|0||5||");
        //        npcs["npc.animal.fox"].tame = 2;
        //        npcs["npc.animal.fox"].osvej["item.food.meat"] = "мясо|1|10|4:0:";
        //        npcs["npc.animal.fox"].osvej["item.hunter.skin"] = "шкура|1|5";
        //        npcs["npc.animal.fox"].osvej["item.hunter.claw"] = "когти|1|5";

        //        npcs["npc.animal.dog"] = new _1NPC("собака", 28, 28, "80|6|9|4|0|0|20|0|0|0|0|0|зубами|8||");
        //        npcs["npc.animal.dog"].tame = 1;
        //        npcs["npc.animal.dog"].osvej["item.food.meat"] = "мясо|1|10|4:0:";
        //        npcs["npc.animal.dog"].osvej["item.hunter.skin"] = "шкура|1|5";
        //        npcs["npc.animal.dog"].osvej["item.hunter.teeths"] = "клыки|1|8";

        //        npcs["npc.crim.rat"] = new _1NPC("крыса", 6, 6, "80|0|4|6|0|0|5|0|0|0|0|0||4||");

        //        npcs["npc.crim.snake"] = new _1NPC("змея", 18, 18, "90|4|8|5|0|0|5|0|0|0|0|0||12||");

        //        npcs["npc.crim.wolf"] = new _1NPC("волк", 25, 25, "70|4|11|5|0|0|5|0|0|0|0|0|зубами|16||");
        //        npcs["npc.crim.wolf"].tame = 1;
        //        npcs["npc.crim.wolf"].osvej["item.food.meat"] = "мясо|1|10|4:0:";
        //        npcs["npc.crim.wolf"].osvej["item.hunter.skin.wolf"] = "шкура волка|1|10";
        //        npcs["npc.crim.wolf"].osvej["item.hunter.teeths"] = "клыки|1|8";

        //        npcs["npc.crim.bear"] = new _1NPC("медведь", 45, 45, "70|8|18|10|0|0|5|0|0|0|0|0|зубами|22||");
        //        npcs["npc.crim.bear"].tame = 3;
        //        npcs["npc.crim.bear"].osvej["item.food.meat"] = "мясо|2|10|4:0:";
        //        npcs["npc.crim.bear"].osvej["item.hunter.skin"] = "шкура|1|5";
        //        npcs["npc.crim.bear"].osvej["item.hunter.claw"] = "когти|1|5";

        //        npcs["npc.crim.zombie"] = new _1NPC("зомби", 14, 14, "65|2|6|8|0|0|5|0|0|0|0|0||12||");
        //        npcs["npc.crim.zombie"].items["item.misc.money"] = "монеты|8|1";

        //        npcs["npc.crim.skeleton"] = new _1NPC("скелет", 20, 20, "65|4|12|6|0|0|10|0|0|0|0|0||21||");
        //        npcs["npc.crim.skeleton"].items["item.misc.money"] = "монеты|12|1";
        //        npcs["npc.crim.skeleton"].osvej["item.hunter.bone"] = "кость|1|5";

        //        npcs["npc.crim.warriorskeleton"] = new _1NPC("воин-скелет", 35, 35, "80|6|18|6|0|0|10|20|2|0|0|0|мечом|25||");
        //        npcs["npc.crim.warriorskeleton"].items["item.misc.money"] = "монеты|14|1";
        //        npcs["npc.crim.warriorskeleton"].items["item.armor.shield.wood"] = "деревянный щит|1|80|1";
        //        npcs["npc.crim.warriorskeleton"].items["item.weapon.shortsword"] = "короткий меч|1|30|3|4|0|5|мечом||";
        //        npcs["npc.crim.warriorskeleton"].equip["arm"] = "item.weapon.shortsword";
        //        npcs["npc.crim.warriorskeleton"].equip["shield"] = "item.armor.shield.wood";
        //        npcs["npc.crim.warriorskeleton"].osvej["item.hunter.bone"] = "кость|2|5";

        //        npcs["npc.crim.vampire"] = new _1NPC("вампир", 70, 70, "80|9|18|7|0|0|30|0|0|0|0|0||35||");
        //        npcs["npc.crim.vampire"].items["item.misc.money"] = "монеты|22|1";
        //        npcs["npc.crim.vampire"].osvej["item.hunter.teeths"] = "клыки|1|8";

        //        npcs["npc.crim.shadow"] = new _1NPC("тень", 16, 26, "70|3|14|5|0|0|20|0|0|0|0|0||26||");
        //        npcs["npc.crim.shadow"].items["item.misc.money"] = "монеты|18|1";

        //        npcs["npc.crim.witch"] = new _1NPC("ведьма", 12, 12, "70|2|8|6|0|0|10|0|0|20|0|0||12||");
        //        npcs["npc.crim.witch"].items["item.misc.money"] = "монеты|14|1";

        //        npcs["npc.crim.orc"] = new _1NPC("орк", 28, 28, "80|4|12|7|0|1|10|0|0|0|0|0||18||");
        //        npcs["npc.crim.orc"].items["item.misc.money"] = "монеты|25|1";

        //        npcs["npc.crim.orcwarrior"] = new _1NPC("орк-воин", 40, 40, "80|8|18|7|0|3|10|10|4|0|0|0|мечом|30||");
        //        npcs["npc.crim.orcwarrior"].items["item.misc.money"] = "монеты|30|1";
        //        npcs["npc.crim.orcwarrior"].items["item.weapon.halfsword"] = "полуторный меч|1|40|4|5|2|5|мечом||";
        //        npcs["npc.crim.orcwarrior"].equip["arm"] = "item.weapon.halfsword";

        //        npcs["npc.crim.ogr"] = new _1NPC("огр", 90, 90, "80|12|22|8|0|2|5|0|0|10|0|0||40||");
        //        npcs["npc.crim.ogr"].items["item.misc.money"] = "монеты|30|1";
        //        npcs["npc.crim.ogr"].osvej["item.hunter.skin.ogr"] = "шкура огра|1|50";

        //        npcs["npc.crim.ogrwarrior"] = new _1NPC("огр-воин", 100, 100, "80|16|24|8|0|2|5|0|0|10|0|0|дубиной|40||");
        //        npcs["npc.crim.ogrwarrior"].items["item.misc.money"] = "монеты|50|1";
        //        npcs["npc.crim.ogrwarrior"].items["item.weapon.crookedsword"] = "кривой меч|1|60|4|7|2|6|мечом||";
        //        npcs["npc.crim.ogrwarrior"].equip["arm"] = "item.weapon.crookedsword";
        //        npcs["npc.crim.ogrwarrior"].osvej["item.hunter.skin.ogr"] = "шкура огра|1|50";

        //        npcs["npc.crim.troll"] = new _1NPC("тролль", 120, 120, "75|15|25|9|0|6|5|0|0|0|40|4||60||");
        //        npcs["npc.crim.troll"].items["item.misc.money"] = "монеты|75|1";
        //        npcs["npc.crim.troll"].osvej["item.hunter.skin.troll"] = "шкура тролля|1|70";

        //        //humans
        //        npcs["npc.guard"] = new _1NPC("Стража", 1000, 1000, "100|100|100|4|0|100|100|0|0|100|0|0|алебардой|0||", "npc.guard");

        //        npcs["npc.healer"] = new _1NPC("Джозеф [лекарь]", 1000, 1000, "80|3|6|4|0|0|10|0|0|0|0|0|врукопашную|0||", "npc.healer");
        //        npcs["npc.healer"].healer = true;

        //        npcs["npc.trader"] = new _1NPC("Торговец", 40, 40, "60|4|8|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.trader");

        //        npcs["npc.bankir"] = new _1NPC("Лукас [банкир]", 1000, 1000, "60|3|6|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.bankir");
        //        npcs["npc.bankir"].bankir = true;

        //        npcs["npc.beginner"] = new _1NPC("Привратник Уин", 1000, 1000, "100|100|100|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.beginner");
        //        npcs["npc.Gant"] = new _1NPC("Гант", 1000, 1000, "80|12|15|4|0|0|10|30|4|0|0|0|мечом|0||", "npc.Gant");
        //        npcs["npc.LordHagen"] = new _1NPC("Лорд Хаген", 1000, 1000, "80|14|18|4|0|0|30|0|0|0|0|0|мечом|0||", "npc.LordHagen");
        //        npcs["npc.Rene"] = new _1NPC("Рене", 1000, 1000, "80|8|10|4|0|0|20|0|0|0|0|0|мечом|0||", "npc.Rene");
        //        npcs["npc.Silvestr"] = new _1NPC("Сильвестр", 1000, 1000, "60|2|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Silvestr");
        //        npcs["npc.Stouns"] = new _1NPC("Стоунс", 1000, 1000, "70|4|7|4|0|0|10|0|0|0|0|0|врукопашную|0||", "npc.Stouns");
        //        npcs["npc.KantaresNovobranec"] = new _1NPC("Ученик", 1000, 1000, "65|5|7|4|0|0|5|0|0|0|0|0|мечом|0||", "npc.KantaresNovobranec");
        //        npcs["npc.Kantares"] = new _1NPC("Кантарес", 1000, 1000, "95|8|12|4|0|0|30|0|0|0|0|0|мечом|0||", "npc.Kantares");
        //        npcs["npc.Hans"] = new _1NPC("Ханс", 1000, 1000, "70|4|18|4|0|0|30|0|0|0|0|0|луком|0||", "npc.Hans");
        //        npcs["npc.Ded"] = new _1NPC("Старый дед", 1000, 1000, "50|0|3|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Ded");
        //        npcs["npc.Malchugan"] = new _1NPC("Мальчуган", 1000, 1000, "70|0|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Malchugan");
        //        npcs["npc.Mahmet"] = new _1NPC("Махмет [торговец]", 1000, 1000, "60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Mahmet");
        //        npcs["npc.Julien"] = new _1NPC("Жульен [торговец]", 1000, 1000, "60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Julien");
        //        npcs["npc.Goston"] = new _1NPC("Гостон [торговец]", 1000, 1000, "60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Goston");
        //        npcs["npc.Raksha"] = new _1NPC("Ракша [торговка]", 1000, 1000, "60|1|3|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Goston");
        //        npcs["npc.Arant"] = new _1NPC("Арант [торговец]", 1000, 1000, "60|6|9|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Arant");
        //        npcs["npc.Milta"] = new _1NPC("Милта [торговец]", 1000, 1000, "60|6|9|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Milta");
        //        npcs["npc.Frederik"] = new _1NPC("Фредерик [торговец]", 1000, 1000, "60|2|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Frederik");
        //        npcs["npc.Surri"] = new _1NPC("Сурри", 1000, 1000, "60|1|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Surri");
        //        npcs["npc.Sirs"] = new _1NPC("Сирс", 1000, 1000, "60|1|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Sirs");
        //        npcs["npc.Markus"] = new _1NPC("Маркус", 1000, 1000, "90|7|9|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Markus");
        //        npcs["npc.Sloven"] = new _1NPC("Словен [торговец]", 1000, 1000, "60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Sloven");
        //        npcs["npc.Yan"] = new _1NPC("Ян [охотник]", 1000, 1000, "60|4|13|4|0|0|5|0|0|0|0|0|луком|0||", "npc.Yan");
        //        npcs["npc.Leksli"] = new _1NPC("Лексли", 1000, 1000, "80|4|7|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Leksli");
        //        npcs["npc.Batist"] = new _1NPC("Батист", 1000, 1000, "70|3|6|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Batist");
        //        npcs["npc.Djon"] = new _1NPC("Джон", 1000, 1000, "60|0|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Djon");
        //        npcs["npc.Gregg"] = new _1NPC("Грегг", 1000, 1000, "60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Gregg");
        //        npcs["npc.Stoun"] = new _1NPC("Стоун", 1000, 1000, "60|3|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Stoun");
        //        npcs["npc.Silvio"] = new _1NPC("Сильвио [торговец]", 1000, 1000, "60|3|9|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Silvio");
        //        npcs["npc.Franchesko"] = new _1NPC("Франческо", 1000, 1000, "60|3|9|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Franchesko");
        //        npcs["npc.Djoshua"] = new _1NPC("Джошуа [торговец]", 1000, 1000, "40|1|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Djoshua");
        //        npcs["npc.Klavdius"] = new _1NPC("Клавдиус", 1000, 1000, "40|1|4|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Klavdius");
        //        npcs["npc.Antonio"] = new _1NPC("Антонио", 1000, 1000, "60|4|9|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Antonio");
        //        npcs["npc.Serpent"] = new _1NPC("Серпент", 1000, 1000, "60|4|9|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Serpent");
        //        npcs["npc.Milton"] = new _1NPC("Мильтон", 1000, 1000, "60|4|9|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Milton");
        //        npcs["npc.Raks"] = new _1NPC("Ракс [кузнец]", 1000, 1000, "80|8|11|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Raks");
        //        npcs["npc.Silt"] = new _1NPC("Силт [торговец]", 1000, 1000, "80|5|6|4|0|0|5|0|0|0|0|0|врукопашную|0||", "npc.Silt");
        //        npcs["npc.Plant"] = new _1NPC("Плант [торговец]", 1000, 1000, "80|9|13|4|0|0|5|0|0|0|0|0|мечом|0||", "npc.Plant");
        //    }

        //    /// <summary>
        //    /// Шаг 3 - Создание константной магии
        //    /// </summary>
        //    public void CreateMagic()
        //    {
        //        magics["magic.war.arrow"] = new _1Magic("Магическая стрела", 5, 1, "In Ost", 4, 10, true, false, 2);
        //        magics["magic.war.arrow"].need.Add("item.magic.silk|1|паутина");
        //        magics["magic.war.arrow"].need.Add("item.magic.moss|1|мох");
        //        magics["magic.war.holyarrow"] = new _1Magic("Святая стрела", 3, 1, "Blast Kosta Nor", 5, 8, true, true, 2);
        //        magics["magic.war.holyarrow"].need.Add("item.magic.wormwood|2|полынь");
        //        magics["magic.war.firearrow"] = new _1Magic("Огненная стрела", 8, 2, "Sist Ar", 7, 12, true, false, 2);
        //        magics["magic.war.firearrow"].need.Add("item.magic.coal|1|уголь");
        //        magics["magic.war.firearrow"].need.Add("item.magic.sulphur|1|сера");
        //        magics["magic.war.firearrow"].need.Add("item.magic.moss|1|мох");
        //        magics["magic.war.icefirst"] = new _1Magic("Ледяной кулак", 10, 2, "Mar Irn Las", 10, 15, true, false, 3);
        //        magics["magic.war.icefirst"].need.Add("item.magic.silk|1|паутина");
        //        magics["magic.war.icefirst"].need.Add("item.magic.wormwood|1|полынь");
        //        magics["magic.war.icefirst"].need.Add("item.magic.moss|1|мох");
        //        magics["magic.war.firebolt"] = new _1Magic("Огненный столб", 13, 3, "Ort Fa Las", 12, 16, true, false, 4);
        //        magics["magic.war.firebolt"].need.Add("item.magic.coal|1|уголь");
        //        magics["magic.war.firebolt"].need.Add("item.magic.sulphur|1|сера");
        //        magics["magic.war.firebolt"].need.Add("item.magic.moss|1|мох");
        //        magics["magic.war.iceray"] = new _1Magic("Ледяной луч", 18, 4, "Mista Blast", 16, 25, true, false, 4);
        //        magics["magic.war.iceray"].need.Add("item.magic.pearl|1|жемчуг");
        //        magics["magic.war.iceray"].need.Add("item.magic.moss|1|мох");
        //        magics["magic.war.iceray"].need.Add("item.magic.wormwood|1|полынь");
        //        magics["magic.war.firestreem"] = new _1Magic("Струя пламени", 22, 4, "Farta Luz Senn", 22, 32, true, false, 5);
        //        magics["magic.war.firestreem"].need.Add("item.magic.coal|1|уголь");
        //        magics["magic.war.firestreem"].need.Add("item.magic.sulphur|1|сера");
        //        magics["magic.war.lighting"] = new _1Magic("Молния", 11, 3, "Las Ka Sant", 1, 28, true, false, 3);
        //        magics["magic.war.lighting"].need.Add("item.magic.pearl|1|жемчуг");
        //        magics["magic.war.lighting"].need.Add("item.magic.silk|1|паутина");
        //        magics["magic.war.lighting"].need.Add("item.magic.wormwood|1|полынь");
        //        magics["magic.all.watergross"] = new _1Magic("Водяной вал", 24, 4, "Vlinta Suento Borta", 8, 22, false, false, 5);
        //        magics["magic.all.watergross"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.all.watergross"].need.Add("item.magic.moss:2:мох");
        //        magics["magic.all.godanger"] = new _1Magic("Гнев богов", 18, 5, "Kal Rans Bet", 16, 26, false, false, 6);
        //        magics["magic.all.godanger"].need.Add("item.magic.coal:1:уголь");
        //        magics["magic.all.godanger"].need.Add("item.magic.wormwood:1:полынь");
        //        magics["magic.all.godanger"].need.Add("item.magic.sulphur:1:сера");
        //        magics["magic.all.earthquake"] = new _1Magic("Землетрясение", 32, 5, "Swar Di Otr", 18, 28, false, false, 6);
        //        magics["magic.all.earthquake"].need.Add("item.magic.coal:1:уголь");
        //        magics["magic.all.earthquake"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.all.earthquake"].need.Add("item.magic.wormwood:1:полынь");
        //        magics["magic.all.earthquake"].need.Add("item.magic.sulphur:1:сера");
        //        magics["magic.createfood"] = new _1Magic("Создать еду", 12, 1, "Manm Kris", 0, 0, false, false, 2);
        //        magics["magic.createfood"].need.Add("item.magic.coal:1:уголь");
        //        magics["magic.createfood"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.charm"] = new _1Magic("Зачаровать", 8, 2, "Silwa Ruun", 0, 0, true, false, 3);
        //        magics["magic.charm"].need.Add("item.magic.pearl:1:жемчуг");
        //        magics["magic.charm"].need.Add("item.magic.silk:2:паутина");
        //        magics["magic.charmenemy"] = new _1Magic("Привлечь", 18, 3, "Diswal Ruun", 0, 0, true, false, 4);
        //        magics["magic.charmenemy"].need.Add("item.magic.silk:2:паутина");
        //        magics["magic.charmenemy"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.peace"] = new _1Magic("Усмирить", 14, 2, "Sunwa Marr", 0, 0, true, false, 3);
        //        magics["magic.peace"].need.Add("item.magic.coal:1:уголь");
        //        magics["magic.peace"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.peace"].need.Add("item.magic.wormwood:1:полынь");
        //        magics["magic.silence"] = new _1Magic("Тишина", 22, 4, "Maer Dis Wu An", 0, 0, false, false, 5);
        //        magics["magic.silence"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.silence"].need.Add("item.magic.moss:2:мох");
        //        magics["magic.maddnes"] = new _1Magic("Безумие", 28, 5, "Baar Ganta Kar", 0, 0, false, false, 5);
        //        magics["magic.maddnes"].need.Add("item.magic.sulphur|2|сера");
        //        magics["magic.maddnes"].need.Add("item.magic.moss:2:мох");
        //        magics["magic.maddnes"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.summon.wolf"] = new _1Magic("Призвать волка", 10, 1, "Suent Via", 0, 0, false, false, 3);
        //        magics["magic.summon.wolf"].need.Add("item.magic.coal:1:уголь");
        //        magics["magic.summon.wolf"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.summon.wolf"].need.Add("item.magic.pearl:1:жемчуг");
        //        magics["magic.summon.wolf"].need.Add("item.magic.wormwood:1:полынь");
        //        magics["magic.summon.skeleton"] = new _1Magic("Призвать скелета", 12, 1, "Suent Mart", 0, 0, false, false, 3);
        //        magics["magic.summon.skeleton"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.summon.skeleton"].need.Add("item.magic.moss:2:мох");
        //        magics["magic.summon.skeleton"].need.Add("item.magic.pearl:1:жемчуг");
        //        magics["magic.summon.golem"] = new _1Magic("Призвать голема", 14, 2, "Suent Dal Wan", 0, 0, false, false, 4);
        //        magics["magic.summon.golem"].need.Add("item.magic.pearl:1:жемчуг");
        //        magics["magic.summon.golem"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.summon.golem"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.summon.golem"].need.Add("item.magic.wormwood:1:полынь");
        //        magics["magic.summon.demon"] = new _1Magic("Призвать демона", 16, 3, "Suelt Kas Valla", 0, 0, false, false, 4);
        //        magics["magic.summon.demon"].need.Add("item.magic.pearl:1:жемчуг");
        //        magics["magic.summon.demon"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.summon.demon"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.summon.demon"].need.Add("item.magic.sulphur:2:сера");
        //        magics["magic.heal"] = new _1Magic("Лечение", 8, 1, "Suelt Kas Valla", 6, 16, true, false, 2);
        //        magics["magic.heal"].need.Add("item.magic.wormwood:1:полынь");
        //        magics["magic.heal"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.heal.great"] = new _1Magic("Исцеление", 12, 3, "Suelt Kas Valla", 12, 24, true, false, 3);
        //        magics["magic.heal.great"].need.Add("item.magic.wormwood:1:полынь");
        //        magics["magic.heal.great"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.heal.great"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.ressurect"] = new _1Magic("Воскрешение", 22, 6, "Suelt Kas Valla", 0, 0, true, false, 5);
        //        magics["magic.ressurect"].need.Add("item.magic.coal:1:уголь");
        //        magics["magic.ressurect"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.ressurect"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.ressurect"].need.Add("item.magic.wormwood:1:полынь");
        //        magics["magic.ressurect"].need.Add("item.magic.sulphur:1:сера");
        //        magics["magic.ressurect"].need.Add("item.magic.pearl:1:жемчуг");
        //        magics["magic.mark"] = new _1Magic("Пометить", 16, 3, "Ir Sin Mar", 0, 0, true, false, 4);
        //        magics["magic.mark"].need.Add("item.magic.pearl:1:жемчуг");
        //        magics["magic.mark"].need.Add("item.magic.moss:1:мох");
        //        magics["magic.mark"].need.Add("item.magic.sulphur:1:сера");
        //        magics["magic.recall"] = new _1Magic("Возвращение", 6, 1, "Ir As", 0, 0, true, false, 2);
        //        magics["magic.recall"].need.Add("item.magic.coal:1:уголь");
        //        magics["magic.recall"].need.Add("item.magic.silk:1:паутина");
        //        magics["magic.recall"].need.Add("item.magic.wormwood:1:полынь");
        //    }

        //    /// <summary>
        //    /// Шаг 4 - Инициализация всех локаций мира
        //    /// </summary>
        //    public void InitializeLocations()
        //    {
        //        locations["loc.0"] = new Dictionary<string, Object>();
        //        locations["loc.lek1"] = new Dictionary<string, Object>();
        //        locations["loc.lek"] = new Dictionary<string, Object>();
        //        locations["loc.drag1"] = new Dictionary<string, Object>();
        //        locations["loc.drag"] = new Dictionary<string, Object>();
        //        locations["loc.sklad1"] = new Dictionary<string, Object>();
        //        locations["loc.sklad2"] = new Dictionary<string, Object>();
        //        locations["loc.sklad"] = new Dictionary<string, Object>();
        //        locations["loc.reg"] = new Dictionary<string, Object>();
        //        locations["loc.jd3"] = new Dictionary<string, Object>();
        //        locations["loc.jd4"] = new Dictionary<string, Object>();
        //        locations["loc.jd2"] = new Dictionary<string, Object>();
        //        locations["loc.jd1"] = new Dictionary<string, Object>();
        //        locations["loc.osobn"] = new Dictionary<string, Object>();
        //        locations["loc.tenal"] = new Dictionary<string, Object>();
        //        locations["loc.vv"] = new Dictionary<string, Object>();
        //        locations["loc.vpl"] = new Dictionary<string, Object>();
        //        locations["loc.ak1"] = new Dictionary<string, Object>();
        //        locations["loc.bank1"] = new Dictionary<string, Object>();
        //        locations["loc.bank"] = new Dictionary<string, Object>();
        //        locations["loc.bank2"] = new Dictionary<string, Object>();
        //        locations["loc.kon1"] = new Dictionary<string, Object>();
        //        locations["loc.kon"] = new Dictionary<string, Object>();
        //        locations["loc.centr1"] = new Dictionary<string, Object>();
        //        locations["loc.tav"] = new Dictionary<string, Object>();
        //        locations["loc.tav1"] = new Dictionary<string, Object>();
        //        locations["loc.tav2"] = new Dictionary<string, Object>();
        //        locations["loc.tav3"] = new Dictionary<string, Object>();
        //        locations["loc.tav4"] = new Dictionary<string, Object>();
        //        locations["loc.tav5"] = new Dictionary<string, Object>();
        //        locations["loc.br"] = new Dictionary<string, Object>();
        //        locations["loc.or"] = new Dictionary<string, Object>();
        //        locations["loc.centr2"] = new Dictionary<string, Object>();
        //        locations["loc.kuzn"] = new Dictionary<string, Object>();
        //        locations["loc.uv"] = new Dictionary<string, Object>();
        //        locations["loc.uz2"] = new Dictionary<string, Object>();
        //        locations["loc.prip"] = new Dictionary<string, Object>();
        //        locations["loc.luk"] = new Dictionary<string, Object>();
        //        locations["loc.uz1"] = new Dictionary<string, Object>();
        //        locations["loc.jiv"] = new Dictionary<string, Object>();
        //        locations["loc.but"] = new Dictionary<string, Object>();
        //        locations["loc.kaz1"] = new Dictionary<string, Object>();
        //        locations["loc.kaz"] = new Dictionary<string, Object>();
        //        locations["loc.dv1"] = new Dictionary<string, Object>();
        //        locations["loc.dv"] = new Dictionary<string, Object>();
        //        locations["loc.dv2"] = new Dictionary<string, Object>();
        //        locations["loc.br3"] = new Dictionary<string, Object>();
        //        locations["loc.br4"] = new Dictionary<string, Object>();
        //        locations["loc.br2"] = new Dictionary<string, Object>();
        //        locations["loc.br1"] = new Dictionary<string, Object>();
        //        locations["loc.sv"] = new Dictionary<string, Object>();
        //        locations["loc.snar"] = new Dictionary<string, Object>();
        //        locations["loc.zvv"] = new Dictionary<string, Object>();
        //        locations["loc.zsv"] = new Dictionary<string, Object>();
        //        locations["loc.zb.1"] = new Dictionary<string, Object>();
        //        locations["loc.zb.2"] = new Dictionary<string, Object>();
        //        locations["loc.zb.3"] = new Dictionary<string, Object>();
        //        locations["loc.zb.4"] = new Dictionary<string, Object>();
        //        locations["loc.zb.5"] = new Dictionary<string, Object>();
        //        locations["loc.pristan"] = new Dictionary<string, Object>();
        //        locations["loc.port1"] = new Dictionary<string, Object>();
        //        locations["loc.port2"] = new Dictionary<string, Object>();
        //        locations["loc.ak"] = new Dictionary<string, Object>();
        //        locations["loc.ak4"] = new Dictionary<string, Object>();
        //        locations["loc.ak2"] = new Dictionary<string, Object>();
        //        locations["loc.ak5"] = new Dictionary<string, Object>();
        //        locations["loc.ak3"] = new Dictionary<string, Object>();
        //        locations["loc.cpl"] = new Dictionary<string, Object>();
        //        locations["loc.dvr"] = new Dictionary<string, Object>();
        //        locations["loc.dvr2"] = new Dictionary<string, Object>();
        //        locations["loc.dvr4"] = new Dictionary<string, Object>();
        //        locations["loc.dvr1"] = new Dictionary<string, Object>();
        //        locations["loc.dvr5"] = new Dictionary<string, Object>();
        //        locations["loc.dvr3"] = new Dictionary<string, Object>();
        //        locations["loc.bl.1"] = new Dictionary<string, Object>();
        //        locations["loc.bl.2"] = new Dictionary<string, Object>();
        //        locations["loc.bl.3"] = new Dictionary<string, Object>();
        //        locations["loc.bl.4"] = new Dictionary<string, Object>();
        //        locations["loc.bl.5"] = new Dictionary<string, Object>();
        //        locations["loc.bl.6"] = new Dictionary<string, Object>();
        //        locations["loc.bl.7"] = new Dictionary<string, Object>();
        //        locations["loc.bl.8"] = new Dictionary<string, Object>();
        //        locations["loc.kl.1"] = new Dictionary<string, Object>();
        //        locations["loc.kl.2"] = new Dictionary<string, Object>();
        //        locations["loc.kl.3"] = new Dictionary<string, Object>();
        //        locations["loc.kl.4"] = new Dictionary<string, Object>();
        //        locations["loc.kl.5"] = new Dictionary<string, Object>();
        //        locations["loc.kl.6"] = new Dictionary<string, Object>();
        //        locations["loc.kl.7"] = new Dictionary<string, Object>();
        //        locations["loc.kl.8"] = new Dictionary<string, Object>();
        //        locations["loc.kl.9"] = new Dictionary<string, Object>();
        //        locations["loc.kl.10"] = new Dictionary<string, Object>();
        //        locations["loc.kl.11"] = new Dictionary<string, Object>();
        //        locations["loc.kl.12"] = new Dictionary<string, Object>();
        //        locations["loc.kl.13"] = new Dictionary<string, Object>();
        //        locations["loc.kl.14"] = new Dictionary<string, Object>();
        //        locations["loc.kl.15"] = new Dictionary<string, Object>();
        //        locations["loc.kl.16"] = new Dictionary<string, Object>();
        //        locations["loc.kl.17"] = new Dictionary<string, Object>();
        //        locations["loc.kl.18"] = new Dictionary<string, Object>();
        //        locations["loc.kl.19"] = new Dictionary<string, Object>();
        //        locations["loc.kl.20"] = new Dictionary<string, Object>();
        //        locations["loc.kl.21"] = new Dictionary<string, Object>();
        //        locations["loc.kl.22"] = new Dictionary<string, Object>();
        //        locations["loc.kl.23"] = new Dictionary<string, Object>();
        //        locations["loc.kl.24"] = new Dictionary<string, Object>();
        //        locations["loc.kl.25"] = new Dictionary<string, Object>();
        //        locations["loc.kl.26"] = new Dictionary<string, Object>();
        //        locations["loc.kl.27"] = new Dictionary<string, Object>();
        //        locations["loc.kl.28"] = new Dictionary<string, Object>();
        //        locations["loc.kl.29"] = new Dictionary<string, Object>();
        //        locations["loc.kl.30"] = new Dictionary<string, Object>();
        //        locations["loc.kl.31"] = new Dictionary<string, Object>();
        //        locations["loc.kl.32"] = new Dictionary<string, Object>();
        //        locations["loc.kl.33"] = new Dictionary<string, Object>();
        //        locations["loc.kl.34"] = new Dictionary<string, Object>();
        //        locations["loc.kl.35"] = new Dictionary<string, Object>();
        //        locations["loc.kl.36"] = new Dictionary<string, Object>();
        //        locations["loc.kl.37"] = new Dictionary<string, Object>();
        //        locations["loc.kl.38"] = new Dictionary<string, Object>();
        //        locations["loc.kl.39"] = new Dictionary<string, Object>();
        //        locations["loc.kl.40"] = new Dictionary<string, Object>();
        //        locations["loc.kl.41"] = new Dictionary<string, Object>();
        //        locations["loc.kl.42"] = new Dictionary<string, Object>();
        //        locations["loc.kl.43"] = new Dictionary<string, Object>();
        //        locations["loc.sd.1"] = new Dictionary<string, Object>();
        //        locations["loc.sd.2"] = new Dictionary<string, Object>();
        //        locations["loc.sd.3"] = new Dictionary<string, Object>();
        //        locations["loc.sd.4"] = new Dictionary<string, Object>();
        //        locations["loc.kzd"] = new Dictionary<string, Object>();
        //        locations["loc.sl.1"] = new Dictionary<string, Object>();
        //        locations["loc.sl.2"] = new Dictionary<string, Object>();
        //        locations["loc.sl.3"] = new Dictionary<string, Object>();
        //        locations["loc.sl.4"] = new Dictionary<string, Object>();
        //        locations["loc.sl.5"] = new Dictionary<string, Object>();
        //        locations["loc.sl.6"] = new Dictionary<string, Object>();
        //        locations["loc.sl.7"] = new Dictionary<string, Object>();
        //        locations["loc.sl.8"] = new Dictionary<string, Object>();
        //        locations["loc.sl.9"] = new Dictionary<string, Object>();
        //        locations["loc.sl.10"] = new Dictionary<string, Object>();
        //        locations["loc.sl.11"] = new Dictionary<string, Object>();
        //        locations["loc.sl.12"] = new Dictionary<string, Object>();
        //        locations["loc.sl.14"] = new Dictionary<string, Object>();
        //        locations["loc.sl.15"] = new Dictionary<string, Object>();
        //        locations["loc.sl.16"] = new Dictionary<string, Object>();
        //        locations["loc.sl.17"] = new Dictionary<string, Object>();
        //        locations["loc.vd.1"] = new Dictionary<string, Object>();
        //        locations["loc.vd.2"] = new Dictionary<string, Object>();
        //        locations["loc.vd.3"] = new Dictionary<string, Object>();
        //        locations["loc.vd.4"] = new Dictionary<string, Object>();
        //        locations["loc.vd.5"] = new Dictionary<string, Object>();
        //        locations["loc.vd.6"] = new Dictionary<string, Object>();
        //        locations["loc.vd.7"] = new Dictionary<string, Object>();
        //        locations["loc.vl.1"] = new Dictionary<string, Object>();
        //        locations["loc.vl.2"] = new Dictionary<string, Object>();
        //        locations["loc.vl.3"] = new Dictionary<string, Object>();
        //        locations["loc.vl.4"] = new Dictionary<string, Object>();
        //        locations["loc.vl.5"] = new Dictionary<string, Object>();
        //        locations["loc.vl.6"] = new Dictionary<string, Object>();
        //        locations["loc.vl.7"] = new Dictionary<string, Object>();
        //        locations["loc.vl.8"] = new Dictionary<string, Object>();
        //        locations["loc.vl.9"] = new Dictionary<string, Object>();
        //        locations["loc.vl.10"] = new Dictionary<string, Object>();
        //        locations["loc.vl.11"] = new Dictionary<string, Object>();
        //        locations["loc.vl.12"] = new Dictionary<string, Object>();
        //        locations["loc.vl.13"] = new Dictionary<string, Object>();
        //        locations["loc.vl.14"] = new Dictionary<string, Object>();
        //        locations["loc.vl.15"] = new Dictionary<string, Object>();
        //        locations["loc.vl.16"] = new Dictionary<string, Object>();
        //        locations["loc.vl.17"] = new Dictionary<string, Object>();
        //        locations["loc.vl.18"] = new Dictionary<string, Object>();
        //        locations["loc.vl.19"] = new Dictionary<string, Object>();
        //        locations["loc.vl.20"] = new Dictionary<string, Object>();
        //        locations["loc.vl.21"] = new Dictionary<string, Object>();
        //        locations["loc.vl.22"] = new Dictionary<string, Object>();
        //        locations["loc.vl.23"] = new Dictionary<string, Object>();
        //        locations["loc.vl.24"] = new Dictionary<string, Object>();
        //        locations["loc.vl.25"] = new Dictionary<string, Object>();
        //        locations["loc.vl.26"] = new Dictionary<string, Object>();
        //        locations["loc.vl.27"] = new Dictionary<string, Object>();
        //        locations["loc.vl.28"] = new Dictionary<string, Object>();
        //        locations["loc.vl.29"] = new Dictionary<string, Object>();
        //        locations["loc.vl.30"] = new Dictionary<string, Object>();
        //        locations["loc.zl.1"] = new Dictionary<string, Object>();
        //        locations["loc.zl.2"] = new Dictionary<string, Object>();
        //        locations["loc.zl.3"] = new Dictionary<string, Object>();
        //        locations["loc.zl.4"] = new Dictionary<string, Object>();
        //        locations["loc.zl.5"] = new Dictionary<string, Object>();
        //        locations["loc.zl.6"] = new Dictionary<string, Object>();
        //        locations["loc.zl.7"] = new Dictionary<string, Object>();
        //        locations["loc.zl.8"] = new Dictionary<string, Object>();
        //        locations["loc.zl.9"] = new Dictionary<string, Object>();
        //        locations["loc.zl.10"] = new Dictionary<string, Object>();
        //        locations["loc.zl.11"] = new Dictionary<string, Object>();
        //        locations["loc.zl.12"] = new Dictionary<string, Object>();
        //        locations["loc.zl.13"] = new Dictionary<string, Object>();
        //        locations["loc.zl.14"] = new Dictionary<string, Object>();
        //        locations["loc.zl.15"] = new Dictionary<string, Object>();
        //        locations["loc.krestd"] = new Dictionary<string, Object>();
        //    }

        //    /// <summary>
        //    /// Шаг 5 - Спаун стартовых объектов в мире
        //    /// </summary>
        //    public void SpawnStartElements()
        //    {
        //        locations["loc.0"]["npc.beginner"] = new _1NPC(npcs["npc.beginner"]);
        //        ((_1NPC)locations["loc.0"]["npc.beginner"]).respawn = "loc.0|1|2";

        //        locations["loc.lek"]["npc.healer"] = new _1NPC(npcs["npc.healer"]);
        //        ((_1NPC)locations["loc.lek"]["npc.healer"]).respawn = "loc.lek|1|2";

        //        locations["loc.drag"]["npc.Mahmet"] = new _1NPC(npcs["npc.Mahmet"]);
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).respawn = "loc.drag|1|2";
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).trader = "1|0.5|2400";
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).trader_filter.Add("item.crystal");
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).trader_filter.Add("item.ring");
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).bank.Add("item.ring.gold", "90|0|1=золотое кольцо|1|70");
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).bank.Add("item.ring.silver", "90|1|2=серебрянное кольцо|1|50");
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).bank.Add("item.crystal.adamant", "90|0|2=алмаз|1|300");
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).bank.Add("item.crystal.emerald", "90|0|2=изумруд|1|200");
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).bank.Add("item.crystal.ruby", "90|0|4=рубин|1|150");
        //        ((_1NPC)locations["loc.drag"]["npc.Mahmet"]).bank.Add("item.crystal.amber", "90|0|4=янтарь|1|100");

        //        locations["loc.sklad2"]["npc.Djon"] = new _1NPC(npcs["npc.Djon"]);
        //        ((_1NPC)locations["loc.sklad2"]["npc.Djon"]).respawn = "loc.sklad2|1|2";

        //        locations["loc.sklad"]["npc.crim.rat.123"] = new _1NPC(npcs["npc.crim.rat"]);
        //        ((_1NPC)locations["loc.sklad"]["npc.crim.rat.123"]).respawn = "loc.sklad|600|1200";

        //        locations["loc.sklad"]["npc.crim.rat.124"] = new _1NPC(npcs["npc.crim.rat"]);
        //        ((_1NPC)locations["loc.sklad"]["npc.crim.rat.124"]).respawn = "loc.sklad|600|1200";

        //        locations["loc.sklad"]["npc.crim.rat.125"] = new _1NPC(npcs["npc.crim.rat"]);
        //        ((_1NPC)locations["loc.sklad"]["npc.crim.rat.125"]).respawn = "loc.sklad|600|1200";

        //        locations["loc.sklad"]["npc.crim.rat.126"] = new _1NPC(npcs["npc.crim.rat"]);
        //        ((_1NPC)locations["loc.sklad"]["npc.crim.rat.126"]).respawn = "loc.sklad|600|1200";

        //        locations["loc.reg"]["npc.Julien"] = new _1NPC(npcs["npc.Julien"]);
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).respawn = "loc.reg|1|2";
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).trader = "1|0.8|1200";
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).trader_filter.Add("item.magic.sulphur");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).trader_filter.Add("item.magic.coal");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).trader_filter.Add("item.magic.silk");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).trader_filter.Add("item.magic.pearl");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).trader_filter.Add("item.magic.wormwood");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).trader_filter.Add("item.magic.moss");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).trader_filter.Add("item.recallrune");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).bank.Add("item.recallrune.empty", "90|1|4=руна перемещения|1|100");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).bank.Add("item.magic.sulphur", "90|2|8=сера|1|4");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).bank.Add("item.magic.coal", "90|2|8=уголь|1|2");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).bank.Add("item.magic.silk", "90|2|8=паутина|1|4");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).bank.Add("item.magic.pearl", "90|1|4=жемчуг|1|10");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).bank.Add("item.magic.wormwood", "90|2|8=полынь|1|2");
        //        ((_1NPC)locations["loc.reg"]["npc.Julien"]).bank.Add("item.magic.moss", "90|2|8=мох|1|2");

        //        locations["loc.osobn"]["npc.Gregg"] = new _1NPC(npcs["npc.Gregg"]);
        //        ((_1NPC)locations["loc.osobn"]["npc.Gregg"]).respawn = "loc.osobn|1|2";

        //        locations["loc.osobn"]["npc.Stoun"] = new _1NPC(npcs["npc.Stoun"]);
        //        ((_1NPC)locations["loc.osobn"]["npc.Stoun"]).respawn = "loc.osobn|1|2";

        //        locations["loc.bank1"]["npc.animal.dog.123"] = new _1NPC(npcs["npc.animal.dog"]);
        //        ((_1NPC)locations["loc.bank1"]["npc.animal.dog.123"]).respawn = "loc.bank1|600|1200";
        //        ((_1NPC)locations["loc.bank1"]["npc.animal.dog.123"]).move = "10|30|180|1";

        //        locations["loc.bank"]["npc.bankir"] = new _1NPC(npcs["npc.bankir"]);
        //        ((_1NPC)locations["loc.bank"]["npc.bankir"]).respawn = "loc.bank|1|2";

        //        locations["loc.kon1"]["npc.animal.pig.12"] = new _1NPC(npcs["npc.animal.pig"]);
        //        ((_1NPC)locations["loc.kon1"]["npc.animal.pig.12"]).respawn = "loc.kon1|600|1200";

        //        locations["loc.tav1"]["npc.Frederik"] = new _1NPC(npcs["npc.Frederik"]);
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).respawn = "loc.tav1|1|2";
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).trader = "1|1|1200";
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).trader_filter.Add("none");
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).bank.Add("item.food.meat.fried", "90|0|4=жаренное мясо|1|25|8|0|");
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).bank.Add("item.food.apple", "90|0|10=яблоко|1|4|2|0|");
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).bank.Add("item.food.sandwich", "90|0|12=бутерброд|1|15|5|0|");
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).bank.Add("item.food.sausage", "90|0|6=колбаса|1|20|9|0|");
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).bank.Add("item.food.ham", "90|0|4=окорок|1|30|13|0|");
        //        ((_1NPC)locations["loc.tav1"]["npc.Frederik"]).bank.Add("item.food.bread", "90|0|6=хлеб|1|16|6|0|");

        //        locations["loc.br"]["npc.Silt"] = new _1NPC(npcs["npc.Silt"]);
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).respawn = "loc.br|1|2";
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).trader = "1.2|0.6|1200";
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).trader_filter.Add("item.armor");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.body.leather", "90|0|6=кожаная броня|1|150|2");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.hand.leather", "90|0|6=кожаные поручи|1|70|1");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.leg.leather", "90|0|6=кожаные поножи|1|80|1");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.head.leather", "90|0|6=кожаный шлем|1|70|1");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.body.bone", "90|0|4=костяная броня|1|250|3");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.hand.bone", "90|0|4=костяные поручи|1|90|1");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.body.mail", "70|0|3=кольчуга|1|450|4");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.body.full", "60|0|2=латный доспех|1|600|5");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.body.plate", "40|0|1=пластинчатый доспех|1|1000|6");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.shield.wood", "90|0|12=деревянный щит|1|80|1");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.shield.copperwood", "70|0|6=обитый щит|1|150|2");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.shield.bronze", "70|0|4=бронзовый щит|1|250|3");
        //        ((_1NPC)locations["loc.br"]["npc.Silt"]).bank.Add("item.armor.shield.heavy", "50|0|2=большой щит|1|400|4");

        //        locations["loc.or"]["npc.Plant"] = new _1NPC(npcs["npc.Plant"]);
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).respawn = "loc.or|1|2";
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).trader = "1.2|0.6|1200";
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).trader_filter.Add("item.weapon");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.knife", "90|0|18=нож|1|10|1|3|0|4|ножом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.knife.hunter", "70|0|6=охотничий нож|1|15|1|5|0|4|ножом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.knife.boot", "40|0|2=нож-засапожник|1|20|2|4|0|4|ножом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.knife.butcher", "60|0|3=нож мясника|1|25|2|5|0|5|ножом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.knife.cutlass", "70|0|4=тесак|1|18|2|5|2|5|тесаком||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.dagger", "90|0|8=кинжал|1|22|1|6|0|4|кинжалом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.kortik", "70|0|5=кортик|1|20|1|5|0|4|кортиком||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.shortsword", "90|0|12=короткий меч|1|30|3|4|0|5|мечом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.broadsword", "40|0|4=широкий меч|1|35|3|5|0|5|мечом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.halfsword", "80|0|6=полуторный меч|1|40|4|5|2|5|мечом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.longsword", "70|0|6=длинный меч|1|50|5|7|3|5|мечом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.twohandsword", "60|0|3=двуручный меч|1|150|5|12|4|7|мечом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.sabre", "80|0|6=сабля|1|70|3|8|2|5|саблей||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.crookedsword", "70|0|6=кривой меч|1|60|4|7|2|6|мечом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.yatagan", "50|0|4=ятаган|1|50|2|6|3|6|ятаганом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.samuraysword", "20|0|3=самурайский меч|1|200|3|10|0|5|мечом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.glade", "80|0|5=шпага|1|40|1|4|0|5|шпагой||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.flamberg", "30|0|3=фламберг|1|170|12|15|5|9|фламбергом||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.spear", "70|0|5=копье|1|180|6|11|3|6|копьем||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.halberd", "40|0|2=алебарда|1|250|11|17|4|9|алебардой||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.axe", "80|0|4=топор|1|90|6|7|3|7|топором||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.poleaxe", "60|0|3=секира|1|210|9|15|4|8|секирой||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.blackjack", "90|0|12=дубина|1|15|2|3|2|6|дубиной||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.moningstar", "80|0|2=утренняя звезда|1|120|5|8|3|8|утренней звездой||");
        //        ((_1NPC)locations["loc.or"]["npc.Plant"]).bank.Add("item.weapon.glefa", "20|0|2=глефа|1|250|7|11|2|6|глефой||");

        //        locations["loc.kuzn"]["npc.Raks"] = new _1NPC(npcs["npc.Raks"]);
        //        ((_1NPC)locations["loc.kuzn"]["npc.Raks"]).respawn = "loc.kuzn|1|2";

        //        locations["loc.prip"]["npc.Goston"] = new _1NPC(npcs["npc.Goston"]);
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).respawn = "loc.prip|1|2";
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).trader = "1|0.7|1200";
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.recallrune.empty", "90|1|8=руна перемещения|1|100");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.magic.sulphur", "90|1|4=сера|1|4");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.magic.coal", "90|1|4=уголь|1|2");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.magic.silk", "90|1|4=паутина|1|4");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.magic.pearl", "90|1|2=жемчуг|1|10");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.magic.wormwood", "90|1|4=полынь|1|2");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.magic.moss", "90|1|4=мох|1|2");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.weapon.knife", "90|0|6=нож|1|10|1|3|0|4|ножом||");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.weapon.knife.hunter", "70|0|4=охотничий нож|1|15|1|5|0|4|ножом||");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.weapon.knife.boot", "40|0|1=нож-засапожник|1|20|2|4|0|4|ножом||");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.weapon.knife.butcher", "60|0|3=нож мясника|1|25|2|5|0|5|ножом||");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.weapon.knife.cutlass", "70|0|4=тесак|1|18|2|5|2|5|тесаком||");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.weapon.dagger", "90|0|8=кинжал|1|22|1|6|0|4|кинжалом||");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.misc.arrow", "90|0|28=стрелы|1|1");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.misc.bolt", "90|0|22=болты|1|1");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.food.meat.fried", "90|0|4=жаренное мясо|1|25|8|0|");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.food.apple", "90|0|10=яблоко|1|4|2|0|");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.food.sandwich", "90|0|12=бутерброд|1|15|5|0|");
        //        ((_1NPC)locations["loc.prip"]["npc.Goston"]).bank.Add("item.food.sausage", "90|0|6=колбаса|1|20|9|0|");

        //        locations["loc.luk"]["npc.Arant"] = new _1NPC(npcs["npc.Arant"]);
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).respawn = "loc.luk|1|2";
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).trader = "1.2|0.6|1200";
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).trader_filter.Add("item.weapon.ranged");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.misc.arrow", "90|0|32=стрелы|1|1");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.misc.bolt", "90|0|32=болты|1|1");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.stone", "90|0|32=камень|1|2|0|1|0|5|камнем|item.weapon.ranged.stone|камень");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.surricen", "80|0|23=сюррикен|1|5|0|1|0|4|сюррикеном|item.weapon.surricen|сюррикен");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.bumerang", "30|0|3=бумеранг|1|30|1|4|0|5|бумерангом||");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.tomahawk", "40|0|6=томагавк|1|15|2|3|2|5|томагавком|item.weapon.tomahawk|томагавк");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.dropknife", "70|0|16=метательный нож|1|10|1|3|2|4|метательным ножом|item.weapon.dropknife|метательный нож");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.dropspear", "40|0|12=метательное копье|1|100|7|17|3|7|метательным копьем|item.weapon.dropspear|метательное копье");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.javelin", "70|0|18=дротик|1|15|1|5|0|4|дротиком|item.weapon.javelin|дротик");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.sling", "90|0|4=праща|1|30|1|8|0|6|пращой|item.weapon.ranged.stone|камень");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.bow", "90|0|6=лук|1|30|1|6|0|5|луком|item.misc.arrow|стрелы");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.shortbow", "90|0|8=короткий лук|1|30|1|5|0|5|луком|item.misc.arrow|стрелы");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.longbow", "70|0|6=длинный лук|1|50|3|6|2|5|луком|item.misc.arrow|стрелы");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.willowbow", "60|0|6=ивовый лук|1|60|4|6|2|5|луком|item.misc.arrow|стрелы");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.birchbow", "40|0|4=березовый лук|1|90|5|8|3|6|луком|item.misc.arrow|стрелы");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.hunterbow", "30|0|2=охотничий лук|1|150|5|10|3|6|луком|item.misc.arrow|стрелы");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.compoundbow", "20|0|1=соcтавной лук|1|250|8|13|4|6|луком|item.misc.arrow|стрелы");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.crossbow.light", "70|0|4=легкий арбалет|1|150|7|10|0|7|арбалетом|item.misc.bolt|болты");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.crossbow.middle", "40|0|3=средний арбалет|1|230|10|16|3|6|арбалетом|item.misc.bolt|болты");
        //        ((_1NPC)locations["loc.luk"]["npc.Arant"]).bank.Add("item.weapon.ranged.crossbow.hard", "20|0|1=тяжелый арбалет|1|280|14|17|4|9|арбалетом|item.misc.bolt|болты");

        //        locations["loc.jiv"]["npc.Milta"] = new _1NPC(npcs["npc.Milta"]);
        //        ((_1NPC)locations["loc.jiv"]["npc.Milta"]).respawn = "loc.jiv|1|2";

        //        locations["loc.jiv"]["npc.animal.pig.13"] = new _1NPC(npcs["npc.animal.pig"]);
        //        ((_1NPC)locations["loc.jiv"]["npc.animal.pig.13"]).respawn = "loc.jiv|600|1200";

        //        locations["loc.jiv"]["npc.animal.hen.12"] = new _1NPC(npcs["npc.animal.hen"]);
        //        ((_1NPC)locations["loc.jiv"]["npc.animal.hen.12"]).respawn = "loc.jiv|600|1200";

        //        locations["loc.but"]["npc.Raksha"] = new _1NPC(npcs["npc.Raksha"]);
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).respawn = "loc.but|1|2";
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).trader = "1|0.6|1200";
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).trader_filter.Add("item.bottle");
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).bank.Add("item.bottle.empty", "90|0|8=бутылка|1|5|0|0|");
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).bank.Add("item.bottle.life", "90|0|4=напиток жизни|1|30|15|0|");
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).bank.Add("item.bottle.life.great", "60|0|2=напиток великой жизни|1|150|25|0|");
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).bank.Add("item.bottle.mana", "90|0|4=напиток маны|1|40|0|10|");
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).bank.Add("item.bottle.mana.great", "60|0|2=напиток великой маны|1|150|0|25|");
        //        ((_1NPC)locations["loc.but"]["npc.Raksha"]).bank.Add("item.bottle.health", "30|0|3=напиток исцеления|1|100|15|10|");

        //        locations["loc.kaz"]["npc.Markus"] = new _1NPC(npcs["npc.Markus"]);
        //        ((_1NPC)locations["loc.kaz"]["npc.Markus"]).respawn = "loc.kaz|1|2";

        //        locations["loc.dv"]["npc.Surri"] = new _1NPC(npcs["npc.Surri"]);
        //        ((_1NPC)locations["loc.dv"]["npc.Surri"]).respawn = "loc.dv|1|2";

        //        locations["loc.dv2"]["npc.Sirs"] = new _1NPC(npcs["npc.Sirs"]);
        //        ((_1NPC)locations["loc.dv2"]["npc.Sirs"]).respawn = "loc.dv2|1|2";

        //        locations["loc.br2"][".crim.rat.129"] = new _1NPC(npcs[".crim.rat"]);
        //        ((_1NPC)locations["loc.br2"][".crim.rat.129"]).respawn = "loc.br2|600|1200";

        //        locations["loc.br2"]["item.magic.wormwood"] = new _1Item(items["item.magic.wormwood"]);
        //        ((_1Item)locations["loc.br2"]["item.magic.wormwood"]).time = 1;
        //        ((_1Item)locations["loc.br2"]["item.magic.wormwood"]).respawn = "600|1200|0|4";

        //        locations["loc.snar"]["npc.Sloven"] = new _1NPC(npcs["npc.Sloven"]);
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).respawn = "loc.snar|1|2";
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).trader = "1.2|0.6|1200";
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.recallrune.empty", "90|1|8=руна перемещения|1|100");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.magic.sulphur", "90|1|4=сера|1|4");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.magic.coal", "90|1|4=уголь|1|2");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.magic.silk", "90|1|4=паутина|1|4");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.magic.pearl", "90|1|2=жемчуг|1|10");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.magic.wormwood", "90|1|4=полынь|1|2");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.magic.moss", "90|1|4=мох|1|2");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.weapon.knife", "90|0|6=нож|1|10|1|3|0|4|ножом||");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.weapon.knife.hunter", "70|0|4=охотничий нож|1|15|1|5|0|4|ножом||");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.weapon.knife.boot", "40|0|1=нож-засапожник|1|20|2|4|0|4|ножом||");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.weapon.knife.butcher", "60|0|3=нож мясника|1|25|2|5|0|5|ножом||");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.weapon.knife.cutlass", "70|0|4=тесак|1|18|2|5|2|5|тесаком||");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.weapon.dagger", "90|0|8=кинжал|1|22|1|6|0|4|кинжалом||");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.misc.arrow", "90|0|28=стрелы|1|1");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.misc.bolt", "90|0|22=болты|1|1");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.food.meat.fried", "90|0|4=жаренное мясо|1|25|8|0|");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.food.apple", "90|0|10=яблоко|1|4|2|0|");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.food.sandwich", "90|0|12=бутерброд|1|15|5|0|");
        //        ((_1NPC)locations["loc.snar"]["npc.Sloven"]).bank.Add("item.food.sausage", "90|0|6=колбаса|1|20|9|0|");

        //        locations["loc.zsv"]["npc.Yan"] = new _1NPC(npcs["npc.Yan"]);
        //        ((_1NPC)locations["loc.zsv"]["npc.Yan"]).respawn = "loc.zsv|1|2";

        //        locations["loc.zb.1"]["item.weapon.ranged.stone"] = new _1Item(items["item.weapon.ranged.stone"]);
        //        ((_1Item)locations["loc.zb.1"]["item.weapon.ranged.stone"]).time = 1;
        //        ((_1Item)locations["loc.zb.1"]["item.weapon.ranged.stone"]).respawn = "600|1200|0|8";

        //        locations["loc.zb.2"]["item.magic.pearl"] = new _1Item(items["item.magic.pearl"]);
        //        ((_1Item)locations["loc.zb.2"]["item.magic.pearl"]).time = 1;
        //        ((_1Item)locations["loc.zb.2"]["item.magic.pearl"]).respawn = "600|1200|0|2";

        //        locations["loc.zb.3"]["item.magic.pearl"] = new _1Item(items["item.magic.pearl"]);
        //        ((_1Item)locations["loc.zb.3"]["item.magic.pearl"]).time = 1;
        //        ((_1Item)locations["loc.zb.3"]["item.magic.pearl"]).respawn = "600|1200|0|2";

        //        locations["loc.pristan"]["npc.Ded"] = new _1NPC(npcs["npc.Ded"]);
        //        ((_1NPC)locations["loc.pristan"]["npc.Ded"]).respawn = "loc.pristan|1|2";

        //        locations["loc.pristan"]["npc.Malchugan"] = new _1NPC(npcs["npc.Malchugan"]);
        //        ((_1NPC)locations["loc.pristan"]["npc.Malchugan"]).respawn = "loc.pristan|1|2";

        //        locations["loc.ak"]["npc.Franchesko"] = new _1NPC(npcs["npc.Franchesko"]);
        //        ((_1NPC)locations["loc.ak"]["npc.Franchesko"]).respawn = "loc.ak|1|2";

        //        locations["loc.ak4"]["npc.Djoshua"] = new _1NPC(npcs["npc.Djoshua"]);
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).respawn = "loc.ak4|1|2";
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).trader = "1.5|0.5|1200";
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).trader_filter.Add("item.magic.sulphur");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).trader_filter.Add("item.magic.coal");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).trader_filter.Add("item.magic.silk");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).trader_filter.Add("item.magic.pearl");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).trader_filter.Add("item.magic.wormwood");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).trader_filter.Add("item.magic.moss");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).trader_filter.Add("item.recallrune");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.recallrune.empty", "90|1|8=руна перемещения|1|100");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.magic.sulphur", "90|2|14=сера|1|4");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.magic.coal", "90|2|14=уголь|1|2");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.magic.silk", "90|2|18=паутина|1|4");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.magic.pearl", "90|1|12=жемчуг|1|10");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.magic.wormwood", "90|3|10=полынь|1|2");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.magic.moss", "90|6|18=мох|1|2");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.bottle.empty", "90|0|12=бутылка|1|5|0|0|");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.bottle.life", "90|0|8=напиток жизни|1|30|15|0|");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.bottle.life.great", "70|0|4=напиток великой жизни|1|150|25|0|");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.bottle.mana", "90|0|8=напиток маны|1|40|0|10|");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.bottle.mana.great", "70|0|4=напиток великой маны|1|150|0|25|");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.bottle.health", "60|0|6=напиток исцеления|1|100|15|10|");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.war.arrow", "90|12|24=свиток Магическая стрела|1|30");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.war.firearrow", "90|8|16=свиток Огненная стрела|1|0");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.war.icefirst", "90|6|14=свиток Ледяной кулак|1|50");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.war.firebolt", "80|6|12=свиток Огненный столб|1|55");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.war.iceray", "70|4|8=свиток Ледяной луч|1|60");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.war.firestreem", "60|4|8=свиток Струя пламени|1|70");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.war.lighting", "80|2|12=свиток Молния|1|35");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.all.watergross", "60|0|4=свиток Водяной вал|1|60");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.all.earthquake", "40|1|3=свиток Землетрясение|1|80");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.createfood", "90|5|12=свиток Создать еду|1|20");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.charm", "80|2|8=свиток Зачаровать|1|45");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.charmenemy", "70|0|8=свиток Привлечь|1|70");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.peace", "70|0|8=свиток Усмирить|1|60");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.silence", "70|0|6=свиток Тишина|1|100");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.maddnes", "50|0|4=свиток Безумие|1|150");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.summon.wolf", "80|0|8=свиток Призвать волка|1|45");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.summon.skeleton", "70|0|6=свиток Призвать скелета|1|55");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.summon.golem", "60|0|5=свиток Призвать голема|1|60");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.summon.demon", "40|0|4=свиток Призвать демона|1|80");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.heal", "90|6|24=свиток Лечение|1|20");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.heal.great", "60|1|6=свиток Исцеление|1|40");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.ressurect", "30|1|3=свиток Воскрешение|1|200");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.mark", "90|4|12=свиток Пометить|1|35");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.scroll.recall", "90|6|18=свиток Возвращение|1|25");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.war.arrow", "90|1|6=руна Магическая стрела|1|200");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.war.firearrow", "80|1|5=руна Огненная стрела|1|300");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.war.icefirst", "70|0|2=руна Ледяной кулак|1|350");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.war.firebolt", "60|0|3=руна Огненный столб|1|400");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.war.iceray", "40|0|2=руна Ледяной луч|1|450");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.war.firestreem", "40|0|1=руна Струя пламени|1|500");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.war.lighting", "80|0|4=руна Молния|1|300");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.all.watergross", "70|0|1=руна Водяной вал|1|500");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.all.earthquake", "60|0|2=руна Землетрясение|1|650");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.createfood", "90|1|6=руна Создать еду|1|400");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.charm", "70|0|2=руна Зачаровать|1|300");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.charmenemy", "80|0|4=руна Привлечь|1|500");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.peace", "70|0|3=руна Усмирить|1|400");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.silence", "70|0|4=руна Тишина|1|450");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.maddnes", "40|0|3=руна Безумие|1|800");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.summon.wolf", "80|0|4=руна Призвать волка|1|700");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.summon.skeleton", "70|0|4=руна Призвать скелета|1|800");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.summon.golem", "60|0|3=руна Призвать голема|1|900");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.summon.demon", "40|1|1=руна Призвать демона|1|1000");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.heal", "90|0|4=руна Лечение|1|600");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.heal.great", "70|0|3=руна Исцеление|1|800");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.ressurect", "20|0|2=руна Воскрешение|1|800");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.mark", "90|1|4=руна Пометить|1|600");
        //        ((_1NPC)locations["loc.ak4"]["npc.Djoshua"]).bank.Add("item.rune.recall", "90|2|4=руна Возвращение|1|500");

        //        locations["loc.ak2"]["npc.Klavdius"] = new _1NPC(npcs["npc.Klavdius"]);
        //        ((_1NPC)locations["loc.ak2"]["npc.Klavdius"]).respawn = "loc.ak2|1|2";

        //        locations["loc.ak5"]["npc.Serpent"] = new _1NPC(npcs["npc.Serpent"]);
        //        ((_1NPC)locations["loc.ak5"]["npc.Serpent"]).respawn = "loc.ak5|1|2";

        //        locations["loc.ak3"]["npc.Antonio"] = new _1NPC(npcs["npc.Antonio"]);
        //        ((_1NPC)locations["loc.ak3"]["npc.Antonio"]).respawn = "loc.ak3|1|2";

        //        locations["loc.ak3"]["npc.Milton"] = new _1NPC(npcs["npc.Milton"]);
        //        ((_1NPC)locations["loc.ak3"]["npc.Milton"]).respawn = "loc.ak3|1|2";

        //        locations["loc.dvr"]["npc.Gant"] = new _1NPC(npcs["npc.Gant"]);
        //        ((_1NPC)locations["loc.dvr"]["npc.Gant"]).respawn = "loc.dvr|1|2";

        //        locations["loc.dvr2"]["npc.Silvestr"] = new _1NPC(npcs["npc.Silvestr"]);
        //        ((_1NPC)locations["loc.dvr2"]["npc.Silvestr"]).respawn = "loc.dvr2|1|2";

        //        locations["loc.dvr2"]["npc.Stouns"] = new _1NPC(npcs["npc.Stouns"]);
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).respawn = "loc.dvr2|1|2";
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).trader = "1.5|0.5|1200";
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).trader_filter.Add("none");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.recallrune.empty", "90|1|8=руна перемещения|1|100");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.magic.sulphur", "90|2|8=сера|2|6");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.magic.coal", "90|2|8=уголь|4|6");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.magic.silk", "90|2|8=паутина|4|6");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.magic.pearl", "90|1|4=жемчуг|1|4");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.magic.wormwood", "90|2|8=полынь|4|6");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.magic.moss", "90|2|8=мох|6|6");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.scroll.heal", "90|4|12=свиток Лечение|1|20");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.scroll.heal.great", "60|1|6=свиток Исцеление|1|40");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.scroll.ressurect", "30|1|3=свиток Воскрешение|1|200");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.scroll.mark", "90|2|8=свиток Пометить|1|35");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.scroll.recall", "90|2|12=свиток Возвращение|1|25");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.scroll.war.holyarrow", "90|8|18=свиток Святая стрела|1|45");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.scroll.all.godanger", "50|1|4=свиток Гнев богов|1|80");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.rune.heal", "90|0|3=руна Лечение|1|600");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.rune.heal.great", "70|0|2=руна Исцеление|1|800");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.rune.ressurect", "20|0|1=руна Воскрешение|1|800");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.rune.mark", "90|1|2=руна Пометить|1|600");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.rune.recall", "90|2|2=руна Возвращение|1|500");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.rune.war.holyarrow", "90|1|4=руна Святая стрела|1|250");
        //        ((_1NPC)locations["loc.dvr2"]["npc.Stouns"]).bank.Add("item.rune.all.godanger", "50|0|2=руна Гнев богов|1|600");

        //        locations["loc.dvr4"]["npc.LordHagen"] = new _1NPC(npcs["npc.LordHagen"]);
        //        ((_1NPC)locations["loc.dvr4"]["npc.LordHagen"]).respawn = "loc.dvr4|1|2";

        //        locations["loc.dvr4"]["npc.Rene"] = new _1NPC(npcs["npc.Rene"]);
        //        ((_1NPC)locations["loc.dvr4"]["npc.Rene"]).respawn = "loc.dvr4|1|2";

        //        locations["loc.dvr5"]["npc.Kantares"] = new _1NPC(npcs["npc.Kantares"]);
        //        ((_1NPC)locations["loc.dvr5"]["npc.Kantares"]).respawn = "loc.dvr5|1|2";

        //        locations["loc.dvr5"]["npc.KantaresNovobranec"] = new _1NPC(npcs["npc.KantaresNovobranec"]);
        //        ((_1NPC)locations["loc.dvr5"]["npc.KantaresNovobranec"]).respawn = "loc.dvr5|1|2";

        //        locations["loc.dvr3"]["npc.Hans"] = new _1NPC(npcs["npc.Hans"]);
        //        ((_1NPC)locations["loc.dvr3"]["npc.Hans"]).respawn = "loc.dvr3|1|2";

        //        locations["loc.bl.6"]["item.magic.moss"] = new _1Item(items["item.magic.moss"]);
        //        ((_1Item)locations["loc.bl.6"]["item.magic.moss"]).time = 1;
        //        ((_1Item)locations["loc.bl.6"]["item.magic.moss"]).respawn = "600|1200|0|2";

        //        locations["loc.bl.8"]["item.magic.moss"] = new _1Item(items["item.magic.moss"]);
        //        ((_1Item)locations["loc.bl.8"]["item.magic.moss"]).time = 1;
        //        ((_1Item)locations["loc.bl.8"]["item.magic.moss"]).respawn = "600|1200|0|2";

        //        locations["loc.kl.3"]["npc.crim.zombie.124"] = new _1NPC(npcs["npc.crim.zombie"]);
        //        ((_1NPC)locations["loc.kl.3"]["npc.crim.zombie.124"]).respawn = "loc.kl.3|600|1200";
        //        ((_1NPC)locations["loc.kl.3"]["npc.crim.zombie.124"]).move = "3|20|180";

        //        locations["loc.kl.4"]["npc.crim.vampire.sds"] = new _1NPC(npcs["npc.crim.vampire"]);
        //        ((_1NPC)locations["loc.kl.4"]["npc.crim.vampire.sds"]).respawn = "loc.kl.4|600|1200";
        //        ((_1NPC)locations["loc.kl.4"]["npc.crim.vampire.sds"]).move = "2|20|180";

        //        locations["loc.kl.8"]["npc.crim.zombie.125"] = new _1NPC(npcs["npc.crim.zombie"]);
        //        ((_1NPC)locations["loc.kl.8"]["npc.crim.zombie.125"]).respawn = "loc.kl.8|600|1200";
        //        ((_1NPC)locations["loc.kl.8"]["npc.crim.zombie.125"]).move = "3|20|180";

        //        locations["loc.kl.11"]["item.magic.moss"] = new _1Item(items["item.magic.moss"]);
        //        ((_1Item)locations["loc.kl.11"]["item.magic.moss"]).time = 1;
        //        ((_1Item)locations["loc.kl.11"]["item.magic.moss"]).respawn = "600|1200|0|4";

        //        locations["loc.kl.14"]["npc.crim.zombie.123"] = new _1NPC(npcs["npc.crim.zombie"]);
        //        ((_1NPC)locations["loc.kl.14"]["npc.crim.zombie.123"]).respawn = "loc.kl.14|600|1200";
        //        ((_1NPC)locations["loc.kl.14"]["npc.crim.zombie.123"]).move = "3|20|180";

        //        locations["loc.kl.17"]["item.magic.wormwood"] = new _1Item(items["item.magic.wormwood"]);
        //        ((_1Item)locations["loc.kl.17"]["item.magic.wormwood"]).time = 1;
        //        ((_1Item)locations["loc.kl.17"]["item.magic.wormwood"]).respawn = "600|1200|0|4";

        //        locations["loc.kl.19"]["npc.crim.zombie.126"] = new _1NPC(npcs["npc.crim.zombie"]);
        //        ((_1NPC)locations["loc.kl.19"]["npc.crim.zombie.126"]).respawn = "loc.kl.19|600|1200";
        //        ((_1NPC)locations["loc.kl.19"]["npc.crim.zombie.126"]).move = "3|20|180";

        //        locations["loc.kl.22"]["npc.crim.skeleton.4334"] = new _1NPC(npcs["npc.crim.skeleton"]);
        //        ((_1NPC)locations["loc.kl.22"]["npc.crim.skeleton.4334"]).respawn = "loc.kl.22|600|1200";
        //        ((_1NPC)locations["loc.kl.22"]["npc.crim.skeleton.4334"]).move = "2|20|180";

        //        locations["loc.kl.25"]["npc.crim.skeleton.4334"] = new _1NPC(npcs["npc.crim.skeleton"]);
        //        ((_1NPC)locations["loc.kl.25"]["npc.crim.skeleton.4334"]).respawn = "loc.kl.25|600|1200";
        //        ((_1NPC)locations["loc.kl.25"]["npc.crim.skeleton.4334"]).move = "1|20|180";

        //        locations["loc.kl.33"]["npc.crim.warriorskeleton.3223"] = new _1NPC(npcs["npc.crim.warriorskeleton"]);
        //        ((_1NPC)locations["loc.kl.33"]["npc.crim.warriorskeleton.3223"]).respawn = "loc.kl.33|600|1200";
        //        ((_1NPC)locations["loc.kl.33"]["npc.crim.warriorskeleton.3223"]).move = "1|20|180";

        //        locations["loc.kl.33"]["item.magic.sulphur"] = new _1Item(items["item.magic.sulphur"]);
        //        ((_1Item)locations["loc.kl.33"]["item.magic.sulphur"]).time = 1;
        //        ((_1Item)locations["loc.kl.33"]["item.magic.sulphur"]).respawn = "600|1200|0|4";

        //        locations["loc.kl.38"]["npc.crim.zombie.126"] = new _1NPC(npcs["npc.crim.zombie"]);
        //        ((_1NPC)locations["loc.kl.38"]["npc.crim.zombie.126"]).respawn = "loc.kl.38|600|1200";
        //        ((_1NPC)locations["loc.kl.38"]["npc.crim.zombie.126"]).move = "3|20|180";

        //        locations["loc.kl.41"]["npc.crim.shadow.ds"] = new _1NPC(npcs["npc.crim.shadow"]);
        //        ((_1NPC)locations["loc.kl.41"]["npc.crim.shadow.ds"]).respawn = "loc.kl.41|600|1200";
        //        ((_1NPC)locations["loc.kl.41"]["npc.crim.shadow.ds"]).move = "4|20|180";

        //        locations["loc.kl.43"]["npc.crim.witch.daa"] = new _1NPC(npcs["npc.crim.witch"]);
        //        ((_1NPC)locations["loc.kl.43"]["npc.crim.witch.daa"]).respawn = "loc.kl.43|600|1200";
        //        ((_1NPC)locations["loc.kl.43"]["npc.crim.witch.daa"]).move = "2|20|180";

        //        locations["loc.kl.43"]["item.magic.silk"] = new _1Item(items["item.magic.silk"]);
        //        ((_1Item)locations["loc.kl.43"]["item.magic.silk"]).time = 1;
        //        ((_1Item)locations["loc.kl.43"]["item.magic.silk"]).respawn = "600|1200|0|4";

        //        locations["loc.sd.2"]["npc.animal.hen.ds"] = new _1NPC(npcs["npc.animal.hen"]);
        //        ((_1NPC)locations["loc.sd.2"]["npc.animal.hen.ds"]).respawn = "loc.sd.2|600|1200";

        //        locations["loc.sd.2"]["npc.animal.sheep.0"] = new _1NPC(npcs["npc.animal.sheep"]);
        //        ((_1NPC)locations["loc.sd.2"]["npc.animal.sheep.0"]).respawn = "loc.sd.2|600|1200";

        //        locations["loc.kzd"]["npc.Leksli"] = new _1NPC(npcs["npc.Leksli"]);
        //        ((_1NPC)locations["loc.kzd"]["npc.Leksli"]).respawn = "loc.kzd|1|2";
        //        ((_1NPC)locations["loc.kzd"]["npc.Leksli"]).trader = "1|0.8|1200";
        //        ((_1NPC)locations["loc.kzd"]["npc.Leksli"]).trader_filter.Add("item.hunter");
        //        ((_1NPC)locations["loc.kzd"]["npc.Leksli"]).bank.Add("item.food.meat.fried", "90|0|4=жаренное мясо|1|25|8|0|");
        //        ((_1NPC)locations["loc.kzd"]["npc.Leksli"]).bank.Add("item.food.sausage", "90|0|6=колбаса|1|20|9|0|");
        //        ((_1NPC)locations["loc.kzd"]["npc.Leksli"]).bank.Add("item.food.ham", "90|0|2=окорок|1|30|13|0|");

        //        //locations["loc.sl.2"] => item.stand.ressurect"=>"камень воскрешения|Темный обелиск в пол человеческого роста, любой призрак, дотронувшийся до камня, тут же воскресает",

        //        locations["loc.sl.4"]["item.weapon.ranged.stone"] = new _1Item(items["item.weapon.ranged.stone"]);
        //        ((_1Item)locations["loc.sl.4"]["item.weapon.ranged.stone"]).time = 1;
        //        ((_1Item)locations["loc.sl.4"]["item.weapon.ranged.stone"]).respawn = "600|1200|0|8";

        //        locations["loc.sl.5"]["npc.animal.deer.as"] = new _1NPC(npcs["npc.animal.deer"]);
        //        ((_1NPC)locations["loc.sl.5"]["npc.animal.deer.as"]).respawn = "loc.sl.5|600|1200";
        //        ((_1NPC)locations["loc.sl.5"]["npc.animal.deer.as"]).move = "2|20|180";

        //        locations["loc.sl.6"]["item.magic.moss"] = new _1Item(items["item.magic.moss"]);
        //        ((_1Item)locations["loc.sl.6"]["item.magic.moss"]).time = 1;
        //        ((_1Item)locations["loc.sl.6"]["item.magic.moss"]).respawn = "600|1200|2|6";

        //        locations["loc.sl.9"]["npc.animal.dove.ssad"] = new _1NPC(npcs["npc.animal.dove"]);
        //        ((_1NPC)locations["loc.sl.9"]["npc.animal.dove.ssad"]).respawn = "loc.sl.9|600|1200";
        //        ((_1NPC)locations["loc.sl.9"]["npc.animal.dove.ssad"]).move = "10|20|180";

        //        locations["loc.sl.10"]["item.magic.wormwood"] = new _1Item(items["item.magic.wormwood"]);
        //        ((_1Item)locations["loc.sl.10"]["item.magic.wormwood"]).time = 1;
        //        ((_1Item)locations["loc.sl.10"]["item.magic.wormwood"]).respawn = "600|1200|2|8";

        //        locations["loc.sl.11"]["npc.crim.witch.sda"] = new _1NPC(npcs["npc.crim.witch"]);
        //        ((_1NPC)locations["loc.sl.11"]["npc.crim.witch.sda"]).respawn = "loc.sl.11|600|1200";
        //        ((_1NPC)locations["loc.sl.11"]["npc.crim.witch.sda"]).move = "2|20|180";

        //        locations["loc.sl.14"]["npc.crim.wolf.dsf"] = new _1NPC(npcs["npc.crim.wolf"]);
        //        ((_1NPC)locations["loc.sl.14"]["npc.crim.wolf.dsf"]).respawn = "loc.sl.14|600|1200";
        //        ((_1NPC)locations["loc.sl.14"]["npc.crim.wolf.dsf"]).move = "3|20|180";

        //        locations["loc.sl.16"]["item.crystal.adamant"] = new _1Item(items["item.crystal.adamant"]);
        //        ((_1Item)locations["loc.sl.16"]["item.crystal.adamant"]).time = 1;
        //        ((_1Item)locations["loc.sl.16"]["item.crystal.adamant"]).respawn = "600|1200|0|1";

        //        locations["loc.sl.17"]["item.magic.sulphur"] = new _1Item(items["item.magic.sulphur"]);
        //        ((_1Item)locations["loc.sl.17"]["item.magic.sulphur"]).time = 1;
        //        ((_1Item)locations["loc.sl.17"]["item.magic.sulphur"]).respawn = "600|1200|0|4";

        //        locations["loc.vd.2"]["npc.Silvio"] = new _1NPC(npcs["npc.Silvio"]);
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).respawn = "loc.vd.2|1|2";
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).trader = "1.5|1|1200";
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).trader_filter.Add("item.hunter.bone");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).trader_filter.Add("item.magic.sulphur");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).trader_filter.Add("item.magic.coal");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).trader_filter.Add("item.magic.silk");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).trader_filter.Add("item.magic.pearl");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).trader_filter.Add("item.magic.wormwood");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).trader_filter.Add("item.magic.moss");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).bank.Add("item.magic.sulphur", "90|2|8=сера|2|14");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).bank.Add("item.magic.coal", "90|2|8=уголь|4|14");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).bank.Add("item.magic.silk", "90|2|8=паутина|4|14");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).bank.Add("item.magic.pearl", "90|1|4=жемчуг|1|8");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).bank.Add("item.magic.wormwood", "90|2|8=полынь|4|12");
        //        ((_1NPC)locations["loc.vd.2"]["npc.Silvio"]).bank.Add("item.magic.moss", "90|2|8=мох|6|18");

        //        locations["loc.vd.7"]["item.weapon.ranged.stone"] = new _1Item(items["item.weapon.ranged.stone"]);
        //        ((_1Item)locations["loc.vd.7"]["item.weapon.ranged.stone"]).time = 1;
        //        ((_1Item)locations["loc.vd.7"]["item.weapon.ranged.stone"]).respawn = "600|1200|0|8";

        //        locations["loc.vl.1"]["item.crystal.emerald"] = new _1Item(items["item.crystal.emerald"]);
        //        ((_1Item)locations["loc.vl.1"]["item.crystal.emerald"]).time = 1;
        //        ((_1Item)locations["loc.vl.1"]["item.crystal.emerald"]).respawn = "600|1200|0|1";

        //        locations["loc.vl.2"]["npc.crim.orcwarrior.gd"] = new _1NPC(npcs["npc.crim.orcwarrior"]);
        //        ((_1NPC)locations["loc.vl.2"]["npc.crim.orcwarrior.gd"]).respawn = "loc.vl.2|600|1200";
        //        ((_1NPC)locations["loc.vl.2"]["npc.crim.orcwarrior.gd"]).move = "5|20|180";

        //        locations["loc.vl.4"]["npc.crim.snake.saa"] = new _1NPC(npcs["npc.crim.snake"]);
        //        ((_1NPC)locations["loc.vl.4"]["npc.crim.snake.saa"]).respawn = "loc.vl.4|600|1200";
        //        ((_1NPC)locations["loc.vl.4"]["npc.crim.snake.saa"]).move = "3|20|180";

        //        locations["loc.vl.7"]["item.magic.moss"] = new _1Item(items["item.magic.moss"]);
        //        ((_1Item)locations["loc.vl.7"]["item.magic.moss"]).time = 1;
        //        ((_1Item)locations["loc.vl.7"]["item.magic.moss"]).respawn = "600|1200|0|2";

        //        locations["loc.vl.10"]["item.magic.silk"] = new _1Item(items["item.magic.silk"]);
        //        ((_1Item)locations["loc.vl.10"]["item.magic.silk"]).time = 1;
        //        ((_1Item)locations["loc.vl.10"]["item.magic.silk"]).respawn = "600|1200|0|4";

        //        locations["loc.vl.11"]["npc.crim.ogr"] = new _1NPC(npcs["npc.crim.ogr"]);
        //        ((_1NPC)locations["loc.vl.11"]["npc.crim.ogr"]).respawn = "loc.vl.11|600|1200";
        //        ((_1NPC)locations["loc.vl.11"]["npc.crim.ogr"]).move = "7|20|180";

        //        locations["loc.vl.16"]["item.magic.coal"] = new _1Item(items["item.magic.coal"]);
        //        ((_1Item)locations["loc.vl.16"]["item.magic.coal"]).time = 1;
        //        ((_1Item)locations["loc.vl.16"]["item.magic.coal"]).respawn = "600|1200|0|6";

        //        locations["loc.vl.20"]["npc.crim.wolf.jg"] = new _1NPC(npcs["npc.crim.wolf"]);
        //        ((_1NPC)locations["loc.vl.20"]["npc.crim.wolf.jg"]).respawn = "loc.vl.20|600|1200";
        //        ((_1NPC)locations["loc.vl.20"]["npc.crim.wolf.jg"]).move = "3|20|180";

        //        locations["loc.vl.26"]["npc.crim.vampire.kg"] = new _1NPC(npcs["npc.crim.vampire"]);
        //        ((_1NPC)locations["loc.vl.26"]["npc.crim.vampire.kg"]).respawn = "loc.vl.26|600|1200";
        //        ((_1NPC)locations["loc.vl.26"]["npc.crim.vampire.kg"]).move = "3|20|180";

        //        locations["loc.zl.1"]["npc.animal.hare.dss"] = new _1NPC(npcs["npc.animal.hare"]);
        //        ((_1NPC)locations["loc.zl.1"]["npc.animal.hare.dss"]).respawn = "loc.zl.1|600|1200";
        //        ((_1NPC)locations["loc.zl.1"]["npc.animal.hare.dss"]).move = "4|10|60";

        //        locations["loc.zl.4"]["item.crystal.amber"] = new _1Item(items["item.crystal.amber"]);
        //        ((_1Item)locations["loc.zl.4"]["item.crystal.amber"]).time = 1;
        //        ((_1Item)locations["loc.zl.4"]["item.crystal.amber"]).respawn = "600|1200|0|1";

        //        locations["loc.zl.5"]["npc.crim.bear.ds"] = new _1NPC(npcs["npc.crim.bear"]);
        //        ((_1NPC)locations["loc.zl.5"]["npc.crim.bear.ds"]).respawn = "loc.zl.5|600|1200";
        //        ((_1NPC)locations["loc.zl.5"]["npc.crim.bear.ds"]).move = "2|20|180";

        //        locations["loc.zl.6"]["npc.crim.troll.asd"] = new _1NPC(npcs["npc.crim.troll"]);
        //        ((_1NPC)locations["loc.zl.6"]["npc.crim.troll.asd"]).respawn = "loc.zl.6|600|1200";
        //        ((_1NPC)locations["loc.zl.6"]["npc.crim.troll.asd"]).move = "5|20|180";

        //        locations["loc.zl.8"]["npc.animal.fox.da"] = new _1NPC(npcs["npc.animal.fox"]);
        //        ((_1NPC)locations["loc.zl.8"]["npc.animal.fox.da"]).respawn = "loc.zl.8|600|1200";
        //        ((_1NPC)locations["loc.zl.8"]["npc.animal.fox.da"]).move = "3|20|180";

        //        locations["loc.zl.9"]["npc.animal.wildboar.asas"] = new _1NPC(npcs["npc.animal.wildboar"]);
        //        ((_1NPC)locations["loc.zl.9"]["npc.animal.wildboar.asas"]).respawn = "loc.zl.9|600|1200";
        //        ((_1NPC)locations["loc.zl.9"]["npc.animal.wildboar.asas"]).move = "3|20|180";

        //        locations["loc.zl.12"]["npc.crim.wolf.iy"] = new _1NPC(npcs["npc.crim.wolf"]);
        //        ((_1NPC)locations["loc.zl.12"]["npc.crim.wolf.iy"]).respawn = "loc.zl.12|600|1200";
        //        ((_1NPC)locations["loc.zl.12"]["npc.crim.wolf.iy"]).move = "3|20|180";

        //        locations["loc.zl.13"]["npc.animal.cow.ss"] = new _1NPC(npcs["npc.animal.cow"]);
        //        ((_1NPC)locations["loc.zl.13"]["npc.animal.cow.ss"]).respawn = "loc.zl.13|600|1200";

        //        locations["loc.zl.14"]["item.food.healherb"] = new _1Item(items["item.food.healherb"]);
        //        ((_1Item)locations["loc.zl.14"]["item.food.healherb"]).time = 1;
        //        ((_1Item)locations["loc.zl.14"]["item.food.healherb"]).respawn = "600|1200|0|2";

        //        locations["loc.zl.15"]["npc.crim.warriorskeleton.324"] = new _1NPC(npcs["npc.crim.warriorskeleton"]);
        //        ((_1NPC)locations["loc.zl.15"]["npc.crim.warriorskeleton.324"]).respawn = "loc.zl.15|600|1200";
        //        ((_1NPC)locations["loc.zl.15"]["npc.crim.warriorskeleton.324"]).move = "1|20|180";

        //        locations["loc.krestd"]["item.magic.coal"] = new _1Item(items["item.magic.coal"]);
        //        ((_1Item)locations["loc.krestd"]["item.magic.coal"]).time = 1;
        //        ((_1Item)locations["loc.krestd"]["item.magic.coal"]).respawn = "600|1200|0|6";
        //    }

        //    /// <summary>
        //    /// Шаг 6 - Создание описания локаций
        //    /// </summary>
        //    public void CreateLocationDesc()
        //    {
        //        loc_desc["loc.0"] = "Вы стоите на мощенной камнем улице между добротными домами. Человек в нескольких шагах от вас явно хочет с вами поговорить.";
        //        loc_desc["loc.lek1"] = "Небольшой дворик, огороженный аккуратным невысоким забором, вокруг раскинулись кусты сирени и жасмина. Прямо перед вами дверь в дом лекаря, на востоке проход к Академии, на западе выход к банку, а на юг пролегла неширокая мощенная камнем дорога.";
        //        loc_desc["loc.lek"] = "Вы в доме лекаря, вдоль стен стоят две кушетки, а в центре один большой стол, на котором разложены инструменты.";
        //        loc_desc["loc.drag1"] = "Вы перед зданием из дорогих пород дерева, вход украшают две белоснежные колонны. На востоке виднеется дорожка, усыпанная гравием, а на западе мощенная камнем дорога.";
        //        loc_desc["loc.drag"] = "По бокам комнаты расположены стеклянные витрины с кольцами, ожерельями, драгоценными камнями и прочими безделушками. В центре стоит дубовый стол, за закоторым склонился, что-то разглядывая в увеличительное стекло, пожилой мужчина.";
        //        loc_desc["loc.sklad1"] = "Дорога идет с севера на юг и упирается в городскую стену, на востоке виден портовый склад и какой-то магазин, а на западе большие южные ворота.";
        //        loc_desc["loc.sklad2"] = "Дорога идет с востока на запад, рядом расположены двери в портовый склад и какой-то небольшой магазин.";
        //        loc_desc["loc.sklad"] = "Большое помещение портового склада, сплошь заставленное деревянными ящиками, по углам валяются кучи мусора.";
        //        loc_desc["loc.reg"] = "Небольшое полутемное помещение, на столах разложены сушеные травы и какие-то колбочки с разноцветной жидкостью, в углу дымит масляная лампадка.";
        //        loc_desc["loc.jd3"] = "Вы среди похожих друг на друга небольших домов, не слишком многолюдная улица, некоторые окна и двери заколочены крест-накрест досками. Дорога уходит вглубь района на восток, на запад к портовым складам и на север к восточным воротам.";
        //        loc_desc["loc.jd4"] = "Заброшенная часть жилого квартала, под ногами валяется мусор, а полуразрушенные покосившиеся дома смотрят на вас черными провалами выбитых окон. Однако на севере среди деревьев проступают контуры крупного особняка.";
        //        loc_desc["loc.jd2"] = "Вы в самой восточной части города, на юге видны не слишком благополучные дома, на востоке калитка, ведущая к особняку с аккуратно подстриженным газоном. Чуть в стороне на западе начинаются жилые дома более менее зажиточных горожан, а на севере среди тенистых деревьев теряется дорожка, посыпанная гравием.";
        //        loc_desc["loc.jd1"] = "Вокруг стоят симпатичные домики, у многих на окнах цветут цветы или вьется зеленый плющ. На север начинается тенистая аллея, на юге тоже жилые дома, а на востоке на открытом пространстве стоит крупный особняк.";
        //        loc_desc["loc.osobn"] = "Внутри особняка очень просторно, широкая лестница с резными белясинами уходит на второй этаж, делая поворот и образуя небольшую площадку наверху. На окнах дорогие шторы, у стены стоит мягкий диван.";
        //        loc_desc["loc.tenal"] = "Излюбленное место отдыха влюбленных парочек и зажиточных горожан. Солнце искрится среди ветвей высоких стройных деревьев, по сторонам стоят длинные лавочки. Аллея тянется на север вплоть до восточных ворот, на запад отходит небольшая улочка к магазину драгоценностей, а на юге начинается жилой квартал.";
        //        loc_desc["loc.vv"] = "Вы у восточных ворот города, на севере раскинулась восточная торговая площадь, на западе стоит здание Академии, а на юг тянется тенистая аллея.";
        //        loc_desc["loc.vpl"] = "Широкая мощенная камнем площадь, по краям стоят торговые палатки, большинство из них под разноцветными тентами, хотя есть и открытые. На юге находятся восточные ворота.";
        //        loc_desc["loc.ak1"] = "Вы стоите перед Академией - огромным зданием, подъезд которого украшен белыми колоннами, а наверху под позолоченной крышей высечены из мрамора фигуры разных волшебных существ. Рядом притулилась длинная постройка конюшни. На востоке восточные ворота, к юго-западу расположен домик лекаря, а на западе стоит банк.";
        //        loc_desc["loc.bank1"] = "Здание банка, на окнах решетки, двери обиты медью. На востоке высится Академия, на юго-восток уходит дорожка к дому лекаря, на юг тянется широкая мощенная камнем дорога, а на западе начинается центральная площадь.";
        //        loc_desc["loc.bank"] = "Вы в здании банка, здесь два выхода - на юге и западе.";
        //        loc_desc["loc.bank2"] = "Вы у западного входа в банк. Дорога огибает здание банка с двух сторон: на севере видна конюшня, а на юге начинается центральная площадь. Дальше к северо-западу дорога выходит к северным воротам.";
        //        loc_desc["loc.kon1"] = "Дорога проходит мимо конюшни, у входа стоит деревянная телега с сеном и несколько пустых бочек. На востоке площадь перед Академией, на западе здание банка.";
        //        loc_desc["loc.kon"] = "Вы находитесь в конюшне, что расположена в самой северной части города. Вглубь здания тянутся ряды стойл, время от времени оттуда раздается ржание, под ногами валяется солома и... ну, то что кони иногда оставляют на полу...";
        //        loc_desc["loc.centr1"] = "Широкая мощенная камнем дорога тянется прямо к южным воротам, а на севере упирается в банк. На западе стоит здание, над дверью которого висит табличка 'Таверна', на востоке двойное здание, посередине которого на улице трудится кузнец.";
        //        loc_desc["loc.tav"] = "Вы в просторном главном зале таверны. Вокруг царит приятный полумрак, создаваемый десятком свечей и огромным камином, чувствуются манящие запахи со стороны барной стойки. В дальнем углу еще темнее, там немного обособленно стоят несколько столиков. У противоположной стены и у барной стойки лестница на второй этаж.";
        //        loc_desc["loc.tav1"] = "Барная стойка из дорогого темно-красного дерева отполирована до блеска, за стойкой в серванте искрятся в неверном свете камина графины и бутылки с различными напитками. Рядом лестница с резными белясинами на второй этаж.";
        //        loc_desc["loc.tav2"] = "Здесь еще темнее, так как свет от камина сюда почти не доходит. У стены видна лестница на второй этаж.";
        //        loc_desc["loc.tav3"] = "Вы стоите на втором этаже таверны, здесь есть две двери в комнаты и лестницы на первый этаж в концах коридора.";
        //        loc_desc["loc.tav4"] = "Первая комната на втором этаже таверны, ничего особенного - старая кровать у стены и сундук, заменяющий тумбочку.";
        //        loc_desc["loc.tav5"] = "Вторая комната на втором этаже таверны, ничего особенного - старая кровать у стены и сундук, заменяющий тумбочку.";
        //        loc_desc["loc.br"] = "Вы в здании магазина брони, по стенам развешаны кольчуги и разнообразные щиты всех видов. На юге дверь во вторую часть здания, а на западе выход на улицу.";
        //        loc_desc["loc.or"] = "Вы в здании магазина оружия, на стенах развешаны копья и гобелены, изображающие великие сражения, на полках разложены мечи и другое оружие. На севере дверь в другую часть здания, а на западе выход на улицу.";
        //        loc_desc["loc.centr2"] = "Широкая мощенная камнем улица тянется с юга на север, с одной стороны заканчиваясь южными воротами, а с другой упираясь в банк. Прямо перед вами вход в южную часть двойного здания, а чуть ближе к северу на улице работает кузнец.";
        //        loc_desc["loc.kuzn"] = "Между двумя половинками двойного здания на наковальне работает кузнец, а рядом помощник крутит точило, обтачивая какую-то деталь и рассыпая искры. По сторонам расположены двери в двойное здание.";
        //        loc_desc["loc.uv"] = "Вы у южных ворот города, на север идет центральная дорога, на востоке расположены портовые склады, а на западе несколько магазинов и казармы. Прямо за воротами на юге видна река и пристань.";
        //        loc_desc["loc.uz2"] = "Вы в южной части города, дорога идет с востока на запад, на севере вход в магазин припасов, на юге здание с вывеской, на которой нарисован лук и стрелы.";
        //        loc_desc["loc.prip"] = "В этом магине есть все что нужно для путешествия - одежда, факелы, продовольствие и тому подобное.";
        //        loc_desc["loc.luk"] = "Прямо на стене висит мишень для стрельбы из лука, вдоль стен лежат пучки прутьев, в комнате царит запах лака и свежего можжевельника.";
        //        loc_desc["loc.uz1"] = "Вы в южной части города, дорога идет с востока на запад, из магазина на севере доносится лай, мычание и еще какие-то невнятные звуки, а домик на юге весь зарос плющом и диковинными цветами с большими лепестками. На западе стоят несколько длинных одноэтежных деревянных зданий.";
        //        loc_desc["loc.jiv"] = "Вы оказались в настоящем хлеву, на полу грязная солома, слышен визг свиней, кудахтанье кур, лай псов, про запах можно и не говорить...";
        //        loc_desc["loc.but"] = "Темное помещение, из задней двери слышно бульканье, шипение, в воздухе пахнет терпкими травами.";
        //        loc_desc["loc.kaz1"] = "Прямо перед вами не слишком ухоженное одноэтажное длинное здание, на севере начинается небольшая березованя рощица, а дальше на западе стоит темный полуразвалившийся дом.";
        //        loc_desc["loc.kaz"] = "Сквозь щели в стенах солнечные лучи тают в пыли, по строению гуляет сквозняк, вдоль обшарпанных стен стоят ровные ряды коек, около изголовья каждой стоит небольшая тумбочка.";
        //        loc_desc["loc.dv1"] = "Вы оказались около полуразрушенного дома на западе города. Потемневшие стены, давно не ремонтировавшаяся крыша, покосившаяся дверь...  На севере белеют стволы берез.";
        //        loc_desc["loc.dv"] = "В полумраке видна старая и обшарпанная, очень старинная мебель. Тяжелые меховые шторы почти полностью закрывают окна. В углу комнаты есть небольшая дверь.";
        //        loc_desc["loc.dv2"] = "Вы в небольшой комнате, больше похожей на каморку, чем на жилое помещение, хотя у стены стоит кровать, а на письменном столе лежат исписанные листы бумаги и разные безделушки.";
        //        loc_desc["loc.br3"] = "Вы на краю березовой рощи, молодые деревца жадно тянутся к солнцу, под ногами мягкая трава. Вокруг очень красиво, но кажется, жители города не часто сюда заходят...";
        //        loc_desc["loc.br4"] = "Вы в самой западной части города, вглубине березовой рощи. Эти места кажутся совершенно безлюдными и непосещаемыми, если не считать небольших тропинок в густой траве. Правда кто их проложил - люди или нет, остается загадкой... На западе лес упирается в городскую стену.";
        //        loc_desc["loc.br2"] = "Здесь деревья подступают вплотную к городской стене. В тенистом углу, где стена немного изгибается, на траве из больших серых камней выложен ровный круг в несколько шагов диаметром.";
        //        loc_desc["loc.br1"] = "Вы в старой части березовой рощи на западе города, огромные раскидистые березы частично закрывают солнце. Узкие нехоженные тропинки тянутся вглубь леса на запад и по краю рощи на юг. Более ухоженная дорожка ведет к северным воротам.";
        //        loc_desc["loc.sv"] = "За огромными воротами на севере видна широкая дорога, уходящая вглубь леса. На востоке стоит здание банка, а на западе на небольшой площади двухэтажное каменное строение. Небольшая дорожка ведет между этим зданием и забором двора рыцарей в березовую рощу.";
        //        loc_desc["loc.snar"] = "Добротные каменне стены и узкие окна говорят о том, что раньше это здание было аванпостом, но сейчас в нем торгуют снаряжением и охотничьими принадлежностями.";
        //        loc_desc["loc.zvv"] = "Вы за пределами города, на западе находятся восточные ворота, дорога из них идет вдоль городской стены на север, а на востоке начинается лес.";
        //        loc_desc["loc.zsv"] = "Вы за пределами города, на юге находятся северные ворота, дорога из них идет прямиком на север, на северо-востоке видно озеро, а на запад вдоль городской стены уходит небольшая тропинка.";
        //        loc_desc["loc.zb.1"] = "Пропа ведет вдоль изгиба городской стены, на юго-западе видна река, а на севере сплошной стеной встает лес.";
        //        loc_desc["loc.zb.2"] = "Река с запада поворачивает на юг, тропинка идет на север и на юг между городской стеной и рекой.";
        //        loc_desc["loc.zb.3"] = "Тропа идет на север и юг, зажатая между городской стеной и рекой.";
        //        loc_desc["loc.zb.4"] = "Городская стена и река делают поворот на север и восток, тропинка огибает излучину реки.";
        //        loc_desc["loc.zb.5"] = "Городская стена и река идут на запад и восток, поросшая травой тропинка, петляя, стелется вдоль берега и скрывается за поворотом. На востоке видна пристань и за ней южные ворота.";
        //        loc_desc["loc.pristan"] = "Пристань над рекой, на востоке расположен порт, а на запад вдоль городской стены вьется небольшая поросшая травой тропинка. На севере южные ворота в город.";
        //        loc_desc["loc.port1"] = "Портовая площадь завалена пустыми ящиками и мусором, и тянется на восток, на западе расположена пристань и южные ворота.";
        //        loc_desc["loc.port2"] = "Порт оканчивается у юго-восточной части города, дальше на востоке начинается болотистая местность, поросшая кустарником и кривыми низкими деревьями. На западе лежит пристань, а еще дальше южные городские ворота.";
        //        loc_desc["loc.ak"] = "Вы в парадном зале Академии, здесь очень светло благодаря сотням свечей в позолоченных канделябрах под потолком, вдоль стен стоят мраморные статуи волшебных существ в полный рост, в воздухе разлито неяркое голубое сияние, иногда вспыхивают целы рои зеленых и красных огоньков. На востоке видна дверь в волшебный магазин, в дальней части зала вход в библиотеку, в западной части в зал монстрологии, а у дальней стены видна лестница на второй этаж.";
        //        loc_desc["loc.ak4"] = "Вы в волшебном магазине Академии, на столах разложены колбы с красными, зелеными и синими напитками, в воздухе пахнет экзотическими сушеными травами, а на главной стойке в неясном свете масляной лампадки тускло поблескивают амулеты и обереги.";
        //        loc_desc["loc.ak2"] = "Библиотека Академии не зря славится на весь мир: тысячи книг на сотнях полок в тесно заставленных рядах шкафов. Здесь есть как новейшие, только что из-под пера, так и древние тома, готовые рассыпаться прахом при одном прикосновении.";
        //        loc_desc["loc.ak5"] = "В просторном помещении вдоль стены расставлены чучела странных существ, а на самих стенах весят красочные гобелены с изображениями далеких стран и необычных животных.";
        //        loc_desc["loc.ak3"] = "На втором этаже всего один зал, но зато огромный, с мраморным полом и хорошо освещенный. По всему залу рассыпались группы магов и учеников, стоит гул от произносимых заклинаний, временами раздаются хлопки, а цветные витражи на высоких окнах бликуют снопами разноцветных искр.";
        //        loc_desc["loc.cpl"] = "Вы на центральной площади, на западе расположен двор рыцарей, на северо-востоке банк, который можно обойти с двух сторон - севера и востока.";
        //        loc_desc["loc.dvr"] = "Перед вами большой двор, огороженный забором, прямо стоит большое здание с широким крыльцом, на севере здание поменьше, а на юге видны очертания ристалища.";
        //        loc_desc["loc.dvr2"] = "Просторное помещение хорошо освещено, на столах разложены свитки, перья, чернильницы и тому подобные принадлежности.";
        //        loc_desc["loc.dvr4"] = "Обширное помещение освещается свечами в канделябрах, на окнах роскошные дорогие шторы, прямо посередине комнаты стоит огромный прямоугольный стол, а по краям несколько десятков деревянных стульев с высокой спинкой.";
        //        loc_desc["loc.dvr1"] = "Ристалище представляет собой большую хорошо утоптанную овальную площадь, огороженную редким забором со скамьями для зрителей по бокам. Здесь проводят турниры и объезжают лошадей. В дальнем углу ристалища слышен звон мечей, похоже там тренируются воины. А в другом углу стоят мишени для стрельбы из лука.";
        //        loc_desc["loc.dvr5"] = "В этом углу ристалища несколько человек, разбившись по парам, оттачивают воинское искусство. В другом углу виден ряд мишеней для стрельбы из лука.";
        //        loc_desc["loc.dvr3"] = "Несколько мишеней для стрельбы из лука стоят в ряд, на земле под ногами валяются сломанные стрелы. Еще несколько торчат в бревнах забора. В другом углу ристалища слышен звон мечей тренирующихся воинов.";
        //        loc_desc["loc.bl.1"] = "Вы стоите за городскими стенами на юго-востоке от города. На запад идет дорога в порт. На юге течет река. На север и восток простирается болотный лес.";
        //        loc_desc["loc.bl.2"] = "Вы в болотном лесу, под ногами хлюпает жижа, квакают лягушки. На юге река, город на западе.";
        //        loc_desc["loc.bl.3"] = "Вы в болотном лесу, на западе лес вплотную подходит к городской стене.";
        //        loc_desc["loc.bl.4"] = "Вы в болотном лесу, под ногами хлюпает жижа, квакают лягушки. На северо-востоке виден темный овраг.";
        //        loc_desc["loc.bl.5"] = "Вы в болотном лесу за восточной стеной города.";
        //        loc_desc["loc.bl.6"] = "Вы на краю темного сырого оврага, за которым на востоке виден нормальный сухой лес. Овраг тянется на север.";
        //        loc_desc["loc.bl.7"] = "Вы в болотном лесу за восточной стеной города.";
        //        loc_desc["loc.bl.8"] = "Вы на краю темного сырого оврага, за которым на востоке виден нормальный сухой лес. Овраг тянется на юг.";
        //        loc_desc["loc.kl.1"] = "Вы в начале кладбища, на юге калитка, выводящая на дорогу, на севере видно крупное серое каменное строение с небольшим двориком, огороженном решеткой с калиткой посередине. На востоке ряд могил.";
        //        loc_desc["loc.kl.2"] = "Вы идете среди полураскопанных могил вдоль южной ограды кладбища, на востоке стоит какое-то здание, на западе калитка на дорогу.";
        //        loc_desc["loc.kl.3"] = "На востоке темнеет черный провал входа в одноэтажную каменную усыпальницу, с юга вокруг вас ряды могил.";
        //        loc_desc["loc.kl.4"] = "Вы внутри усыпальницы на юго-востоке кладбища. Здесь ничего нет, кроме кучи пыли и нескольких полуистлевших костей на полу в углу.";
        //        loc_desc["loc.kl.5"] = "Вы между двумя усыпальницами на востоке кладбища вплотную к ограде. Жесткая желтованая трава покрывает неровную изрытую почту.";
        //        loc_desc["loc.kl.6"] = "На северо-востоке и юго-востоке видны два одинаковых серых здания, на юге ровные ряды могил.";
        //        loc_desc["loc.kl.7"] = "Вы с восточной стороны от дворика перед цельтральным зданием, огороженного решеткой из железных прутьев. На юге ряд могил.";
        //        loc_desc["loc.kl.8"] = "Вы внутри дворика перед центральным каменным зданием, из черного провала дует ледяной сквозняк с подозрительным запахом.";
        //        loc_desc["loc.kl.9"] = "Вы с западной части дворика перед центральным зданием. На западе видно неболшое болотце, заросшее камышом и кувшинками.";
        //        loc_desc["loc.kl.10"] = "Вы на берегу небольшого болотца, почти полностью заросшего камышом, в черной зеркальной воде плавают цветут несколько кувшинок.";
        //        loc_desc["loc.kl.11"] = "Вы между забором и болотцем на западной части кладбища, отсюда есть только путь к северу или югу.";
        //        loc_desc["loc.kl.12"] = "Вы в юго-западном углу кладбища, черные наконечники железных пуртьев забора угрожающе торчат из листьев какого-то кустарника, растущего вдоль всего забора. На севере видно небольшое болотце.";
        //        loc_desc["loc.kl.13"] = "Вы между забором на юге и болотцем на севере";
        //        loc_desc["loc.kl.14"] = "Вы у южной ограды кладбища, на востоке видна калитка на дорогу, а на северо-западе небольшое болотце.";
        //        loc_desc["loc.kl.15"] = "Вы у южной ограды кладбища. На северо-востоке видно большое серое здание.";
        //        loc_desc["loc.kl.16"] = "Вы у западного забора кладбища, на юге видно небольшое болотце.";
        //        loc_desc["loc.kl.17"] = "Вы на северном берегу болотца, заросшего камышом и кувшинками.";
        //        loc_desc["loc.kl.18"] = "На юго-западе виднеется болотце, на востоке стена каменного здания.";
        //        loc_desc["loc.kl.19"] = "Вы около стены каменного серого здания, под самой стеной свалена куча проволоки и каких-то железок, все вместе сильно заросшее крапивой.";
        //        loc_desc["loc.kl.20"] = "Вы во внутреннем помещении центрального здания. Здесь две двери. Повсюду лежат кучи пыли и царит затхлый воздух.";
        //        loc_desc["loc.kl.21"] = "Вы в небольшом грязном помещении с каменным полом и единственной дверью";
        //        loc_desc["loc.kl.22"] = "Вы в небольшом грязном помещении с каменным полом и единственной дверью";
        //        loc_desc["loc.kl.23"] = "Вы у восточной стены центрального здания, на востоке видно небольшое строение.";
        //        loc_desc["loc.kl.24"] = "Вы у входа в одноэтажную усыпальницу на востоке, на земле видны отпечатки множества ног.";
        //        loc_desc["loc.kl.25"] = "Вы внутри каменной усыпальницы. Пол завален клочками бумаги и прошлогодними листьями.";
        //        loc_desc["loc.kl.26"] = "Вы между двумя усыпальницами и восточным забором кладбища. Отсюда только один уть - на запад.";
        //        loc_desc["loc.kl.27"] = "Вы стоите около трех одинаково выглядящих каменных усыпальниц - на северо-западе, северо-востоке и юго-востоке. Между зданиями есть небольшие проходы.";
        //        loc_desc["loc.kl.28"] = "Вы у входа в каменную усыпальницу на севере, с юго-запада видна задняя стена центрального здания.";
        //        loc_desc["loc.kl.29"] = "Вы у северной стены центрального здания, на северо-западе и северо-востоке стоят похожие одноэтажные каменные здания, между которыми можно пройти.";
        //        loc_desc["loc.kl.30"] = "Вы перед входом в каменное строение, похожее на гробницу, с юго-востока выступает угол центрального здания.";
        //        loc_desc["loc.kl.31"] = "Вы в северо-западной части кладбища, на северо-востоке стоит каменное здание.";
        //        loc_desc["loc.kl.32"] = "Вы в северо-западной части кладбища.";
        //        loc_desc["loc.kl.33"] = "Вы у западной ограды кладбища. Рядом с забором лежит каменная надгробная плита внушительных размеров. У изголовья стоит обколотый обелиск в пол человеческого роста. Мраморная табличка разбита на две части, на той что осталась, выбиты какие-то руны.";
        //        loc_desc["loc.kl.34"] = "Вы в самом северо-западном углу кладбища. За оградой начинается друмучий темный лес.";
        //        loc_desc["loc.kl.35"] = "Вы у северной ограды кладбища.";
        //        loc_desc["loc.kl.36"] = "На востоке стоит каменное сооружение, на севере ограда кладбища.";
        //        loc_desc["loc.kl.37"] = "Вы внутри строения, в полумраке у дальней стены видна темная деревянная дверь.";
        //        loc_desc["loc.kl.38"] = "В углу виден круглый лаз, ведущий куда-то вниз в темноту. К сожалению, лаз придавлен неподъемной каменной плитой, так что сейчас в него не пролезть.";
        //        loc_desc["loc.kl.39"] = "Вы между двумя зданиями и оградой на севере кладбища, отсюда можно выйти только на юг.";
        //        loc_desc["loc.kl.40"] = "Вы в полутемном помещении, кажется, солнечные лучи сюда таинственным  образом не проходят, хотя двери на входе нет. В дальней стене видны очертания двери.";
        //        loc_desc["loc.kl.41"] = "Вы во внутреннем помещении склепа, каменный пол и полное отсутствие света.";
        //        loc_desc["loc.kl.42"] = "Вы в северо-восточной части кладбища между двумя зданиями, на востоке от вас темнее черный провал входа в склеп, а на западе сплошная стена. На севере ограда кладбища.";
        //        loc_desc["loc.kl.43"] = "Склеп изнутри выложен камнем, на стенах видны странные иероглифы, а углы затянуты сплошной паутиной.";
        //        loc_desc["loc.sd.1"] = "Дорога идет на север, на юге расположены северные ворота, с запада подступает лес, а на востоке видно небольшое озеро.";
        //        loc_desc["loc.sd.2"] = "Дорога идет на север и юг мимо большого каменного дома на востоке. На западе сплошной стеной стоит лес.";
        //        loc_desc["loc.sd.3"] = "Дорога идет на юг и север, причем на севере немного поворачивает к западу, по сторонам расстилается лес.";
        //        loc_desc["loc.sd.4"] = "Дорога делает небольшой поворот на запад. Странно, но дальше какая-то сила не дает пройти. Возможно, стоит вернуться сюда в другое время?";
        //        loc_desc["loc.kzd"] = "Вы внутри просторного дома, по стенам развешаны шкуры животных, в воздухе пахнет жареным мясом и дубленой кожей.";
        //        loc_desc["loc.sl.1"] = "Редкий лес с преобладанием березок и осины, на западе видна дорога, на севере за деревьями какое-то каменное строение, а на востоке небольшое озеро можно обогнуть с двух сторон.";
        //        loc_desc["loc.sl.2"] = "Широкая полянка с мягкой низкой травой проходит между озером и северной городской стеной, на востоке виден небольшой пригорок.";
        //        loc_desc["loc.sl.3"] = "Вы находитесь на небольшом пригорке между озером и городской стеной, который ближе к западу сходит пологим спуском к самой воде. На востоке за лесом должны показаться восточные ворота.";
        //        loc_desc["loc.sl.4"] = "Светлое редколесье раскинулось между озером на западе и восточными воротами на востоке, здесь протоптана широкая тропа, очевидно, жители часто посещают этим места. Озеро на западе можно обогнуть с двух направлений. А на северо-востоке вздымаются каменные строения погоста.";
        //        loc_desc["loc.sl.5"] = "Вы идете вдоль озера с северной стороны, здесь оно немного владется в берег, образуя небольшой залив. Ограда кладбища видна с востока и тянется на север. За ней проглядывает болотце, затянутое трясиной.";
        //        loc_desc["loc.sl.6"] = "С этой части озеро заросло кустарником и камышами. Южные ворота находятся на юго-западе.";
        //        loc_desc["loc.sl.7"] = "На западе сквозь деревья видна задняя стена какого-то здания, на юге находится озеро, а на север и восток тянется лес.";
        //        loc_desc["loc.sl.8"] = "Вы рядом с оградой кладбища, поворачивающей с юга на восток. Из-за ограды доносится шорох, хотя из-за серых каменных плит ничего не разглядеть...";
        //        loc_desc["loc.sl.9"] = "Вы в северной части леса, на западе видна дорога. На юге стена какого-то каменнтого здания.";
        //        loc_desc["loc.sl.10"] = "Кругом лес, сквозь который ничего не видно, но кажется на западе что-то есть...";
        //        loc_desc["loc.sl.11"] = "Кругом лес, сквозь который ничего не видно.";
        //        loc_desc["loc.sl.12"] = "Вы находитесь на северо-западном углу кладбища со стороны леса. За оградой видна одинокая могила с каким-то барельефом, отсюда не разобрать точно...";
        //        loc_desc["loc.sl.14"] = "Вы находитесь на северо-восточном углу кладбища, дальше на востоке видны вдалеке горы.";
        //        loc_desc["loc.sl.15"] = "Вы в северо-восточной части леса, на востоке желтеет наезженая дорога, а на западе сквозь ветки виден угол ограды кладбища";
        //        loc_desc["loc.sl.16"] = "Вы идете перелесьем между дорогой на востоке и оградой кладбища на западе. Прямо за оградой высятся каменные погребальные сооружения, поэтому за их стенами нчиего не видно.";
        //        loc_desc["loc.sl.17"] = "Вы стоите на изгибе дороги, на западе от вас ограда кладбища.";
        //        loc_desc["loc.vd.1"] = "Дорога идет на север и около кладбища поворачивает к востоку, обходя его вдоль ограды, на юге видны восточные ворота города, на востоке начинается лес, а на западе поблескивает небольшое озеро.";
        //        loc_desc["loc.vd.2"] = "Вы находитесь около входа на территорию кладбища. Из-за калитки доносятся какие-то завывания, вздохи и подозрительный скрежет. Дорога идет на юг и восток вдоль ограды.";
        //        loc_desc["loc.vd.3"] = "Дорога идет на восток и запад вдоль ограды кладбища, из-за которой доносятся не внушающие особого оптимизма звуки. На юге начинается лес.";
        //        loc_desc["loc.vd.4"] = "Дорога тянется на запад, а на востоке делает поворот к северу, кладбище на северо-западе, со всех остальных сторон начинается лес.";
        //        loc_desc["loc.vd.5"] = "Дорога окружена лесом и идет на север в сторону гор, а на юге делает поворот к западу.";
        //        loc_desc["loc.vd.6"] = "Дорога окружена со всех сторон лесом, на юге выступают горы.";
        //        loc_desc["loc.vd.7"] = "Дорога упирается в пещеру, которая перегорожена грубой решеткой. Похоже, пока что туда не пройти...";
        //        loc_desc["loc.vl.1"] = "Вы на границе болотного и восточного леса на востоке от города. Болотная трава постепенно сменяется более жесткой и низкой, а вдали среди подлеска уже вздымаются могучие дубы и ясени. На юге течет река.";
        //        loc_desc["loc.vl.2"] = "Вы в лесу на востоке от города. Вдали на востоке сереют скалы, а на западе лес спускается в болотистую низину. С южной стороны течет река.";
        //        loc_desc["loc.vl.3"] = "Лес подходит вплотную к скалам на востоке, цепкие молодые деревца упорно карабкаются по неприступному серому камню. С юга путь преграждает река.";
        //        loc_desc["loc.vl.4"] = "Вы на границе болотного леса, на северо-западе виден темный овраг.";
        //        loc_desc["loc.vl.5"] = "Вы в самой глубине леса на востоке от города.";
        //        loc_desc["loc.vl.6"] = "Вы в крайней части леса на востоке от города, дальше на востоке начинаются непроходимые скалы.";
        //        loc_desc["loc.vl.7"] = "Вы на краю темного сырого оврага, за которым на западе тянется болотистая местность. Овраг протянулся на север.";
        //        loc_desc["loc.vl.8"] = "Вы глубине леса на востоке от города, на западе виден темный овраг, а на востоке скалы.";
        //        loc_desc["loc.vl.9"] = "Лес подходит вплотную к скалам на востоке, которые тянутся на север и юг.";
        //        loc_desc["loc.vl.10"] = "Вы на краяю темного сырого оврага, на западе за которым начинается низина, овраг тянется к югу.";
        //        loc_desc["loc.vl.11"] = "Вы в глубине леса на востоке от города.";
        //        loc_desc["loc.vl.12"] = "На востоке скалы, город где-то на западе.";
        //        loc_desc["loc.vl.13"] = "Вы под городскими стенами на востоке от города. К югу почва снижается и растет болотная трава, на востоке виден какой-то овраг, а стена идет на юг и север.";
        //        loc_desc["loc.vl.14"] = "Вы в лесу на востоке от города. На юго-востоке темнеет овраг.";
        //        loc_desc["loc.vl.15"] = "Вы в лесу на востоке от города, на юго-западе темнеет овраг.";
        //        loc_desc["loc.vl.16"] = "Вы в лесу на востоке от города. Еще дальше на востоке над деревьями встают серые скалы.";
        //        loc_desc["loc.vl.17"] = "Вы в лесу на востоке от города, над вами на востоке нависают скалы, лес здесь редкий и невысокий из-за постоянной тени.";
        //        loc_desc["loc.vl.18"] = "Вы вышли в редколесье, на западе сквозь деревья просвечивает дорога и восточне ворота, а на востоке начинается дремучий лес.";
        //        loc_desc["loc.vl.19"] = "Вы в лесу на востоке от города.";
        //        loc_desc["loc.vl.20"] = "Вы в глухом лесу на востоке от города.";
        //        loc_desc["loc.vl.21"] = "Вы в лесу на востоке от города, еще восточней должны показаться скалы.";
        //        loc_desc["loc.vl.22"] = "Вы в лесу на востоке от города, путь на восток преграждают серые скалы.";
        //        loc_desc["loc.vl.23"] = "Вы на краю леса, с западе и севера его огибает дорога, которая отсюда отлично видна. Еще северней выступают каменные постройки кладбища.";
        //        loc_desc["loc.vl.24"] = "Вы в лесу, на севере пролегает дорога, за которой видна ограда кладбища.";
        //        loc_desc["loc.vl.25"] = "Вы в лесу на северо-востоке от города. На севере видна дорога, на востоке и юге лес сгущается.";
        //        loc_desc["loc.vl.26"] = "Вы в лесу на северо-востоке от города, к северо-западу виден изгиб реки, а на востоке высятся скалы.";
        //        loc_desc["loc.vl.27"] = "Лес подступает вплотную к скалам, которые тянутся на юг и север.";
        //        loc_desc["loc.vl.28"] = "Небольшой участок леса, зажатый между дорогой с запада и скалами на востоке.";
        //        loc_desc["loc.vl.29"] = "Небольшой участок леса, зажатый между дорогой с запада и скалами на востоке. Вдали на севере тоже видны горы.";
        //        loc_desc["loc.vl.30"] = "Вы самом дальнем северо-восточном углу лесу, с востока и севера вплотную пдступают горы, на западе видна дорога, уходящая куда-то под гору.";
        //        loc_desc["loc.zl.1"] = "Сразу за дорогой от северных воротам на юго-востоке начинается довольно дремучий лес.";
        //        loc_desc["loc.zl.2"] = "Вас окружает западный лес, на востоке должны находиться северные ворота, а с запада слышен шум воды.";
        //        loc_desc["loc.zl.3"] = "Вы на берегу реки, на юге видна небольшая заросшая травой тропинка вдоль городской стены, река течет на запад. С севера почти к самой воде подступает лес.";
        //        loc_desc["loc.zl.4"] = "Вы на берегу реки, которая течет на восток и запад, за спиной с свернйо стороны дремучий лес.";
        //        loc_desc["loc.zl.5"] = "Вы на берегу реки, которая утекает куда-то вдаль на запад...";
        //        loc_desc["loc.zl.6"] = "Вы в дремучем лесу, с юга слышен шум воды.";
        //        loc_desc["loc.zl.7"] = "Вы в дремучем лесу, с юга еле слышен шум воды.";
        //        loc_desc["loc.zl.8"] = "Вы в дремучем лесу.";
        //        loc_desc["loc.zl.9"] = "Вы в дремучем лесу.";
        //        loc_desc["loc.zl.10"] = "Вокруг темный лес, на востоке чуть-чуть просвечивает сквозь листву дорога.";
        //        loc_desc["loc.zl.11"] = "Лес тянется вдоль дороги, но сразу видно, что места здесь не хоженные...";
        //        loc_desc["loc.zl.12"] = "Северная часть леса, единственный ориентир - дорога на востоке.";
        //        loc_desc["loc.zl.13"] = "Неожиданно в лесу вы натолкнулись на небольшой деревянный дом, огороженный невысоким забором, за которым пасутся куры и домашний скот.";
        //        loc_desc["loc.zl.14"] = "Вы в глухом лесу.";
        //        loc_desc["loc.zl.15"] = "Прямо в лесу, наполовину ушедшее в землю, стоит каменное строение высотой в полтора роста и единственным входом без двери. Вокруг валяется какой-то мусор и видны следы, правда непонятно, кому принадлежащие.";
        //        loc_desc["loc.krestd"] = "Аккуратно прибранная избушка, на столе чистая белая скатерть, а в воздухе пахнет домашним хлебом. Из других предметов домашнего обихода видна кровать у стены и очень старый, весь покрытый пылью, сундук в углу.";
        //    }

        //    /// <summary>
        //    /// Шаг 7 - Создание переходов по локациям
        //    /// </summary>
        //    public void CreateLocationMoves()
        //    {
        //        loc_moves["loc.0"] = "Welcome|1|к лекарю|loc.lek1|к магазину драгоценностей|loc.drag1|по дороге на юг|loc.sklad1";
        //        loc_moves["loc.lek1"] = "Двор лекаря|1|войти в дом|loc.lek|к Академии|loc.ak1|к банку|loc.bank1|на юг|loc.0";
        //        loc_moves["loc.lek"] = "Дом лекаря|1|выйти на улицу|loc.lek1";
        //        loc_moves["loc.drag1"] = "Перед магазином драгоценностей|1|войти в дом|loc.drag|на восток|loc.tenal|на запад|loc.0";
        //        loc_moves["loc.drag"] = "Магазин драгоценностей|1|выйти на улицу|loc.drag1";
        //        loc_moves["loc.sklad1"] = "Дорога к складу|1|к складу|loc.sklad2|к южным воротам|loc.uv|на север|loc.0";
        //        loc_moves["loc.sklad2"] = "Около склада|1|войти в склад|loc.sklad|войти в магазин|loc.reg|на восток|loc.jd3|на запад|loc.sklad1";
        //        loc_moves["loc.sklad"] = "На складе|0|выйти на улицу|loc.sklad2";
        //        loc_moves["loc.reg"] = "Магазин реагентов|1|выйти на улицу|loc.sklad2";
        //        loc_moves["loc.jd3"] = "Жилые дома|1|к складу|loc.sklad2|на восток|loc.jd4|на север|loc.jd1";
        //        loc_moves["loc.jd4"] = "Трущобы|0|на запад|loc.jd3|к особняку|loc.jd2";
        //        loc_moves["loc.jd2"] = "Около особняка|1|к особняку|loc.osobn|на север|loc.tenal|на запад|loc.jd1|в трущобы на юге|loc.jd4";
        //        loc_moves["loc.jd1"] = "Жилые дома|1|к особняку|loc.jd2|к тенистой аллее|loc.tenal|на юг|loc.jd3";
        //        loc_moves["loc.osobn"] = "Особняк|1|выйти из особняка|loc.jd2";
        //        loc_moves["loc.tenal"] = "Тенистая аллея|1|восточные ворота|loc.vv|к магазину|loc.drag1|в жилой район|loc.jd1|в жилой район на восток|loc.jd2";
        //        loc_moves["loc.vv"] = "Восточные ворота|1|выйти из города|loc.zvv|на площадь|loc.vpl|к Академии|loc.ak1|к тенистой аллее|loc.tenal";
        //        loc_moves["loc.vpl"] = "Восточная площадь|1|к восточным воротам|loc.vv";
        //        loc_moves["loc.ak1"] = "Перед Академией|1|войти в Академию|loc.ak|к конюшне|loc.kon1|к восточным воротам|loc.vv|к дому лекаря|loc.lek1|к банку|loc.bank1";
        //        loc_moves["loc.bank1"] = "Перед банком|1|войти в банк|loc.bank|к Академии|loc.ak1|к лекарю|loc.lek1|на юг|loc.centr1|на запад|loc.cpl";
        //        loc_moves["loc.bank"] = "В банке|1|южная дверь|loc.bank1|западная дверь|loc.bank2";
        //        loc_moves["loc.bank2"] = "Около банка|1|войти в банк|loc.bank|к конюшне|loc.kon1|на площадь|loc.cpl|к северным воротам|loc.sv";
        //        loc_moves["loc.kon1"] = "Около конюшни|1|войти в конюшню|loc.kon|к Академии|loc.ak1|к банку|loc.bank2";
        //        loc_moves["loc.kon"] = "В конюшне|1|выйти на улицу|loc.kon1";
        //        loc_moves["loc.centr1"] = "Центральная дорога|1|к банку|loc.bank1|войти в таверну|loc.tav|подойти к кузнецу|loc.kuzn|войти в двойное здание|loc.br|на юг|loc.centr2";
        //        loc_moves["loc.tav"] = "Таверна|1|выйти из таверны|loc.centr1|подойти к барной стойке|loc.tav1|в дальний угол|loc.tav2";
        //        loc_moves["loc.tav1"] = "Таверна|1|на второй этаж|loc.tav3|в дальний угол|loc.tav2|к выходу из таверны|loc.tav";
        //        loc_moves["loc.tav2"] = "Таверна|1|на второй этаж|loc.tav3|подойти к барной стойке|loc.tav1|к выходу из таверны|loc.tav";
        //        loc_moves["loc.tav3"] = "Таверна|1|войти в первую дверь|loc.tav4|войти во вторую дверь|loc.tav5|южная лестница на первый этаж|loc.tav1|северная лестница на первый этаж|loc.tav2";
        //        loc_moves["loc.tav4"] = "Таверна|1|выйти в корридор|loc.tav3";
        //        loc_moves["loc.tav5"] = "Таверна|1|выйти в корридор|loc.tav3";
        //        loc_moves["loc.br"] = "Магазин брони|1|выйти на улицу|loc.centr1|перейти в дверь на юге|loc.or";
        //        loc_moves["loc.or"] = "Магазин оружия|1|выйти на улицу|loc.centr2|перейти в дверь на севере|loc.br";
        //        loc_moves["loc.centr2"] = "Центральная улица|1|подойти к кузнецу|loc.kuzn|войти в двойное здание|loc.or|к южным воротам|loc.uv|на север|loc.centr1";
        //        loc_moves["loc.kuzn"] = "Кузница|1|войти в северную дверь|loc.br|войти в южную дверь|loc.or|на север|loc.centr1|на юг|loc.centr2";
        //        loc_moves["loc.uv"] = "Южные ворота|1|на север|loc.centr2|на восток|loc.sklad1|на запад|loc.uz2|выйти за город|loc.pristan";
        //        loc_moves["loc.uz2"] = "Торговый квартал|1|войти в магазин припасов|loc.prip|войти в магазин на юге|loc.luk|на восток к южным воротам|loc.uv|на запад|loc.uz1";
        //        loc_moves["loc.prip"] = "Магазин припасов|1|выйти на улицу|loc.uz2";
        //        loc_moves["loc.luk"] = "Магазин для лучников|1|выйти на улицу|loc.uz2";
        //        loc_moves["loc.uz1"] = "Торговый квартал|1|войти в магазин на севере|loc.jiv|войти в магазин на юге|loc.but|на запад|loc.kaz1|на восток|loc.uz2";
        //        loc_moves["loc.jiv"] = "Магазин Животные|1|выйти на улицу|loc.uz1";
        //        loc_moves["loc.but"] = "Магазин напитков|1|выйти на улицу|loc.uz1";
        //        loc_moves["loc.kaz1"] = "Перед казармами|1|войти в казарму|loc.kaz|к березовой роще|loc.br3|на запад|loc.dv1|на восток|loc.uz1";
        //        loc_moves["loc.kaz"] = "Казармы|1|выйти на улицу|loc.kaz1";
        //        loc_moves["loc.dv1"] = "Около старого дома|1|войти в старый дом|loc.dv|к березовой роще|loc.br3|на восток|loc.kaz1";
        //        loc_moves["loc.dv"] = "Старый дом|0|выйти на улицу|loc.dv1|дверь в углу|loc.dv2";
        //        loc_moves["loc.dv2"] = "Старый дом|0|выйти из комнаты|loc.dv";
        //        loc_moves["loc.br3"] = "Березовая роща|0|к старому дому|loc.dv1|к казармам|loc.kaz1|на запад|loc.br4|на север|loc.br1";
        //        loc_moves["loc.br4"] = "Березовая роща|0|на восток|loc.br3|на север|loc.br2";
        //        loc_moves["loc.br2"] = "Березовая роща|0|на восток|loc.br1|на юг|loc.br4";
        //        loc_moves["loc.br1"] = "Березовая роща|1|к северным воротам|loc.sv|тропинка на запад|loc.br2|тропинка на юг|loc.br3";
        //        loc_moves["loc.sv"] = "Северные ворота|1|выйти из города|loc.zsv|войти в здание|loc.snar|к банку|loc.bank2|к березовой роще|loc.br1";
        //        loc_moves["loc.snar"] = "Магазин снаряжения|1|выйти из здания|loc.sv";
        //        loc_moves["loc.zvv"] = "За восточными воротами|0|войти в город|loc.vv|дорога на север|loc.vd.1|лес на востоке|loc.vl.18";
        //        loc_moves["loc.zsv"] = "За северными воротами|0|войти в город|loc.sv|дорога на север|loc.sd.1|тропинка на запад|loc.zb.1";
        //        loc_moves["loc.zb.1"] = "Западный берег|0|к северным воротам|loc.zsv|лес на север|loc.zl.3|тропа на юг|loc.zb.2";
        //        loc_moves["loc.zb.2"] = "Западный берег|0|тропа на север|loc.zb.1|тропа на юг|loc.zb.3";
        //        loc_moves["loc.zb.3"] = "Западный берег|0|тропа на севере|loc.zb.2|тропа на юг|loc.zb.4";
        //        loc_moves["loc.zb.4"] = "Западный берег|0|тропа на север|loc.zb.3|тропа на восток|loc.zb.5";
        //        loc_moves["loc.zb.5"] = "Западный берег|0|тропа на запад|loc.zb.4|пристань на восток|loc.pristan";
        //        loc_moves["loc.pristan"] = "Пристань|1|войти в город|loc.uv|тропа на запад|loc.zb.5|в порт|loc.port1";
        //        loc_moves["loc.port1"] = "Порт|1|на пристань|loc.pristan|на восток|loc.port2";
        //        loc_moves["loc.port2"] = "Порт|0|в лес на востоке|loc.bl.1|на запад|loc.port1";
        //        loc_moves["loc.ak"] = "Академия|1|выйти на улицу|loc.ak1|войти в магазин|loc.ak4|в библиотеку|loc.ak2|в зал монстрологии|loc.ak5|на второй этаж|loc.ak3";
        //        loc_moves["loc.ak4"] = "Волшебный магазин|1|выйти в парадный зал|loc.ak";
        //        loc_moves["loc.ak2"] = "Библиотека|1|выйти в парадный зал|loc.ak";
        //        loc_moves["loc.ak5"] = "Зал монстрологии|1|выйти в парадный зал|loc.ak";
        //        loc_moves["loc.ak3"] = "Академия|1|спуститься на первый этаж|loc.ak";
        //        loc_moves["loc.cpl"] = "Центральная площадь|1|к банку на север|loc.bank2|к банку на восток|loc.bank1|во двор рыцарей|loc.dvr";
        //        loc_moves["loc.dvr"] = "Двор рыцарей|1|выйти на площадь|loc.cpl|войти в главное здание|loc.dvr4|войти в здание на севере|loc.dvr2|к ристалищу|loc.dvr1";
        //        loc_moves["loc.dvr2"] = "Двор рыцарей|1|выйти во двор|loc.dvr";
        //        loc_moves["loc.dvr4"] = "Двор рыцарей|1|выйти во двор|loc.dvr";
        //        loc_moves["loc.dvr1"] = "Ристалище|1|выйти во двор|loc.dvr|подойти к мечникам|loc.dvr5|подойти к мишеням|loc.dvr3";
        //        loc_moves["loc.dvr5"] = "Ристалище|1|ко входу в ристалище|loc.dvr1|подойти к мишеням|loc.dvr3";
        //        loc_moves["loc.dvr3"] = "Ристалище|1|ко входу в ристалище|loc.dvr1|подойти к мечникам|loc.dvr5";
        //        loc_moves["loc.bl.1"] = "Болотный лес|0|север|loc.bl.3|восток|loc.bl.2|на запад в порт|loc.port2";
        //        loc_moves["loc.bl.2"] = "Болотный лес|0|север|loc.bl.4|восток|loc.vl.1|запад|loc.bl.1";
        //        loc_moves["loc.bl.3"] = "Болотный лес|0|север|loc.bl.5|восток|loc.bl.4|юг|loc.bl.1";
        //        loc_moves["loc.bl.4"] = "Болотный лес|0|север|loc.bl.6|восток|loc.vl.4|юг|loc.bl.2|запад|loc.bl.3";
        //        loc_moves["loc.bl.5"] = "Болотный лес|0|север|loc.bl.7|восток|loc.bl.6|юг|loc.bl.3";
        //        loc_moves["loc.bl.6"] = "Болотный лес|0|север|loc.bl.8|перейти овраг восток|loc.vl.7|юг|loc.bl.4|на запад|loc.bl.5";
        //        loc_moves["loc.bl.7"] = "Болотный лес|0|север|loc.vl.13|восток|loc.bl.8|юг|loc.bl.5";
        //        loc_moves["loc.bl.8"] = "Болотный лес|0|север|loc.vl.14|перейти овраг на восток|loc.vl.10|юг|loc.bl.6|запад|loc.bl.7";
        //        loc_moves["loc.kl.1"] = "Кладбище|0|выйти на дорогу|loc.vd.2|войти в калитку|loc.kl.8|восток|loc.kl.2|запад|loc.kl.15";
        //        loc_moves["loc.kl.2"] = "Кладбище|0|север|loc.kl.7|вдоль ограды на восток|loc.kl.3|к калитке на запад|loc.kl.1";
        //        loc_moves["loc.kl.3"] = "Кладбище|0|войти в усыпальницу|loc.kl.4|вдоль ограды на запад|loc.kl.2|север|loc.kl.6";
        //        loc_moves["loc.kl.4"] = "Кладбище|0|выйти|loc.kl.3";
        //        loc_moves["loc.kl.5"] = "Кладбище|0|запад|loc.kl.6";
        //        loc_moves["loc.kl.6"] = "Кладбище|0|север|loc.kl.24|восток|loc.kl.5|юг|loc.kl.3|запад|loc.kl.7";
        //        loc_moves["loc.kl.7"] = "Кладбище|0|север|loc.kl.23|восток|loc.kl.6|юг|loc.kl.2";
        //        loc_moves["loc.kl.8"] = "Кладбище|0|войти в здание|loc.kl.20|выйти в калитку на юге|loc.kl.1";
        //        loc_moves["loc.kl.9"] = "Кладбище|0|север|loc.kl.19|юг|loc.kl.15|запад|loc.kl.10";
        //        loc_moves["loc.kl.10"] = "Кладбище|0|север|loc.kl.18|восток|loc.kl.9|юг|loc.kl.14";
        //        loc_moves["loc.kl.11"] = "Кладбище|0|вдоль забора на север|loc.kl.16|вдоль забора на юг|loc.kl.12";
        //        loc_moves["loc.kl.12"] = "Кладбище|0|вдоль забора на север|loc.kl.11|вдоль забора на восток|loc.kl.13";
        //        loc_moves["loc.kl.13"] = "Кладбище|0|вдоль забора восток|loc.kl.14|вдоль забора запад|loc.kl.12";
        //        loc_moves["loc.kl.14"] = "Кладбище|0|север|loc.kl.10|восток|loc.kl.15|запад|loc.kl.13";
        //        loc_moves["loc.kl.15"] = "Кладбище|0|север|loc.kl.9|восток|loc.kl.1|запад|loc.kl.14";
        //        loc_moves["loc.kl.16"] = "Кладбище|0|север|loc.kl.33|восток|loc.kl.17|юг|loc.kl.11";
        //        loc_moves["loc.kl.17"] = "Кладбище|0|север|loc.kl.32|восток|loc.kl.18|запад|loc.kl.16";
        //        loc_moves["loc.kl.18"] = "Кладбище|0|север|loc.kl.31|восток|loc.kl.19|юг|loc.kl.10|запад|loc.kl.17";
        //        loc_moves["loc.kl.19"] = "Кладбище|0|север|loc.kl.30|юг|loc.kl.9|запад|loc.kl.18";
        //        loc_moves["loc.kl.20"] = "Кладбище|0|войти в северную дверь|loc.kl.22|войти в восточную дверь|loc.kl.21|выйти на улицу|loc.kl.8";
        //        loc_moves["loc.kl.21"] = "Кладбище|0|выйти|loc.kl.20";
        //        loc_moves["loc.kl.22"] = "Кладбище|0|выйти|loc.kl.20";
        //        loc_moves["loc.kl.23"] = "Кладбище|0|север|loc.kl.28|восток|loc.kl.24|юг|loc.kl.7";
        //        loc_moves["loc.kl.24"] = "Кладбище|0|войти в усыпальницу|loc.kl.25|север|loc.kl.27|юг|loc.kl.6|запад|loc.kl.23";
        //        loc_moves["loc.kl.25"] = "Кладбище|0|выйти на улицу|loc.kl.24";
        //        loc_moves["loc.kl.26"] = "Кладбище|0|запад|loc.kl.27";
        //        loc_moves["loc.kl.27"] = "Кладбище|0|север|loc.kl.42|восток|loc.kl.26|юг|loc.kl.24|запад|loc.kl.28";
        //        loc_moves["loc.kl.28"] = "Кладбище|0|войти в усыпальницу|loc.kl.40|восток|loc.kl.27|юг|loc.kl.23|запад|loc.kl.29";
        //        loc_moves["loc.kl.29"] = "Кладбище|0|север|loc.kl.39|восток|loc.kl.28|запад|loc.kl.30";
        //        loc_moves["loc.kl.30"] = "Кладбище|0|войти в строение|loc.kl.37|восток|loc.kl.29|юг|loc.kl.19|запад|loc.kl.31";
        //        loc_moves["loc.kl.31"] = "Кладбище|0|север|loc.kl.36|восток|loc.kl.30|юг|loc.kl.18|запад|loc.kl.32";
        //        loc_moves["loc.kl.32"] = "Кладбище|0|север|loc.kl.35|восток|loc.kl.31|юг|loc.kl.17|запад|loc.kl.33";
        //        loc_moves["loc.kl.33"] = "Кладбище|0|север|loc.kl.34|восток|loc.kl.32|юг|loc.kl.16";
        //        loc_moves["loc.kl.34"] = "Кладбище|0|вдоль ограды на восток|loc.kl.35|вдоль ограды на юг|loc.kl.33";
        //        loc_moves["loc.kl.35"] = "Кладбище|0|восток|loc.kl.36|юг|loc.kl.32|запад|loc.kl.34";
        //        loc_moves["loc.kl.36"] = "Кладбище|0|юг|loc.kl.31|запад|loc.kl.35";
        //        loc_moves["loc.kl.37"] = "Кладбище|0|войти в дверь|loc.kl.38|выйти на улицу|loc.kl.30";
        //        loc_moves["loc.kl.38"] = "Кладбище|0|выйти|loc.kl.37";
        //        loc_moves["loc.kl.39"] = "Кладбище|0|юг|loc.kl.29";
        //        loc_moves["loc.kl.40"] = "Кладбище|0|войти в дверь|loc.kl.41|выйти на улицу|loc.kl.28";
        //        loc_moves["loc.kl.41"] = "Кладбище|0|выйти|loc.kl.40";
        //        loc_moves["loc.kl.42"] = "Кладбище|0|войти в склеп|loc.kl.43|юг|loc.kl.27";
        //        loc_moves["loc.kl.43"] = "Кладбище|0|выйти на улицу|loc.kl.42";
        //        loc_moves["loc.sd.1"] = "Северная дорога|0|дорога на север|loc.sd.2|к северным воротам|loc.zsv|к озеру на восток|loc.sl.1|лес на западе|loc.zl.1";
        //        loc_moves["loc.sd.2"] = "Северная дорога|0|войти в дом|loc.kzd|дорога на север|loc.sd.3|дорога на юг|loc.sd.1|на запад|loc.zl.10";
        //        loc_moves["loc.sd.3"] = "Северная дорога|0|дорога на север|loc.sd.4|лес на востоке|loc.sl.9|дорога на юг|loc.sd.2|лес на западе|loc.zl.11";
        //        loc_moves["loc.sd.4"] = "Северная дорога|0|дорога на юг|loc.sd.3|лес на западе|loc.zl.12";
        //        loc_moves["loc.kzd"] = "Дом у дороги|0|выйти на улицу|loc.sd.2";
        //        loc_moves["loc.sl.1"] = "Северный лес|0|дорога на севере|loc.sd.1|обогнуть озеро с севера|loc.sl.6|обогнуть озеро с юга|loc.sl.2";
        //        loc_moves["loc.sl.2"] = "Северный лес|0|вдоль берега на восток|loc.sl.3|лес на западе|loc.sl.1";
        //        loc_moves["loc.sl.3"] = "Северный лес|0|вдоль берега на запад|loc.sl.2|на восток|loc.sl.4";
        //        loc_moves["loc.sl.4"] = "Северный лес|0|на дорогу к воротам|loc.vd.1|на северо-восток|loc.vd.2|обогнуть озеро с севера|loc.sl.5|обогнуть озеро с юга|loc.sl.3";
        //        loc_moves["loc.sl.5"] = "Северный лес|0|на север вдоль забора|loc.sl.8|вдоль берега на запад|loc.sl.6|на юго-восток|loc.sl.4";
        //        loc_moves["loc.sl.6"] = "Северный лес|0|в лес на севере|loc.sl.7|вдоль берега на восток|loc.sl.5|на юго-запад|loc.sl.1";
        //        loc_moves["loc.sl.7"] = "Северный лес|0|к озеру|loc.sl.6|север|loc.sl.10|восток|loc.sl.8";
        //        loc_moves["loc.sl.8"] = "Северный лес|0|на юг к озеру|loc.sl.5|север|loc.sl.11|запад|loc.sl.7";
        //        loc_moves["loc.sl.9"] = "Северный лес|0|дорога на западе|loc.sd.3|на восток|loc.sl.10";
        //        loc_moves["loc.sl.10"] = "Северный лес|0|восток|loc.sl.11|юг|loc.sl.7|запад|loc.sl.9";
        //        loc_moves["loc.sl.11"] = "Северный лес|0|восток|loc.sl.12|юг|loc.sl.8|запад|loc.sl.10";
        //        loc_moves["loc.sl.12"] = "Северный лес|0|восток|loc.sl.14|запад|loc.sl.11";
        //        loc_moves["loc.sl.14"] = "Северный лес|0|восток|loc.sl.15|запад|loc.sl.12";
        //        loc_moves["loc.sl.15"] = "Северный лес|0|дорога на востоке|loc.vd.7|вдоль кладбища на юг|loc.sl.16|вдоль кладбища на запад|loc.sl.14";
        //        loc_moves["loc.sl.16"] = "Северный лес|0|дорога на востоке|loc.vd.6|на север|loc.sl.15|на юг|loc.sl.17";
        //        loc_moves["loc.sl.17"] = "Северный лес|0|дорога на востоке|loc.vd.5|дорога на юге|loc.vd.4|на север|loc.sl.16";
        //        loc_moves["loc.vd.1"] = "Восточная дорога|0|дорога на севере|loc.vd.2|лес на востоке|loc.vl.23|ворота на юге|loc.zvv|к озеру на западе|loc.sl.4";
        //        loc_moves["loc.vd.2"] = "Восточная дорога|0|войти в калитку|loc.kl.1|по дороге на восток|loc.vd.3|по дороге на юг|loc.vd.1|на запад|loc.sl.4|в лес на юге|loc.vl.23";
        //        loc_moves["loc.vd.3"] = "Восточная дорога|0|дорога на восток|loc.vd.4|лес на юге|loc.vl.24|дорога на запад|loc.vd.2";
        //        loc_moves["loc.vd.4"] = "Восточная дорога|0|север|loc.sl.17|дорога на восток|loc.vd.5|юг|loc.vl.25|дорога на запад|loc.vd.3";
        //        loc_moves["loc.vd.5"] = "Восточная дорога|0|дорога на север|loc.vd.6|восток|loc.vl.28|дорога на юг|loc.vd.4|запад|loc.sl.17";
        //        loc_moves["loc.vd.6"] = "Восточная дорога|0|дорога на север|loc.vd.7|восток|loc.vl.29|дорога на юг|loc.vd.5|запад|loc.sl.16";
        //        loc_moves["loc.vd.7"] = "Восточная дорога|0|восток|loc.vl.30|дорога на юг|loc.vd.6|запад|loc.sl.15";
        //        loc_moves["loc.vl.1"] = "Восточный лес|0|север|loc.vl.4|восток|loc.vl.2|запад|loc.bl.2";
        //        loc_moves["loc.vl.2"] = "Восточный лес|0|север|loc.vl.5|восток|loc.vl.3|запад|loc.vl.1";
        //        loc_moves["loc.vl.3"] = "Восточный лес|0|север|loc.vl.6|запад|loc.vl.2";
        //        loc_moves["loc.vl.4"] = "Восточный лес|0|север|loc.vl.7|восток|loc.vl.5|юг|loc.vl.1|запад|loc.bl.4";
        //        loc_moves["loc.vl.5"] = "Восточный лес|0|север|loc.vl.8|восток|loc.vl.6|юг|loc.vl.2|запад|loc.vl.4";
        //        loc_moves["loc.vl.6"] = "Восточный лес|0|север|loc.vl.9|юг|loc.vl.3|запад|loc.vl.5";
        //        loc_moves["loc.vl.7"] = "Восточный лес|0|север|loc.vl.10|восток|loc.vl.8|юг|loc.vl.4|перейти овраг на запад|loc.bl.6";
        //        loc_moves["loc.vl.8"] = "Восточный лес|0|север|loc.vl.11|восток|loc.vl.9|юг|loc.vl.5|запад|loc.vl.7";
        //        loc_moves["loc.vl.9"] = "Восточный лес|0|север|loc.vl.12|юг|loc.vl.6|запад|loc.vl.8";
        //        loc_moves["loc.vl.10"] = "Восточный лес|0|север|loc.vl.15|восток|loc.vl.11|юг|loc.vl.7|перейти овраг на запад|loc.bl.8";
        //        loc_moves["loc.vl.11"] = "Восточный лес|0|север|loc.vl.16|восток|loc.vl.12|юг|loc.vl.8|запад|loc.vl.10";
        //        loc_moves["loc.vl.12"] = "Восточный лес|0|север|loc.vl.17|юг|loc.vl.9|запад|loc.vl.11";
        //        loc_moves["loc.vl.13"] = "Восточный лес|0|север|loc.vl.18|восток|loc.vl.14|юг|loc.bl.7";
        //        loc_moves["loc.vl.14"] = "Восточный лес|0|север|loc.vl.19|восток|loc.vl.15|юг|loc.bl.8|запад|loc.vl.13";
        //        loc_moves["loc.vl.15"] = "Восточный лес|0|север|loc.vl.20|восток|loc.vl.16|юг|loc.vl.10|запад|loc.vl.14";
        //        loc_moves["loc.vl.16"] = "Восточный лес|0|север|loc.vl.21|восток|loc.vl.17|юг|loc.vl.11|запад|loc.vl.15";
        //        loc_moves["loc.vl.17"] = "Восточный лес|0|север|loc.vl.22|юг|loc.vl.12|запад|loc.vl.16";
        //        loc_moves["loc.vl.18"] = "Восточный лес|0|север|loc.vl.23|восток|loc.vl.19|юг|loc.vl.13|на дорогу|loc.zvv";
        //        loc_moves["loc.vl.19"] = "Восточный лес|0|север|loc.vl.24|восток|loc.vl.20|юг|loc.vl.14|запад|loc.vl.18";
        //        loc_moves["loc.vl.20"] = "Восточный лес|0|север|loc.vl.25|восток|loc.vl.21|юг|loc.vl.15|запад|loc.vl.19";
        //        loc_moves["loc.vl.21"] = "Восточный лес|0|север|loc.vl.26|восток|loc.vl.22|юг|loc.vl.16|запад|loc.vl.20";
        //        loc_moves["loc.vl.22"] = "Восточный лес|0|север|loc.vl.27|юг|loc.vl.17|запад|loc.vl.21";
        //        loc_moves["loc.vl.23"] = "Восточный лес|0|север|loc.vd.2|восток|loc.vl.24|юг|loc.vl.18|запад|loc.vd.1";
        //        loc_moves["loc.vl.24"] = "Восточный лес|0|север|loc.vd.3|восток|loc.vl.25|юг|loc.vl.19|запад|loc.vl.23";
        //        loc_moves["loc.vl.25"] = "Восточный лес|0|север|loc.vd.4|восток|loc.vl.26|юг|loc.vl.20|запад|loc.vl.24";
        //        loc_moves["loc.vl.26"] = "Восточный лес|0|север|loc.vl.28|восток|loc.vl.27|юг|loc.vl.21|запад|loc.vl.25";
        //        loc_moves["loc.vl.27"] = "Восточный лес|0|север|loc.vl.28|юг|loc.vl.22|запад|loc.vl.26";
        //        loc_moves["loc.vl.28"] = "Восточный лес|0|север|loc.vl.29|юг|loc.vl.26|юго-восток|loc.vl.27|запад|loc.vd.5";
        //        loc_moves["loc.vl.29"] = "Восточный лес|0|север|loc.vl.30|юг|loc.vl.28|запад|loc.vd.6";
        //        loc_moves["loc.vl.30"] = "Восточный лес|0|юг|loc.vl.29|на дорогу|loc.vd.7";
        //        loc_moves["loc.zl.1"] = "Западный лес|0|к северным воротам|loc.sd.1|север|loc.zl.10|запад|loc.zl.2";
        //        loc_moves["loc.zl.2"] = "Западный лес|0|север|loc.zl.9|восток|loc.zl.1|запад|loc.zl.3";
        //        loc_moves["loc.zl.3"] = "Западный лес|0|на тропу на юге|loc.zb.1|вдоль реки на запад|loc.zl.4|север|loc.zl.8|восток|loc.zl.2";
        //        loc_moves["loc.zl.4"] = "Западный лес|0|вдоль реки на восток|loc.zl.3|вдоль реки на запад|loc.zl.5|север|loc.zl.7";
        //        loc_moves["loc.zl.5"] = "Западный лес|0|вдоль реки на восток|loc.zl.4|на север|loc.zl.6";
        //        loc_moves["loc.zl.6"] = "Западный лес|0|север|loc.zl.15|восток|loc.zl.7|юг|loc.zl.5";
        //        loc_moves["loc.zl.7"] = "Западный лес|0|север|loc.zl.14|запад|loc.zl.6|юг|loc.zl.4|восток|loc.zl.8";
        //        loc_moves["loc.zl.8"] = "Западный лес|0|север|loc.zl.13|восток|loc.zl.9|юг|loc.zl.3|запад|loc.zl.7";
        //        loc_moves["loc.zl.9"] = "Западный лес|0|север|loc.zl.12|восток|loc.zl.10|юг|loc.zl.2|запад|loc.zl.8";
        //        loc_moves["loc.zl.10"] = "Западный лес|0|дорога на востоке|loc.sd.2|север|loc.zl.11|юг|loc.zl.1|запад|loc.zl.9";
        //        loc_moves["loc.zl.11"] = "Западный лес|0|дорога на востоке|loc.sd.3|на северо-запад|loc.zl.12|вдоль дороги на юг|loc.zl.10";
        //        loc_moves["loc.zl.12"] = "Западный лес|0|дорога на востоке|loc.sd.4|на юго-восток|loc.zl.11|юг|loc.zl.9|запад|loc.zl.13";
        //        loc_moves["loc.zl.13"] = "Западный лес|0|войти в дом|loc.krestd|восток|loc.zl.12|юг|loc.zl.8|запад|loc.zl.14";
        //        loc_moves["loc.zl.14"] = "Западный лес|0|восток|loc.zl.13|юг|loc.zl.7|запад|loc.zl.15";
        //        loc_moves["loc.zl.15"] = "Западный лес|0|восток|loc.zl.14|юг|loc.zl.6";
        //        loc_moves["loc.krestd"] = "Крестьянский дом|0|выйти на улицу|loc.zl.13";
        //    }

        //    /// <summary>
        //    /// Шаг 8 - Создание диалогов
        //    /// </summary>
        //    public void CreateDialogs()
        //    {
        //        arr_speak["npc.guard"] = new Dictionary<string, string>();
        //        arr_speak["npc.guard"]["begin"] = "Что ты хочешь узнать?|Кто вы?|who|Что вы здесь делаете?|what|А где тут...|where|Нет, ничего, я ошибся|end";
        //        arr_speak["npc.guard"]["who"] = "Мы городская стража, разве не это не заметно?|И чем вы занимаетесь?|what|Городская стража?|who2|Понятно, ну, мне пора...|end";
        //        arr_speak["npc.guard"]["what"] = "Мы защищаем мирных граждан от преступников и всякой нечисти, что прет из окрестных лесов.|Ух-ты! А можно мне с вами?|help|Каких преступников?|prest|Ясно|begin";
        //        arr_speak["npc.guard"]["where"] = "Эй, я же на службе и в мои обязанности не входит работать путеводителем.|Ок, сменим тему|begin|А что входит?|what|Тогда не буду мешать|end";
        //        arr_speak["npc.guard"]["who2"] = "Ну да, отборные войска, лучшие из лучших и все такое. Вот будет заварушка, убедишься сам.|Я тоже хочу стать стражником!|can|Хм.. много чести разговаривать с таким хвастуном...|end";
        //        arr_speak["npc.guard"]["can"] = "Вряд ли у тебя получится, чтобы стать городским стражником, надо быть действительно лучшим, а кроме того, примерным горожанином. Поживи здесь, познакомься с людьми и тогда посмотрим...|Так все-таки, как стать стражником?|imp|Эээ... Я передумал...|begin";
        //        arr_speak["npc.guard"]["imp"] = "[сердится] Как да как, вот пристал. Как только так сразу! Не задавай дурацких вопросов!|Хорошо, не буду|begin";
        //        arr_speak["npc.guard"]["prest"] = "Ну, воришек там всяких, убийц и тому подобной дряни. А также тех кто им помогает.|Хорошее дело, а помощь вам нужна?|help|Эээ... я, пожалуй, пойду отсюда, что-то мне здесь разонравилось...|end";
        //        arr_speak["npc.guard"]["help"] = "Хочешь помочь? Вытаскивай меч и помогай, если нападешь на преступника в охраняемой зоне, тебе ничего не будет. [ухмыляется] Ну кроме разве что благодарности от жителей города... [опять ухмыляется] Хотя в крайнем случае мы и сами справимся...|Нет, я имел ввиду, как к вам присоединиться?|can|Да ну вас к черту, разбирайтесь сами!|end";
        //        arr_speak["npc.guard"]["end"] = "Как знаешь, удачи! [многозначительно] Надеюсь, мы и впредь будем встречаться исключительно для беседы...";

        //        arr_speak["npc.healer"] = new Dictionary<string, string>();
        //        arr_speak["npc.healer"]["begin"] = "Здравствуй, <name>! Как твои дела, как здоровье?|Спасибо, хорошо. Кто вы?|who|Вы можете меня вылечить?|heal|Я занят, до свидания|end";
        //        arr_speak["npc.healer"]["who"] = "Я лекарь, помогаю людям, попавшим в беду. Кроме того, я могу возвращать к жизни призраков.|Как это?|how|Вы можете меня вылечить?|heal|Понятно, мне пора...|end";
        //        arr_speak["npc.healer"]["heal"] = "В принципе, могу, но я занят более важными делами - помогаю тем, от кого в этом мире осталась лишь бледное подобие тени. А об обычных ранах и порезах, уверен, ты позаботишься и сам.|Поподробнее про тень, пожалуйста|how|Завидую вашей уверенности, в таком случае мне пора...|end";
        //        arr_speak["npc.healer"]["how"] = "После физической смерти, душа человека продолжает бродить по свету, но ее еще можно при некотором желании вернуть в мир живых.|И что для этого надо сделать?|res|А, я это и так знал, счастливо!|end";
        //        arr_speak["npc.healer"]["res"] = "Для этого надо просто постоять рядом со мной и я все сделаю сам. Либо найти камень воскрешения и дотронуться до него. Впрочем, опытный маг тоже может воскресить призрака.|Спасибо за объяснение, мне пора|end";
        //        arr_speak["npc.healer"]["end"] = "Удачи, береги себя!";

        //        arr_speak["npc.trader"] = new Dictionary<string, string>();
        //        arr_speak["npc.trader"]["begin"] = "Здравствуй, <name>! Желаешь что-нибудь продать или купить?|Да, я хочу купить|buyinfo|Я хочу кое-что продать|sellinfo|В другой раз, до свидания|end";
        //        arr_speak["npc.trader"]["buyinfo"] = "Хорошо, для этого в любой момент просто позови меня и я покажу тебе список своих товаров.|Я хочу посмотреть список товаров|buy|Как часто обновляется ассортимент?|upd|Интересно, а цены у всех продавцов одинаковы?|price";
        //        arr_speak["npc.trader"]["upd"] = "Это зависит от продавца, у некоторых раз в день, у других раз в неделю. Одни товары появляются чаще, другие реже. Это зависит от многих факторов, просто почаще заглядывай и не пропустишь что тебе нужно.|Ок, можно посмотреть ваши товары?|buy";
        //        arr_speak["npc.trader"]["sellinfo"] = "Отлично, покажи свои товары и я назову свою цену.|Цены у всех продавцов одинаковы?|price|Ясно, тогда перейдем к делу|sell";
        //        arr_speak["npc.trader"]["price"] = "Хм... Нет, конечно, каждый торговец может назначить свою цену, у кого-то дороже, у кого-то дешевле.|Ясно, покажите мне ваши товары|buy";
        //        arr_speak["npc.trader"]["end"] = "Всегда к вашим услугам";

        //        arr_speak["npc.bankir"] = new Dictionary<string, string>();
        //        arr_speak["npc.bankir"]["begin"] = "Здравствуй, <name>! Хочешь что-нибудь положить в банк или, наоборот, забрать?|Кто вы?|who|Я хочу положить в банк|tobank|Я хочу забрать из банка|frombank|Как мне положить предмет в банк?|tobankinfo|Как мне забрать что-нибудь из банка?|frombankinfo|Не в этот раз, до встречи!|end";
        //        arr_speak["npc.bankir"]["who"] = "Я банкир, и я могу положить твои вещи в надежное хранилище, а потом по первому требованию выдать их обратно.|А если я погибну, что будет с моими вещами?|die|И сколько это удовольствие будет мне стоить?|cost|Забрать свои вещи я могу только у вас?|place|Как мне положить предмет в банк?|tobankinfo|Как мне забрать что-нибудь из банка?|frombankinfo|На сегодня все, спасибо|end";
        //        arr_speak["npc.bankir"]["die"] = "Они по прежнему будут храниться в надежном сейфе, и как только вы их потребуете, будут вам возвращены.|Неплохо, еще пара вопросов...|who";
        //        arr_speak["npc.bankir"]["cost"] = "Абсолютно нисколько, наш сервис работает совершенно бесплатно.|Гм...у меня есть еще вопросы|who";
        //        arr_speak["npc.bankir"]["place"] = "Не обязательно, положить в банк вещи и забрать их оттуда можно у любого представителя нашей профессии, а не только у меня. Наши банки есть в любом крупном городе.|Ясно, еще пара вопросов...|who";
        //        arr_speak["npc.bankir"]["tobankinfo"] = "Для этого просто передай любой предмет мне и он будет помещен в банк в надежное хранилище.|Вот оно что...|who|Я хочу положить в банк|tobank|Я хочу забрать из банка|frombank|Это все что я хотел узнать, счастливо!|end";
        //        arr_speak["npc.bankir"]["frombankinfo"] = "Просто поговори со мной, и я покажу список твоих вещей в банке.|Я хочу забрать из банка прямо сейчас|getnow|Понятно|who|Это все что я хотел узнать, до свидания|end";
        //        arr_speak["npc.bankir"]["end"] = "Всегда к вашим услугам";

        //        arr_speak["npc.beginner"] = new Dictionary<string, string>();
        //        arr_speak["npc.beginner"]["begin"] = "Приветствую тебя, <name>! Меня зовут Уин и я помогу тебе сделать первые шаги в этом мире. Кроме того, у меня ты всегда можешь узнать последние новости или спросить о чем-нибудь, если забудешь.|Какие новости?|news|Расскажи мне обо всем|do|Расскажи мне о...|list|Как мне найти...|find|До свиданья|end";
        //        arr_speak["npc.beginner"]["news"] = "Пожалуй, пока никаких, жизнь идет свои чередом|Назад|begin|Тогда до встречи!|end";
        //        arr_speak["npc.beginner"]["find"] = "Что именно тебя интересует?|Лекарь|lek|Банк|tobank|Магазины|mag|Академия|ak|Двор рыцарей|dvr|Выходы из города|exit|Ничего, я передумал|begin";
        //        arr_speak["npc.beginner"]["lek"] = "Просто иди отсюда на север и зайди в первый встретившийся дом, не ошибешься.|А как найти...|find|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["tobank"] = "Иди отсюда на север и сразу поверни на запад, увидишь здание банка.|А как найти...|find|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["mag"] = "|А как найти...|find|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["ak"] = "Иди отсюда на север и поверни на северо-восток и попадешь прямо к парадному крыльцу Академии.|А как найти...|find|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["dvr"] = "Это немного сложнее, сейчас иди на север, потом мимо банка на центральную площадь, а уже там будет вход во двор.|А как найти...|find|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["exit"] = "Южные ворота: иди на юг и поверни на запад, Восточные ворота: иди на север, мимо Академии на восток и выйдешь к воротам. Северные ворота: около двора рыцарей сверни на север и около магазина снаряжения увидишь ворота.|А как найти...|find|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["list"] = "О чем тебе рассказать?|Что я могу делать|do|Об этом месте|place|О страже|crim|Что если я умру|die|О банке|bank|О навыках|skills|О магии|magic|О сражениях|fight|О торговле|trade|Как заработать|job|О приручении животных|tame|О контактах|contact|О макросах|macros|Ни о чем, я передумал|begin";
        //        arr_speak["npc.beginner"]["do"] = "Для начала ты должен знать, что любой диалог можно прервать и вернуться в игру, а разговор закончить позже. Обычно никто на такие вещи не обижается. Итак, в игре ты можешь делать практически все что угодно: охотиться, путешествовать, разговаривать, выполнять квесты, использовать предметы, изучать магию, применять и развивать свои навыки, и многое, многое другое...|Дальше|place|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["place"] = "Город довольно большой и в нем есть все что надо для жизни - магазины, библиотека, места для тренировок, банк, таверна и так далее. С юга город омывается рекой, там же находится порт, со всех остальных сторон город окружен лесами.|Дальше|place2|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["place2"] = "На северо-востоке есть большое кладбище, куда обычно ходят охотиться на нежить, хотя и в лесах тварей хватает. Походи по городу, почитай указатели и вывески, поговори с жителями. Ориентироваться за пределами стен очень легко - просто выйди на любую дорогу и иди по ней, куда-нибудь да придешь.|Дальше|crim|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["crim"] = "Другая важная вещь, которую ты должен знать - это преступники и городская стража. Любой человек, совершивший преступление, объявляется вне закона и на него сразу же нападает стража. К преступлениям относятся: нападение на невиновного, воровство, мародерство, натравливание своих животных на других людей.|Дальше|crim2|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["crim2"] = "Также к преступлению приравнивается любая помощь преступнику: лечение и т.д. А вот по отношению к преступникам эти правила не распространяются! То есть, на преступника можно нападать в любой момент, также можно безнаказанно забирать предметы с его трупа и т.д. Учти только, что стража есть лишь в пределах города, а за городскими стенами каждый предоставлен лишь самому себе. Впрочем, через какое-то время все забывается и даже преступники перестают быть таковыми и могут заходить в город. Так что если ты стал преступником, просто отсидись где-нибудь в лесах.|Дальше|die|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["die"] = "В случае смерти все предметы, что ты нес с собой, остаются на трупе, а сам ты становишься призраком. Ты можешь свободно ходить, но тебя почти никто не будет видеть, ты не сможешь использовать магию или предметы. А если попытаешься что-нибудь сказать, то все, за исключением имеющих навык спиритизма, услышат вместо слов лишь потустороннее завывание... Ну а чтобы не терять важные предметы, храни их в банке.|Дальше|bank|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["bank"] = "Предметы в банке храняться сколько угодно времени, забрать их оттуда можешь только ты. Чтобы положить предмет в свой банк или забрать что-нибудь из банка, просто поговори с банкиром. В банке можно хранить любые предметы и неограниченное число.|Дальше|skills|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["skills"] = "Свои параметры ты можешь посмотреть, выбрав 'Навыки' в основном меню. Главные из них - сила, ловкость и интеллект. Они учитываются почти во всех твоих действиях. Все остальные навыки тоже важны, но они учитываются только в специфических ситуациях, например, навык 'Воровство' определяет твои шансы что-нибудь утащить у соседа и так далее.|Дальше|skills2|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["skills2"] = "Все навыки изменяются в пределах 0..5, чем больше, тем лучше. Только учти, что есть предел для суммы очков всех навыков, так что стать профессионалом во всех областях сразу тебе не удастся. Теперь о том, как улучшать свои навыки. За победу над врагом ты получаешь опыт, причем чем сильнее враг (неважно, зверь или человек), тем больше за него получишь опыта.|Дальше|skills3|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["skills3"] = "Когда твой опыт достигнет определенного предела, ты получаешь новый уровень и вместе с ним одно очко опыта, которое можешь потратить на увеличение любого навыка. Для этого тебе надо найти наставника, который согласится обучить тебя выбранному ремеслу, например, рукопашному бою. Просто разговаривай со всеми и спрашивай, не могут ли они тебя чему-нибудь научить. Обычно это происходит за деньги, хотя иногда могут попросить что-то для них сделать, все зависит от наставника.|Дальше|skills4|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["skills4"] = "Многие могут научить тебя чему-нибудь, некоторые это делают дешевле или дороже, некоторые учат только до определенного уровня, а некоторые, наоборот, только если ты уже достиг необходимого уровня... Но есть один нюанс - с каждым новым уровнем получить следующий будет все труднее и труднее, поэтому желательно сразу развивать те навыки, которые тебе больше нравятся. Впрочем, даже при максимальном уровне можно развивать навыки, просто взамен поднятия одного, тебя попросят опустить какой-нибудь другой. Так что даже из эксперта мага можно со временем переквалифицироваться в воина. И наоборот.|Дальше|skills5|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["skills5"] = "Вообще, большинство боевых навыков развивают во дворе рыцарей, а магических - в Академии, так что сходи в эти места и поговори с кем-нибудь там. Хотя учителя встречаются и в других местах, даже за пределами города.|Дальше|magic|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["magic"] = "Чтобы узнать подробней о магии, сходи в Академию, там тебе все расскажут, я же лишь покажу, как ей пользоваться. Твои способности к волшебству определяются навыком 'Магия', чем он больше, тем лучше. Некоторые заклинания даются легче, некоторые труднее. Для использования особо мощных ты должен быть магом уровня не ниже тертьего или даже четвертого. Для использвания магии есть три пути: из своей книги заклинаний, в таком случае тратится мана и магические реагенты, со свитков - тогда тратится только мана и исчезает свиток или с руны, тогда тратится только мана.|Дальше|magic2|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["magic2"] = "Очевидно, что удобней всего пользоваться рунами, т.к. нет необходимости покупать дорогие реагенты, то в случае твоей гибели, руна останется лежать на трупе, ее могут похитить разбойники. Или она может просто пропасть, так как со временем трупы исчезают. Есть очень полезные заклинания 'Пометить' и 'Возвращение', позволяющие тебе телепортироватьтся в любое место! А еще есть 'Воскрешение', позволяющее оживлять погибших товарищей в бою. Сходи в Академию, там все узнаешь.|Дальше|fight|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["fight"] = "Чтобы узнать все о сражениях, сходи в двор рыцарей. Атаковать можно врукопашную или с помощью оружия (или магией). Правда в городе лучше ни на кого, кроме преступников, не нападать, иначе сам станешь преступником. При использовании практически любого вида оружия учитывается твоя сила и ловкость. Так, более сильный лучник сильнее натянет тетиву и соответственно, нанесет больший урон. Так же как и более сильный удар мечом причинит больше вреда.|Дальше|fight2|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["fight2"] = "Впрочем, в некоторых видах оружия сила не учитывается, например, при стрельбе из самстрелов. Ловкость же определяет твою меткость и скорость нанесения ударов. Кроме того, для каждого вида оружия есть свой навык, от которого зависит, насколько ты профессионально обращаешься с этим оружием. Если у тебя в руках щит, то некоторые удары ты можешь отбить им (зависит от навыка 'Парирование'). Еще один момент: броня защищает от обычного оружия, а от магии нет! Для защиты от магии есть специальные навыки.|Дальше|trade|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["trade"] = "Для того, чтобы купить или продать любой предмет, просто поговори с торговцем. У разных продавцов цены разные, кроме того, некоторые из них принимают только определенные виды товаров. И еще: ассортимент время от времени обновляется - могут появиться новые товары и т.д., все зависит от продавца.|Дальше|job|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["job"] = "Фактически, есть 5 способов заработать денег: самый простой - просто пойти за пределы города и собирать все что найдешь - грибы, магические реагенты и т.д. В первое время чтобы не погибнуть можешь просто услышав подозрительыне звуки, бежать со всех ног в сторону города. Второй способ: стать охотником, освещевывать туши убитых зверей и продавать шкуры, клыки, когти и т.д., поговори об этом с охотниками у северных ворот. Третий - идти на кладбище или искать монстров в лесах, у монстров попадаются монеты прямо на трупах.|Дальше|job2|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["job2"] = "Четвертый, не совсем честный, я бы даже сказал совсем нечестный способ  -воровать деньги и предметы у других игроков. Можно еще стать разбойником и нападать на прохожих за пределами городских стен. Путь в город, как ты понимаешь, в таком случае тебе будет закрыт, пока люди не забудут, что ты был бандитом. Можно еще самому делать предметы на продажу, но с этим пока не все ясно...|Дальше|tame|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["tame"] = "Чтобы узнать о приручении животных, найди кого-нибудь, кто этим занимается и расспроси его. Я бы посоветовал поговорить с охотниками у северных ворот, они должны знать. Сейчас лишь скажу, что некоторых животных можно приручить. В случае успеха, они будут ходить за тобой по пятам и защищать тебя. Еще они будут выполнять твои команды, можешь их натравить на кого-нибудь или сказать охранять того-то... Прирученные могут со временем уйти от вас, поэтмоу обращайтесь с ними ласково и тогда они привяжутся к вам надолго.|Дальше|contact|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["contact"] = "В контактах (команда в главном меню) ты можешь оправлять и получать письма от друзей, где бы они не находились. При этом еще показывается, кто из твоих друзей играет в данный момент вместе с тобой. А даже если и нет, можешь им отправить письмо и они получат его, как только войдут в игру. Если тебе что-нибудь говорит слово ICQ, то ты уже понимаешь, о чем речь :-). Да, кстати, если придет новое сообщение, об этом будет написано в главном экране игры, так что не надо постоянно проверять контакты.|Дальше|macros|А что насчет...|list|Ясно, пока|end";
        //        arr_speak["npc.beginner"]["macros"] = "Еще ты можешь создавать свои макросы, например: повторить последнее действие, атаковать последнюю цель, использовать заклинание 'Лечение' на себя и т.д. Все макросы доступны из главного меню (в большинстве телефонов для этого достаточно нажать горячую кнопку). Поздравляю, на этом твое начальное обучение закончено, ты готов вступить в этот чудесный, волшебный мир. Об остальном узнаешь в своих приключениях, удачи тебе!|У, а я только приготовился слушать...|begin|А что насчет...|list|Спасибо, еще увидимся!|end";
        //        arr_speak["npc.beginner"]["end"] = "Хорошо, я всегда буду здесь, если что-то понадобится, приходи в любое время.";

        //        arr_speak["npc.Gant"] = new Dictionary<string, string>();
        //        arr_speak["npc.Gant"]["begin"] = "Здравствуй, незнакомец. Это двор рыцарей, могу я чем-нибудь тебе помочь?|Что за двор рыцарей?|what|Я хочу пройти|go";
        //        arr_speak["npc.Gant"]["what"] = "Здесь живут палладины его Величества во главе с Лордом Хагеном, он находится в здании прямо через двор.|И чем вы тут занимаетесь?|do|Я хочу пройти|go";
        //        arr_speak["npc.Gant"]["do"] = "Мы здесь по приказу короля, прибыли с миссией защиты города от возможного вторжения орков. А пока что, на временной дислокации, тренируем новобранцев и обеспечиваем порядок в городе.|Первый раз слышу о каком-то вторжении|vtorj|Я хочу пройти|go";
        //        arr_speak["npc.Gant"]["vtorj"] = "Поговори об этом лучше с Лордом Хагеном или его помощником, Рено, они тебе все объяснят. Или с главой города Сильвестро, он в доме в северной части двора|Ок, счастливо|go";
        //        arr_speak["npc.Gant"]["go"] = "Постой, это конечно, не мое дело, но все-таки, ты случайно не из Академии?|Да, я из Академии, а что?|ak|Нет|no";
        //        arr_speak["npc.Gant"]["ak"] = "Я так и подумал. Знаешь, ты не очень похож на этих умников в рясах, я бы даже сказал, ты выглядишь вполне благоразумным человеком. Поэтому хочу дать тебе совет - держись подальше от всей этой братии.|Что-то не так с Академией?|ak2|Я сам знаю что мне делать и как|end";
        //        arr_speak["npc.Gant"]["ak2"] = "Никогда не стоит доверять магам. Это самонадеянные, заносчивые, считающие себя выше других. Эти магики себе на уме, лучше с ними не связываться. Хороший клинок, да добрый щит - вот что нужно настоящему мужчине, а не декларировать фразы нараспев, размахивая руками. Ты меня понимаешь?|Понимаю, полностью с тобой согласен!|ak3|Хорошо, учту твое мнение|end";
        //        arr_speak["npc.Gant"]["ak3"] = "Вот и славно! Приятно осознавать, что не дал человеку встать на зыбкий путь. Держить рыцарей и будешь всегда уверен - спина у тебя надежно прикрыта.|Счастливо, удачи|end";
        //        arr_speak["npc.Gant"]["no"] = "И правильно, нечего соваться к этим книгочеям. Так же как и водиться с охотниками. Скажу тебе по секрету, большинство из них бывшие каторжники или наемники. Если ты предпочитаешь честную сталь, двор рыцарей к твоим услугам!|Да здравствует двор рыцарей!|ura|Ладно-ладно, я понял|end";
        //        arr_speak["npc.Gant"]["ura"] = "Ну-ну, не так пылко :-). Я вижу, в нашем полку прибыло и у нас скоро будет новый ноборанец? Поговори с Лордом Хагеном, в потом к Катаресу, он сделает из тебя настоящего мужчину!|Так и сделаем, спсибо за совет|end|Я и так настоящий мужчина|man";
        //        arr_speak["npc.Gant"]["man"] = "Ха! Вот нападут орки, тогда и посмотрим, кто чего стоит. Не обижайся, я ведь тебя не не знаю, может ты мастер меча, просто виду тебя не ахти, ну да ничего, это дело поправимое, верно?|Верно, я пойду|end";
        //        arr_speak["npc.Gant"]["end"] = "Ну бывай, еще свидимся";

        //        arr_speak["npc.LordHagen"] = new Dictionary<string, string>();
        //        arr_speak["npc.LordHagen"]["begin"] = "Как твое имя, незнакомец?|Меня зовут <name>|name|Мое имя Ричард|wr|Гм... Мое имя тебе ничего не скажет, давай лучше сразу перейдем к делу.|vopr";
        //        arr_speak["npc.LordHagen"]["name"] = "Ну что ж, честность красит человека, я думаю мы поладим.|Я тоже так думаю|vopr";
        //        arr_speak["npc.LordHagen"]["wr"] = "Ты в этом уверен? Учти, что лжецам или жуликам не место во дворе рыцарей! Впрочем, ладно, время покажет кто ты такой.|Конечно, уверен, так же как и в том, что у меня на одной руке шесть пальцев!|pal|Я учту это...|vopr";
        //        arr_speak["npc.LordHagen"]["pal"] = "[издевательски] Твое остроумие меня просто поразило до глубины души. Давай не будем тратить время попусту, зачем ты пришел?|Хорошо, для начала - кто вы?|vopr";
        //        arr_speak["npc.LordHagen"]["vopr"] = "Я Лорд Хаген, в данное время я являюсь командиром отряда палладинов в этом городе.|Зачем вы приехали в город?|why|Я хочу стать рыцарем|rene|А магии у вас научиться можно?|mag|Мне пора|end";
        //        arr_speak["npc.LordHagen"]["why"] = "На город может быть совершено массированное нападение орков, чьи полчища собираются на севере и западе. Это достаточная причина? Больше ничего по этому поводу тебе сказать не могу.|Гм...|vopr";
        //        arr_speak["npc.LordHagen"]["rene"] = "Всеми делами, связанными с обучением и новобранцами, заведует мой помощник Рене, вот он стоит рядом, поговори с ним.|Ладно|end|У меня есть еще вопросы|vopr";
        //        arr_speak["npc.LordHagen"]["mag"] = "Да, можно. Наша магия очень сильна, так как мы на службе добра и справедливости, поэтому высшие силы помогают нам. Стоунс в северном здании расскажет тебе подробности. Я же могу научить тебя заклинанию 'Гнев богов'.|Я хочу выучить это заклинание|gnev|И сколько это будет стоить?|cost|В другой раз|vopr";
        //        arr_speak["npc.LordHagen"]["cost"] = "[широко улыбается] Нисколько, это заклинание относится к тем, которые можно доверять любому.|В смысле?|gnev2|Звучит подозрительно, я передумал|vopr";
        //        arr_speak["npc.LordHagen"]["gnev2"] = "Видишь ли, это очень мощное боевое заклинание, но оно действует только на преступников. Так ты хочешь его выучить?|Да, я согласен|gnev|Хм... это не по мне|vopr";
        //        arr_speak["npc.LordHagen"]["gnev"] = "magic|magic.all.godanger|0|4";
        //        arr_speak["npc.LordHagen"]["end"] = "Хорошо, береги себя";

        //        arr_speak["npc.Rene"] = new Dictionary<string, string>();
        //        arr_speak["npc.Rene"]["begin"] = "Я Рене, помощник Лорда Хагена. Что ты хочешь узнать?|Где я могу потренироваться?|tren|Я хочу изучить магию|mag|Где мне найти главу города?|gl|Ничего, мне пора|end";
        //        arr_speak["npc.Rene"]["tren"] = "Иди к ристалищу, там Кантарес тренирует новобранцев. И там же есть где пострелять из лука, если тебя это интересует, спроси про Ханса.|У меня есть другие вопросы|begin|Хорошо, пока|end";
        //        arr_speak["npc.Rene"]["mag"] = "Поговори со Стоунсом в северном здании, у него же ты можешь купить магические товары.|У меня есть другие вопросы|begin|Хорошо, пока|end";
        //        arr_speak["npc.Rene"]["gl"] = "Сильвестра? Он тоже в северном здании вместе со Стоунсом.|У меня есть другие вопросы|begin|Хорошо, пока|end";
        //        arr_speak["npc.Rene"]["end"] = "Пока";

        //        arr_speak["npc.Silvestr"] = new Dictionary<string, string>();
        //        arr_speak["npc.Silvestr"]["begin"] = "Что тебе надо, я занят|Вы глава этого города?|gl|Да собственно, ничего|end";
        //        arr_speak["npc.Silvestr"]["gl"] = "Я, но что толку? С тех пор как появились палладины, я тут вообще ничего не решаю, всем заведует Лорд Хаген!|Зачем палладины в городе?|why";
        //        arr_speak["npc.Silvestr"]["why"] = "А я знаю? Приказ короля и все тут. Для защиты от орков, так было сказано. Только вот я и на своих солдат не жаловался, а теперь где они? В южной части города, в каких-то трущобах! Лучше оставь меня в покое, и так не до тебя :-(|Ладно, не буду мешать|end";
        //        arr_speak["npc.Silvestr"]["end"] = "[отвернулся и занялся своими делами]";

        //        arr_speak["npc.Stouns"] = new Dictionary<string, string>();
        //        arr_speak["npc.Stouns"]["begin"] = "Привет, <name>, как дела?|Нормально, ты можешь научить меня магии?|mag|Я хотел бы кое-что купить|buy|Я хочу продать...|sell|Ты покупаешь товары?|sellinfo|А кто еще учит магии?|more|Могло бы быть и лучше, мне пора|end";
        //        arr_speak["npc.Stouns"]["more"] = "У меня только палладинские заклинания, как ты мог уже заметить. Все остальное практикуют в Академии. Ну и еще Лорд Хаген может научить тебя очень мощному заклинаию 'Гнев Богов', но он учит далеко не всех, впрочем, поговори с ним сам.|Ясно|begin";
        //        arr_speak["npc.Stouns"]["sellinfo"] = "Нет, у нас во дворе рыцарей и так все есть, я только продаю магические принадлежности, ну и обучаю некоторым заклинаниям.|Ясно|begin";
        //        arr_speak["npc.Stouns"]["mag"] = "Я могу научить тебя заклинаниям 'Лечение' и 'Святая стрела', что ты хочешь узнать?|Лечение|heal|Святая стрела|arrow|Я лучше пойду|end";
        //        arr_speak["npc.Stouns"]["heal"] = "Это очень полезное заклинание, оно восстанавливает твою жизнь, если ты ранен. Обучение обойдется в 300 монет.|Согласен, вот деньги|healnow|Ого! Да за такую сумму я скорей съем свой язык!|mag|Я лучше пойду|end";
        //        arr_speak["npc.Stouns"]["arrow"] = "Заклинание 'Святая стрела' действует только на злых существ, но зато наносит довольно сильный урон, а маны требует совсем немного. Обучение стоит 200 монет.|Согласен, вот деньги|arrownow|Хм... для меня дороговато пока...|mag|Я лучше пойду|end";
        //        arr_speak["npc.Stouns"]["healnow"] = "magic|magic.heal|300";
        //        arr_speak["npc.Stouns"]["arrownow"] = "magic|magic.war.holyarrow|200";
        //        arr_speak["npc.Stouns"]["end"] = "Счастливо, да хранят тебя боги!";

        //        arr_speak["npc.KantaresNovobranec"] = new Dictionary<string, string>();
        //        arr_speak["npc.KantaresNovobranec"]["begin"] = "[вытирает пот со лба] Уфф, этот Кантарес сущий дьявол, но как учитель по холодному оружию, ему нет равных!";

        //        arr_speak["npc.Kantares"] = new Dictionary<string, string>();
        //        arr_speak["npc.Kantares"]["begin"] = "Здравствуй, <name>, решил немного размяться?|Говорят, ты тренируешь бойцов?|tren|На самом деле я просто шел мимо|end";
        //        arr_speak["npc.Kantares"]["tren"] = "Верно говорят, я инструктор по холодному оружию.|Как мне стать сильнее?|str|Я хочу научиться драться!|draka|Поздравляю! Это все что я хотел сказать|end";
        //        arr_speak["npc.Kantares"]["str"] = "Нет проблем, это идеальное место для тренировки. Не бесплатно, конечно, тебе это обойдется в 150 монет.|Ок, я хочу увеличить свою силу.|strnow|Я передумал|tren";
        //        arr_speak["npc.Kantares"]["strnow"] = "skill|str|150";
        //        arr_speak["npc.Kantares"]["draka"] = "Я могу научить тебя обращаться с мечом, уклоняться от ударов и правильно использовать щит.|Научи меня обращению с холодным оружием|cold|Научи меня уклоняться|uklon|Научи меня обращению со щитом|parr|А драться врукопашную?|hand|Что насчет стрельбы из лука?|luk|Я передумал|tren";
        //        arr_speak["npc.Kantares"]["cold"] = "Меч - это главное оружие рыцаря. Быстрый и смертоносный клинок, вот чем палладин отстаивает свою честь или честь невиновных! Здесь надо помнить всего две вещи: первое: чем ты сильнее, тем страшнее твой удар, и второе: надо уметь собственно правильно держать меч в руках и знать приемы. Кроме того, помни, что если ты слаб, а оружие тяжелое, то тебе будет сложней с ним обращаться. Всего за 200 монет я покажу тебе как владеть мечом.|Я согласен|coldnow|Лучше научи как увеличить силу|str|А как насчет стрельбы из лука?|luk|Гм.. а как насчет других навыков|tren";
        //        arr_speak["npc.Kantares"]["coldnow"] = "skill|coldweapon|200";
        //        arr_speak["npc.Kantares"]["hand"] = "Ха! Не дело это рыцаря кулаками махать. если хочешь, иди к этим недотепам - солдатам, они любят устраивать кулачные забавы. Простолюдины, что с них взять.|Где мне найти солдат?|hand2";
        //        arr_speak["npc.Kantares"]["hand2"] = "Иди к южным воротам, в около них поверни на запад и выйдешь к казармам. Впрочем, можешь обойти наш двор с задней стороны, так даже ближе.|Понятно|tren";
        //        arr_speak["npc.Kantares"]["luk"] = "Видишь вон в том углу ристалища Ханса? Он владеет стрелковым оружием.|Ясно|tren";
        //        arr_speak["npc.Kantares"]["uklon"] = "Если тебе удалось увернуться от удара, то считай что тебе повезло. За 200 монет я могу сделать так, чтобы тебе 'везло' почаще. Хотя от магии просто так не увернешься, но в обычном бою это очень полезное умение.|Я согласен|uklonnow|Гм.. а как насчет других навыков|tren";
        //        arr_speak["npc.Kantares"]["uklonnow"] = "skill|uklon|200";
        //        arr_speak["npc.Kantares"]["parr"] = "Настоящий воин должен уметь обращаться со щитом. Если ты умеешь им владеть, то урон уменьшается на броню щита, так что чем крепче щит, тем лучше. Но даже самый лучший щит в твоих руках, елси ты не умеешь им правильно закрываться, окажется бесполезным грузом, стесняющим движения. Если хочешь, я научу тебя владешь щитом за 200 монет.|Я согласен|parrnow|Гм.. а как насчет других навыков|tren";
        //        arr_speak["npc.Kantares"]["parrnow"] = "skill|parring|200";
        //        arr_speak["npc.Kantares"]["end"] = "Бывай";

        //        arr_speak["npc.Hans"] = new Dictionary<string, string>();
        //        arr_speak["npc.Hans"]["begin"] = "Я Ханс, тренер по стрелковому оружию.|Чему ты можешь меня научить?|tren|Что-то у тебя не видно учеников...|uch|Где мне купить стрел?|buyinfo|Мне пора|end";
        //        arr_speak["npc.Hans"]["buyinfo"] = "Сходи в торговый квартал на юге города. Или поспрашивай у охотников, они обычно крутятся около северных ворот.|Ясно|begin";
        //        arr_speak["npc.Hans"]["uch"] = "Это верно, среди рыцарей стрелковое опужие не очень-то в почете. Это, по их мнению, противоречит понятиям чести. Да и где это видано, чтобы палладин, к примеру, кидался камнями?|Тогда почему ты здесь?|uch2|Ладно, забудем об этом|begin";
        //        arr_speak["npc.Hans"]["uch2"] = "А кто сказал, что лук со стрелами бесполезен? Во многих случаях он даже эффективней. Здесь мне хорошо платят, я могу учить людей, а какая разница где это делать? Сюда часто приходят местные охотники, им умение стрелять нужно как воздух.|Научи тогда и меня!|tren|Верно говоришь|begin|Пожалуй, я предпочитаю сталь клинка, извини|end";
        //        arr_speak["npc.Hans"]["tren"] = "Я могу научить тебя стрелять, быть проворней, а также быть осторожней.|Я хочу повысить ловкость|dex|Я хочу научиться стрелять|luk|Осторожней?|look|А как насчет мечей?|sword|Мне пора|end";
        //        arr_speak["npc.Hans"]["sword"] = "Для этого сходи к Кантаресу. Иди на звон мечей, не ошибешься.|Понятно|tren";
        //        arr_speak["npc.Hans"]["dex"] = "Ловкость определяет твою меткость и скорость стрельбы. Для лучника это очень важный параметр. Я могу помочь тебе развить ловкость за 150 монет.|Я согласен|dexnow|Я передумал|tren";
        //        arr_speak["npc.Hans"]["dexnow"] = "skill|dex|150";
        //        arr_speak["npc.Hans"]["luk"] = "Ну что ж, во-впервых, для стрельбы из лука или метания нужна сила, т.к. от нее зависит наносимый урон. Кроме арбалетов, конечно. Во-вторых, нужна хорошая ловкость, чтобы попадать в цель. Учти, что попасть из лука намного сложней, чем мечом или кулаком! И в-третьих, надо уметь обращаться со стрелковым оружием. За 200 монет я могу научить тебя стрелять лучше.|Научи, вот деньги|luknow|Лучше научи как увеличить ловкость|dex|Гм.. а как насчет других навыков|tren";
        //        arr_speak["npc.Hans"]["luknow"] = "skill|ranged|200";
        //        arr_speak["npc.Hans"]["end"] = "Удачи, пусть твоя рука не дрогнет в нужный момент";

        //        arr_speak["npc.Ded"] = new Dictionary<string, string>();
        //        arr_speak["npc.Ded"]["begin"] = "И тебе привет, юноша.|Что ты здесь делаешь?|do|Пока|end";
        //        arr_speak["npc.Ded"]["do"] = "Ловлю рыбку на ужин. Надеюсь, этим твое любопытство исчерпало себя?|Неа, а кто тот мальчуган на другой стороне пристани?|mal|Дед, ты видел здесь когда-нибудь корабль?|kor|Твоя правда, старик, исчепало|end";
        //        arr_speak["npc.Ded"]["mal"] = "А, этот босоногий стервец? Да внучок, ишь ты, тоже рыбу ловит. Пугает больше...|Однако он наловил больше тебя!|bol|Ясно, славный малыш|begin";
        //        arr_speak["npc.Ded"]["kor"] = "[ворчит] Видел, видел, а то как же, приплыл тут весной по половодью, высадил десятка три дармоедов, да и убрался восвояси.|А зачем они приплыли?|kor2|Недосуг мне сейчас баловаться разговорами, будь здоров|end";
        //        arr_speak["npc.Ded"]["kor2"] = "А хто ж их знает? Говорят для защиты города, орки вроде что-то затевают, вон по лесам сколько их щастает...|А стража на что?|kor3|Ладно неважно|end";
        //        arr_speak["npc.Ded"]["kor3"] = "Стража только в городе, а рыцари и в лес могут отряд послать, да и организованы не в пример лучше. Вот только и волки-то в город не захаживают, не то чтобы орки, так и просиживают тут эти рыцари свои высокородные штаны. Заняли к тому же лучший двор, а солдаты прозябаяют в како-то дыре...|Как мне найти солдат?|kor5|А мальчуган ваш о рыцарях лучше отзывается|kor6|Говоришь, в лесу есть волки?|kor7|Все ясно, бывай, дед|end";
        //        arr_speak["npc.Ded"]["kor6"] = "Да что он может знать, еще лапти первые не сносил, паршивец!|Гм.. а может дело в том, что у рыба лучше ловится? ;-)|bol|Вернемся к рыцарям|kor3|Ладно, пойду я...|end";
        //        arr_speak["npc.Ded"]["kor5"] = "Зайди в южные ворота и поверни на запад, там недалеко.|Вернемся к рыцарям|kor3|Спасибо, пока|end";
        //        arr_speak["npc.Ded"]["kor7"] = "И не только волки, тут на востоке в болотах говорят, даже громадный огр шастает...|Спасибо за науку, будь здоров дед|end";
        //        arr_speak["npc.Ded"]["bol"] = "И ты туда же! Ух, молодешь, ремней на вас не напасешься! Хотя чего на вас, неразумных сердиться? Все равно оболдуи-оболдуями так и останетесь...|Не серчай дед, я ж не со зла|begin|Сам ты старый пердун, вот что!|end";
        //        arr_speak["npc.Ded"]["end"] = "Иди-иди, всю рыбу распугал!";

        //        arr_speak["npc.Malchugan"] = new Dictionary<string, string>();
        //        arr_speak["npc.Malchugan"]["begin"] = "О! Ты видел палладинов? Правда, здорово? А какая блестящая броня, в такой ни один волк не страшен! Я когда вырасту тоже стану рыцарем!";

        //        arr_speak["npc.Mahmet"] = new Dictionary<string, string>();
        //        arr_speak["npc.Mahmet"]["begin"] = "Здавствуй, <name>. Я Махмет, торговец драгоценностями. Покупаю кольца, бусы, ожерелья и драгоценные камни. У меня лучшие цены в городе!|Я хочу продать кое-что|sell|Покажи мне твои товары|buy|Где же мне достать драгоценности?|get|Пока|end";
        //        arr_speak["npc.Mahmet"]["get"] = "Лучше всего искать их около гор, в рудниках и шахтах. Хотя иногда драгоценные камни попадаются у монстров. Особенного гоблины любят таскать всякие безделушки.";
        //        arr_speak["npc.Mahmet"]["end"] = "Я всегда здесь";

        //        arr_speak["npc.Julien"] = new Dictionary<string, string>();
        //        arr_speak["npc.Julien"]["begin"] = "Рад тебя видеть, <name>. У меня ты можешь купить или продать магические реагенты, а также руны перемещения. Правда покупаю я исключительно реагенты|Я хочу продать кое-что|sell|Покажи мне твои товары|buy|Где я могу найти реагенты?|get|В Академии тоже продают реагенты!|ak|Пока|end";
        //        arr_speak["npc.Julien"]["get"] = "Гм... Ну, большинство из них ты можешь найти в лесу, некоторые у гор или в болотах. Можешь попробовать также пройтись вдоль реки, там иногда попадается жемчуг - очень редкий и дорогой реагент.";
        //        arr_speak["npc.Julien"]["ak"] = "[задумчиво] Академия.. Да.., раньше только в Академии и продавали, а кто еще пробовал, того сразу... ну неважно, сейчас стало гораздо лучше. Если ты этого еще не сделал, сравни цены и все поймешь.";
        //        arr_speak["npc.Julien"]["end"] = "Всегда рад тебя видеть";

        //        arr_speak["npc.Goston"] = new Dictionary<string, string>();
        //        arr_speak["npc.Goston"]["begin"] = "Добро пожаловать! Для тебя, <name>, у меня всегда что-нибудь найдется.|Чем ты торгуешь?|sellштащ|Покажи мне твои товары|buy|Я хочу кое-что продать|sell|Мне пора|end";
        //        arr_speak["npc.Goston"]["sellinfo"] = "Всем помаленьку, что может пригодиться путешественнику или охотнику. Да и покупаю я все, что ни принесешь, только бы оно хоть что-то стоило... Если покажешь мне предмет, я назову свою цену|Ясно, покажи мне твои товары|buy|Я хочу продать|sell";
        //        arr_speak["npc.Goston"]["end"] = "Приходи еще";

        //        arr_speak["npc.Raksha"] = new Dictionary<string, string>();
        //        arr_speak["npc.Raksha"]["begin"] = "Кого я вижу, сам <name> пожаловал! Решил просто так навестить старую Ракшу или хочешь что-то купить?|Чем ты торгуешь?|sellinfo|Хочу купить|buy|Хочу подать|sell|Нет, ничего, в другой раз|end";
        //        arr_speak["npc.Raksha"]["sellinfo"] = "Ты не знаешь, чем торгует Ракша? [сокрушенно] Куда катится мир... Торгую я, сынок, снадобьями целебными, да повышающими ману.|Неплохо, покажи какие именно|buy|Ты можешь научить меня делать напитки?|teach";
        //        arr_speak["npc.Raksha"]["teach"] = "Ух, шустер, ничего не скажешь! Ты думаешь, я вот так раз, взяла, да и рассказа тебе секреты целебных трав, передающиеся поколениями от бабки к внучке? Мал ты еще видать, коль столь наивен...|Хм...|begin";
        //        arr_speak["npc.Raksha"]["end"] = "Береги себя, сынок";

        //        arr_speak["npc.Arant"] = new Dictionary<string, string>();
        //        arr_speak["npc.Arant"]["begin"] = "Здравствуй, <name>. Я торгую стрелковым оружием и припасами к нему.|Покажи свои товары|buy|У меня есть товары на продажу|sell|А ты покупаешь оружие?|sellinfo|Расскажи мне о стрельбе|tell|Нет, ничего, в другой раз|end";
        //        arr_speak["npc.Arant"]["sellinfo"] = "Да, конечно|Покажи свои товары|buy";
        //        arr_speak["npc.Arant"]["tell"] = "Ну, стрелковое оружие разным бывает. Это луки, арбалеты, сюда же относится все что можно кинуть во врага: ножи, копья и многое другое, даже камни. Общее у них одно - им можно достать врага, который довольно далеко от тебя, в отличие от холодного оружия, которое действует только вблизи.|Расскажи об арбалетах|arb|Расскажи о луках|luk|Есть что-нибудь особенное?|bum|ты можешь меня чему-нибудь научить?|teach|Я должен идти|end";
        //        arr_speak["npc.Arant"]["arb"] = "Арбалеты - очень хорошее оружие, хоть и дорогое. Главное достоинство арбалетов - то что они самострелы, т.е. бьют без помощи физической силы человека. Даже, извини, хлюпик и тот всадит болт так, что всадник в броне испустит дух раньше чем коснется земли. Помни только о том, что для арбалетов нужны не стрелы, а болты.|Ясно|tell";
        //        arr_speak["npc.Arant"]["luk"] = "Лук - основное оружие охотника, потому что позволяет подстрелить убегающую добычу. Луки проще в изготовлении, чем арбалеты, луков бывает больше разновидностей. А по мощности они почти догоняют арбалеты. Хотя это дело вкуса. В общем случае, сильный человек даже из плохого лука будет стрелять улчше, чем слабый из хорошего.|Ясно|tell";
        //        arr_speak["npc.Arant"]["bum"] = "Хм... пожалуй, есть. Посмотри на бумеранг. Он относится к стрелковому оружию, но не тратит боеприпасов, так как возвращается к владельцу. Еще обрати внимание на пращу, ей можно метать камни сильней, чем просто бросать их руками.|Ясно, спасибо|tell";
        //        arr_speak["npc.Arant"]["teach"] = "Я могу научить тебя стрелять из лука за 150 монет, а также развить ловкость за 100 монет.|Научи меня стрелять из лука|luknow|Научи меня ловкости|dexnow|Я передумал|tell";
        //        arr_speak["npc.Arant"]["luknow"] = "skill|ranged|150|0|3";
        //        arr_speak["npc.Arant"]["dexnow"] = "skill|dex|100|0|3";
        //        arr_speak["npc.Arant"]["end"] = "Приходи еще";

        //        arr_speak["npc.Milta"] = new Dictionary<string, string>();
        //        arr_speak["npc.Milta"]["begin"] = "Здесь продаются домашние животные. Ты можешь купить себе, например, собаку. Правда сейчас в продаже ничего нет, так что приходи как-нибудь в другой раз...";

        //        arr_speak["npc.Frederik"] = new Dictionary<string, string>();
        //        arr_speak["npc.Frederik"]["begin"] = "Здравствуй. Тебя зовут <name>, верно?|Верно, кто ты?|who|Я должен идти|end";
        //        arr_speak["npc.Frederik"]["who"] = "Меня зовут Фредерик и я владецец этой таверны. Здесь ты можешь что-нибудь перекусить или отдохнуть наверху в одной из комнат.|Покажи свои товары|buy|Ты что-нибудь покупаешь?|sellinfo|Я должен идти|end";
        //        arr_speak["npc.Frederik"]["sellinfo"] = "Нет, это ведь не магазин, а таверна. Люди приходят сюда выпить и перекусить, а не торговаться.|Ясно|who";
        //        arr_speak["npc.Frederik"]["end"] = "Пока";

        //        arr_speak["npc.Surri"] = new Dictionary<string, string>();
        //        arr_speak["npc.Surri"]["begin"] = "Что тебе здесь надо?|Меня зовут <name>, а ты кто?|who|Гм., вернусь когда станешь повежливей|end";
        //        arr_speak["npc.Surri"]["who"] = "Я Сурри. Так все-таки, зачем явился, это место не из самых посещаемых.|Почему это место не охраяется стражей?|who2|Я должен идти|end";
        //        arr_speak["npc.Surri"]["who2"] = "Ну да, не охраняется, да тут и охранять нечего, посмотри вокруг.|Так чего же ты здесь живешь?|who3|Я должен идти|end";
        //        arr_speak["npc.Surri"]["who3"] = "Гм.., значит на то есть причины. Возможно, меня жители не очень-то любят, тебе какое дело?|Да никакого, разве ты можешь кого обидеть?|who4|Похоже, список тех кто тебя недолюбливает, пополнился на одного.|end";
        //        arr_speak["npc.Surri"]["who4"] = "[странно улыбается и что-то бормочет себе под нос] Необязательно причинять боль, чтобы не понравится людям...|А что например?|who5|Мне надоели твои намеки|end";
        //        arr_speak["npc.Surri"]["who5"] = "Ну, например, ты можешь у них что-нибудь украсть...|Ты вор???|who6|Хех, что-то я захотел на улицу|end";
        //        arr_speak["npc.Surri"]["who6"] = "Сейчас я уже нчием таким не занимаюсь, а вот молодость провел очень даже бурно, если ты понимаешь, о чем я...|Тогда почему не возвращаешься в город?|who7|И знать не хочу, о чем ты!|end";
        //        arr_speak["npc.Surri"]["who7"] = "Хе-хе, а мы и так в городе, если ты этого не заметил.|Я не о том|who8|Мне пора|end";
        //        arr_speak["npc.Surri"]["who8"] = "Ну, дело не во мне, а в моем сыне. Он, как бы это сказать, пошел по стопам отца. Я его, понятное дело, не одобряю, но ведь один он у меня, куда уж я без него, вот так и жевем вместе, у черта на куличках...[неожиданно улыбнулся] А ведь знаешь, более шцстрого малого, чем мой сын, и во всем городе не сыскать!|Он может меня чему-нибудь научить?|who9|Мне пора|end";
        //        arr_speak["npc.Surri"]["who9"] = "Что ты у меня спрашиваешь, поговори с ним, он в соседней комнате. Воры хоть и работают порой на заказ, но никому не служат, [презрительно скривился] в отличие от палладинов.|А что с палладинами?|who10|Мне пора|end";
        //        arr_speak["npc.Surri"]["who10"] = "Да ничего, старые счеты. Терпеть не могу этих ныпыщенных ублюдков, рассуждающих о чести, а даже ради спасения близких людей не могущие ударить врага в спину. Чертова благородность. [грубо] И хватит с тебя рассказов, лучше не суй нос в чужую жизнь, некоторым это может не понравиться.|Но ты же сам начал...|who11|Мне пора|end";
        //        arr_speak["npc.Surri"]["who11"] = "Как начал, так и кончил, проваливай.|Как знаешь, твои проблемы|end";
        //        arr_speak["npc.Surri"]["end"] = "[что-то ворчит себе под нос]";

        //        arr_speak["npc.Sirs"] = new Dictionary<string, string>();
        //        arr_speak["npc.Sirs"]["begin"] = "Привет, каким судьбами?|Я говорил с твоим отцом, он утверждает что ты ловкий парень|tren|Такими же, какими я сейчас уйду|end";
        //        arr_speak["npc.Sirs"]["tren"] = "Я так и знал, ну и чему ты хочешь научиться?|Ловкости|dex|Осторожности|look|Подглядыванию|steallook|Воровству|steal|Скрытности|hide|Что-то ты не похож на учителя|story|Нет, ничего|end";
        //        arr_speak["npc.Sirs"]["story"] = "Это смотря чему учить. Да если хочешь, знать, я тут у одного богача свистнул дорогущее ожерелье, да так ловко провернул дельце, что все подумали на его сына, тому как раз нужны были деньги. Что теперь думаешь?|Ты по прежнему не похож на учителя, ты теперь похож не придурка!|fak|Ладно, давай о чем нибудь другом|tren|С ворами у меня пути расходятся|end";
        //        arr_speak["npc.Sirs"]["fak"] = "Сам ты придурок! Не забыл еще, что сюда стража носа не сует, будешь много о себе ставить, мигом твой же нос пообломаю!";
        //        arr_speak["npc.Sirs"]["dex"] = "Ловкость - главная характеристика для вора, от нее зависит, сумеешь ли вообще заглянуть в чужой карман, не говоря уж о том, чтобы что-то спереть! Это будет стоить 100 монет|Согласен|dexnow|Я передумал|tren";
        //        arr_speak["npc.Sirs"]["dexnow"] = "skill|dex|100|2";
        //        arr_speak["npc.Sirs"]["look"] = "Просто не забывай смотреть по сторонам. Нет ничего глупей, чем позволить себя обокрасть среди бела дня... За 200 монет я могу научить тебя, как не позволять всяким... гм... любителям шарить по твоим карманам.|Отличная идея!|looknow|Нет, извини, денег жалко...|tren";
        //        arr_speak["npc.Sirs"]["looknow"] = "skill|look|200";
        //        arr_speak["npc.Sirs"]["steallook"] = "Согласись, прежде чем воровать, неплохо бы знать, что у богатея в сумке, верно? Тем более заглянуть туда намного проще, чем собственно что-то оттуда утянуть. Я могу рассказать о некоторых хитростях за 100 монет|Согласен|steallooknow|Я передумал|tren";
        //        arr_speak["npc.Sirs"]["steallooknow"] = "skill|steallook|100";
        //        arr_speak["npc.Sirs"]["steal"] = "Главное - не быть замеченным. Если все провернуть чисто, то даже стража ничего не заподозрит. Но это трудное и опасное ремесло, к тому же если твой 'объект' осторожен, то обворовать его становится еще сложней! Это будет стоить 200 монет|Давай, учи, вместо того чтобы болтать|stealnow|Я передумал|tren";
        //        arr_speak["npc.Sirs"]["stealnow"] = "skill|steal|200";
        //        arr_speak["npc.Sirs"]["hide"] = "Навык незаметности может пригодиться при удирании от погони. Если грамотно скрываться, то любая стража потеряет тебя из виду уже через несколько шагов. Когда цена - твоя жизнь, что говорить о жалких 200 монетах, согласен?|Угу|hidenow|Нет, не согласен, 200 монет дороже|tren";
        //        arr_speak["npc.Sirs"]["hidenow"] = "skill|hiding|200";
        //        arr_speak["npc.Sirs"]["end"] = "[с усмешкой] Не пропадай";

        //        arr_speak["npc.Markus"] = new Dictionary<string, string>();
        //        arr_speak["npc.Markus"]["begin"] = "Как дела, старина <name>? Я Маркус, тренирую здешних ребят, что сейчас дрыхнут в казарме. Не желаешь размяться?|С удовольствием, старина Маркус!|tren|Вы ошиблись, я просто шел мимо|end";
        //        arr_speak["npc.Markus"]["tren"] = "Вот это дело! Закатывай рукава. Я, конечно, не такой мастер, как Кантарес из двора рыцарей, но в кулачном бою мне нет равных. Да и считай учу задаром|Вначале помоги мне стать сильнее|str|Можешь научить рукопашной схватке?|hand|А как насчет меча?|cold|В другой раз|end";
        //        arr_speak["npc.Markus"]["str"] = "Нет проблем, для человека, каждый день показывающего пример зеленым салагам, это раз плюнуть. Хм... 80 монет найдется?|Найдется!|strnow|Я передумал|tren";
        //        arr_speak["npc.Markus"]["strnow"] = "skill|str|80|0|3";
        //        arr_speak["npc.Markus"]["hand"] = "Все очень просто: сила и навык. И то и то влияет на мощь удара, и не забывай про ловкость, иначе твой кулак скользнет мимо наглой рожи твоего врага. [улыбается] Хотя, если честно, кулаком промазать сложно. Это ведь тебе не меч, и тем более не лук. Гони сотню монет.|Держи сотню монет|handnow|Я передумал|tren";
        //        arr_speak["npc.Markus"]["handnow"] = "skill|hand|100";
        //        arr_speak["npc.Markus"]["cold"] = "C этим сложней. Конечно, я не лопух, но вряд ли смогу показать что-то, чего не смог бы Кантарес. Хотя для начала сойдет, [зубоскалит] чтоб ты сам не сошел на завтрак какому-нибудь орку. Хей, не забудь 80 монет!|Ближе к делу!|coldnow|Я передумал|tren";
        //        arr_speak["npc.Markus"]["coldnow"] = "skill|coldweapon|80|0|2";
        //        arr_speak["npc.Markus"]["end"] = "[дружески хлопает вас спине] Заходи в любое время, <name>!";

        //        arr_speak["npc.Sloven"] = new Dictionary<string, string>();
        //        arr_speak["npc.Sloven"]["begin"] = "Приветствую в моем магазине снаряжения, <name>. Я продаю и покупаю почти все. Ценами тоже не обижаю.|Покажи свои товары|buy|Я хочу продать|sell|Где мне найти охотников?|oh|Нет, ничего, в другой раз|end";
        //        arr_speak["npc.Sloven"]["oh"] = "Ха! Глянь у ворот или за ними, кто-нибудь обязательно там торчит. Этот народ так и снует туда-сюда.|Покажи свои товары|buy|Я хочу продать|sell";
        //        arr_speak["npc.Sloven"]["end"] = "Будь осторожен в лесу";

        //        arr_speak["npc.Yan"] = new Dictionary<string, string>();
        //        arr_speak["npc.Yan"]["begin"] = "Привет|Расскажи мне об охоте|hunt|Ты можешь меня чему-нибудь научить?|tren|Мне пора|end";
        //        arr_speak["npc.Yan"]["hunt"] = "Хм.. а что там рассказывать? Подстрели зверюгу, разделай тушу любым ножом (мечи и кинжалы не годятся!), а что с нее снимешь тащи в город и продавай. Весьма неплохой бизнес, да и относительно спокойный. Если не считать, что иногда в лесах стречаются монстры. Но эnо уже как повезет... Больше всего зверья в западном лесу, туда мы в основном и ходим. Но будь осторожен, не давно там видели настоящего тролля!|Ясно, можешь меня потренировать?|tren";
        //        arr_speak["npc.Yan"]["tren"] = "Каждый, кто способен выжить в лесу, может многому научить. Что тебя интересует?|Как повысить ловкость|dex|Стрельба из лука|luk|Незаметность|hide|Осторожность|look|Изучение животных|lore|Лечение ран|heal|Ничего, я передумал|begin";
        //        arr_speak["npc.Yan"]["dex"] = "Ловкость очень важна дял стрелка. И не надо улыбаться, я имел ввиду меткость, а не умение драпать от первого же зайца, оскалившего зубы :-) Готов расстаться с 90 монетами?|Готов|dexnow|Неа|tren";
        //        arr_speak["npc.Yan"]["dexnow"] = "skill|dex|90|0|4";
        //        arr_speak["npc.Yan"]["luk"] = "Просто целься лучше, да сильней оттягивай тетиву. Или возьми арбалет, там сила нужна лишь чтобы его таскать, весит эта бандура ого-го! Давай 120 монет.|Держи|luknow|Обойдешься|tren";
        //        arr_speak["npc.Yan"]["luknow"] = "skill|ranged|120|0|4";
        //        arr_speak["npc.Yan"]["hide"] = "Скрытность позволяет незаметно подкрасться к врагу, да и потихоньку отойти, если он слишком для тебя силен тоже. Вполне удобный навык для рискованного охотника. И всего за 150 монет.|Ок, согласен|hidenow|Извини, в другой раз|tren";
        //        arr_speak["npc.Yan"]["hidenow"] = "skill|hiding|150|0|4";
        //        arr_speak["npc.Yan"]["look"] = "Да, для выслеживания дичи навык что надо - ты должен быть не только незаметным, но и не пропускать мелких деталей, чтобы выскочивший из чащи медведь не стал для тебя неожиданностью. К тому же и в городе поможет быть начеку, чтобы тебя не очистили воры. Стоит это 180 монет|Готов|looknow|Неа|tren";
        //        arr_speak["npc.Yan"]["looknow"] = "skill|look|180|0|4";
        //        arr_speak["npc.Yan"]["lore"] = "Хочешь уметь обращаться с животными? Я могу помочь, правда сам не много знаю. А вот на севере отсюда есть каменый дом, в нем Лексли, вот кто разбирается в животных, они у него лучшие друзья и слушаются его с полуслова. Я могу научить тебя азам изучения животных за 150 монет.|Давай|lorenow|Нет|tren";
        //        arr_speak["npc.Yan"]["lorenow"] = "skill|animallore|150|0|3";
        //        arr_speak["npc.Yan"]["heal"] = "Раны заживают со скоростью, которая зависит от особенностей организма, но я знаю пару трюков, которые позволят тебе дотянуть до города в таких пердрягах, из которой бы не вышел никто другой! За 180 монет.|Давай|healnow|Нет|tren";
        //        arr_speak["npc.Yan"]["healnow"] = "skill|regeneration|180|0|2";
        //        arr_speak["npc.Yan"]["end"] = "Будь осторожен в лесу";

        //        arr_speak["npc.Leksli"] = new Dictionary<string, string>();
        //        arr_speak["npc.Leksli"]["begin"] = "Здавствуй, <name>, что тебя сюда привело?|Ты можешь меня чему-нибудь научить?|tren|Ты чем-нибудь торгуешь?|trade|Расскажи о здешних местах|tell|Случайность|end";
        //        arr_speak["npc.Leksli"]["trade"] = "Да, я покупаю шкуры животных, да и продаю помаленьку что есть|Покажи свои товары|buy|У меня есть что продать|sell|Ясно|begin";
        //        arr_speak["npc.Leksli"]["tell"] = "Ну, в западном лесу полно дичи, в северном тоже, но там места какие-то гиблые, да и восточное кладбище близко, еще напорешься на какую-нибудь нежить. А в остальном нчиего особенного, места здесь глухие...|Ясно|begin";
        //        arr_speak["npc.Leksli"]["tren"] = "Я могу научить тебя обращению с животными.|Что насчет Изучения животных?|lore|Как приручать животных?|tame|В другой раз|begin";
        //        arr_speak["npc.Leksli"]["lore"] = "Секрет прост - надо быть с ними вежливым. Звери понимают куда больше, чем принято считать. В основном, правда они судят по эмоциям, поэтому говори уверенно и спокойно, правильным тоном можно остановить даже разъяренного волка. Только действует это исключительно на животных, а на монстров нет. 200 монет тебя не затруднят?|Я согласен|lorenow|К сожалению, затруднят|tren";
        //        arr_speak["npc.Leksli"]["lorenow"] = "skill|animallore|200|1";
        //        arr_speak["npc.Leksli"]["tame"] = "С приручением используются почти то же, что и с изучением - надо дать понять звурю, что ты не желаешь ему зла. Все остальное - просто сведения о повадках тех или иных животных. 200 монет и я расскажу какие именно.|Всего-то? Я готов слушать|tamenow|Упс, в другой раз|tren";
        //        arr_speak["npc.Leksli"]["tamenow"] = "skill|animaltaming|200";
        //        arr_speak["npc.Leksli"]["end"] = "Будь здоров";

        //        arr_speak["npc.Batist"] = new Dictionary<string, string>();
        //        arr_speak["npc.Batist"]["begin"] = "Кого тут еще черти носят?|Кто ты?|who|Будь вежливей, говорят, помогает|end";
        //        arr_speak["npc.Batist"]["who"] = "Я просто живу здесь и хотел бы, чтобы меня никто не беспокоил.|Как же ты выжил в лесу?|who2";
        //        arr_speak["npc.Batist"]["who2"] = "Ничего сложного, уметь надо. Никогда не любил города - шум и гам сплошной. То ли дело здесь - красота, никто небя не тревожит...|Что именно надо уметь?|tren|Разве здесь не опасно?|danger|Тогда и я тебя не буду тревожить, пока|end";
        //        arr_speak["npc.Batist"]["tren"] = "Ну, понимаешь, есть навыки, когда раны заживают сами собой, причем раны любой сложности. А уж еду всегда найдешь в лесу. Если хочешь, я научу тебя как без ничего заживлять раны. Но не задаром, за 250 монет.|Держи деньги, учи|trennow|В другой раз|who2";
        //        arr_speak["npc.Batist"]["trennow"] = "skill|regeneration|250";
        //        arr_speak["npc.Batist"]["danger"] = "Ну, бывают и сложности. Порой выйдут чудища какие из леса, переворошат дом. Но окромя съестного, ничего не трогают, да и уйдут обратно в лес. Как ни странно, приходят в основном с запада, хотя там глушь вроде сплошная.";
        //        arr_speak["npc.Batist"]["end"] = "Счастливо, не суйся на запад";

        //        arr_speak["npc.Djon"] = new Dictionary<string, string>();
        //        arr_speak["npc.Djon"]["begin"] = "Дяденька, вы не от Фредерика случайно?|Нет, кто такой Фредерик|no|Может и от него...|yes|Не путайся под ногами, малыш|end";
        //        arr_speak["npc.Djon"]["yes"] = "Вот здорово, значит вы разберетесь с этими тварями на складе? Спасибо!";
        //        arr_speak["npc.Djon"]["no"] = "Жаль, эти крысы меня совсем замучили... Не дают войти на склад и все тут...|Тебя испугали крысы???|no2|Сиди дома, если боишься крыс. И носи юбку.|dom|Ух, такая страшная беда, пойду-ка я отсюда подальше1|end";
        //        arr_speak["npc.Djon"]["no2"] = "А где это видано, чтобы крысы бросались на человека? А эти бросаются! Как хотите, а я туда ни ногой!|Ладно, разберемся|end";
        //        arr_speak["npc.Djon"]["dom"] = "[обиженно сопит] Как обзываться, так все мастера, а вот как бы вас самих оттуда не пришлось крюками вытаскивать...|Что там с этими крысами?|no2|Сопляк ты еще со мной так разговаривать!|end";
        //        arr_speak["npc.Djon"]["end"] = "Будьте осторожней там, дяденька!";

        //        arr_speak["npc.Gregg"] = new Dictionary<string, string>();
        //        arr_speak["npc.Gregg"]["begin"] = "Что тебе надо, чуждестранец? Лучше убирайся подобру-поздорову, иначе у тебя должны быть очень, повторяю, очень веские причины сюда войти!|Не очень-то вежливо|st|Иди сам к черту!|end";
        //        arr_speak["npc.Gregg"]["st"] = "Можешь засунуть свою вежливость себе в задницу, понял? Это мой дом и я здесь хозяин! [Cтоун в стороне робко: но отец...] [обращается к Стоуну] а ты не лезь, когда я разговариваю с 'гостями'!|А чем парень тебе не угодил, или может просто ты оттоптал левую ногу, когда вставал с кровати?|st2|Занесло же меня к психу...|end";
        //        arr_speak["npc.Gregg"]["st2"] = "Не твое дело! С этим ничтожеством я сам разберусь без твоего не в меру любознательного носа!|И все-таки, это парень не похож на лентяя или прохвоста|st3|Ты меня достал|end";
        //        arr_speak["npc.Gregg"]["st3"] = "Он не лентяй и не прохвост, а намного хуже - вор! Только потому что он мой сын, я не позвал стражу.|[язвительно] Хотите, я позову?|st4|Вор? Это меняет дело|st5|Ты меня достал|end";
        //        arr_speak["npc.Gregg"]["st4"] = "Гхм.. [смутился] Не стоит, я погорячился и наговорил лишнего.|То-то же, впредь не горячись|st5|Ладно, мне пора|end";
        //        arr_speak["npc.Gregg"]["st5"] = "Ну, обычная история, парень влюбился, но собственного заработка у него нет, вот и позарился на отцовское ожерелье. [Cтоун: да не брал я его!] Как же, признается он...|Но он правда не брал!|st6|Ремень по твоему сыну плачет, вот что|end";
        //        arr_speak["npc.Gregg"]["st6"] = "А ты откуда это можешь знать? Дружок этого ... или может это ты взял?|Может и я, да доказательств у тебя нет|end|Ну, скажем так, это может быть, например, сын бывшего вора или что-то в этом роде...|st7";
        //        arr_speak["npc.Gregg"]["st7"] = "Как же, так я и поверил, я знаю в городе только одного человека, способного на это - Сурри, что живет на западе города в заброшенном доме, но чтобы его отпрыск пошел по стопам отца, это вряд ли. Мой вот не пошел ведь, не стал честным человеком!|Яблоко от яблони недалеко падает|end";
        //        arr_speak["npc.Gregg"]["end"] = "Проваливай, а? И без тебя забот хватает.";

        //        arr_speak["npc.Stoun"] = new Dictionary<string, string>();
        //        arr_speak["npc.Stoun"]["begin"] = "Сейчас не лучшее время для разговоров, видишь в каком состоянии [косится на Грегга] мой отец?|Я знаю, что ты невиновен|st|Ты пошто ожерелье спер, негодяй?|end";
        //        arr_speak["npc.Stoun"]["st"] = "Правда? Я тоже это знаю, но доказать ничего не могу. Думаю, ожерелье само найдется или обнаружат вора и все уладится.";
        //        arr_speak["npc.Stoun"]["end"] = "[задыхаясь от гнева] Да.. Как ты.. [вдруг смолкает, глянув на Грэгга] А, иди ты к черту, вот что. Не твое это дело.";

        //        arr_speak["npc.Silvio"] = new Dictionary<string, string>();
        //        arr_speak["npc.Silvio"]["begin"] = "Привет, я Сильвио, продаю и покупаю магические реагенты. Еще я покупаю кости скелетов, если найдешь, принеси мне.|Покажи свои товары|buy|Я хочу продавать|sell|Где мне достать реагенты?|find|Кости?|bone|Я спешу|end";
        //        arr_speak["npc.Silvio"]["find"] = "Поищи в округе, по лесам, на болотах. Может что и на кладбище найдешь. Это твои трудности, если бы это было так легко, я бы сам насобирал.|Ясно|begin";
        //        arr_speak["npc.Silvio"]["bone"] = "Ну да, кости, они используются в некоторых магических ритуалах...|Например, в некромантии?|bone2|Забудем об этом|begin";
        //        arr_speak["npc.Silvio"]["bone2"] = "Что ты, какая некромантия, она вообще запрещена законом, я.. ну.. просто... ну..,  в принципе, это тебя не касается, просто если будут кости, то я их у тебя куплю, ок?|Видимо эта причина мешает тебе торговать в городе?|bone3|Забудем об этом|begin";
        //        arr_speak["npc.Silvio"]["bone3"] = "Ты на что намекаешь? Я ведь живу в городе, значит я не преступник, так ведь? Слушай, в конце концов, разве кто-то еще у тебя хочет купить кости? Нет, только я, так что давай если хочешь продавай, иначе не трать мое время. А если ты от этих..этих..бумагомарателей из Академии, то можешь им передать, что ничего они от меня не получат. Я чист, ясно тебе?|Хм... Дело твое. Каждый имеет право быть придурком.|end2|Хм... Дело твое. Каждый имеет право на тайну.|end";
        //        arr_speak["npc.Silvio"]["end2"] = "Пошел ты к черту!";
        //        arr_speak["npc.Silvio"]["end"] = "Тогда пока";

        //        arr_speak["npc.Franchesko"] = new Dictionary<string, string>();
        //        arr_speak["npc.Franchesko"]["begin"] = "Здавствуй, <name>. Академия приветствует тебя!|Ты глава Академии?|who|Я хочу пополнить припасы|shop|Что тут интересного?|who2|Извини, я спешу|end";
        //        arr_speak["npc.Franchesko"]["who"] = "[смеется] Что ты, я даже не прошел Круг Посвящения, просто в мои обязанности входит встречать гостей и рассказывать им об Академии.|Ну раз так, расскажи и мне|who2|Хм, я и так достаточно знаю|begin";
        //        arr_speak["npc.Franchesko"]["who2"] = "Академия - это сосредоточие всех наук, здесь обучаются магии и хранятся знания поколений. Вон там библиотека, где ты можешь узнать историю города, рядом дверь в зал монстрологии, Серпент расскажет тебе об удивительных созданиях, направо наш волшебный магазин, а на втором этаже аколиты тренируются в магии под руководством Антонио и Мильтона.|Молодец, ставлю пять за экскурсию|end";
        //        arr_speak["npc.Franchesko"]["shop"] = "Тогда сразу иди в волшебный магазин, первая дверь направо. Только в Академии такой широкий выбор товаров. Цены пусть тебя не смущают, здесь только первосортный товар, проверенный и надежный.|Спасибо, ты очень добр|end";
        //        arr_speak["npc.Franchesko"]["end"] = "[смущенно] До свидания, желаю успехов";

        //        arr_speak["npc.Djoshua"] = new Dictionary<string, string>();
        //        arr_speak["npc.Djoshua"]["begin"] = "Добро пожаловать! Мы продаем и покупаем магические товары, если хочешь что-то продать, передай мне предмет и я назову его цену.|Покажи свои товары|buy|Я хочу кое-что продать|sell|Мне пора|end";
        //        arr_speak["npc.Djoshua"]["end"] = "Двери магазина Академии всегда открыты";

        //        arr_speak["npc.Klavdius"] = new Dictionary<string, string>();
        //        arr_speak["npc.Klavdius"]["begin"] = "Приветствую тебя в этих мудрых стенах библиотеки, мой юный друг! Ты хотел бы что-то узнать о нашем городе?|Расскажи об этом городе|tell|Нет. В самом деле нет. Не хочу. Совершенно.|end";
        //        arr_speak["npc.Klavdius"]["tell"] = "Город был основан триста лет назад северянами, в те годы у них на родине прошли небывалые морозы. Не только люди, даже звери бежали! А после морозов пришла другая беда: разупокаивались кладбища, мертвяки поперли на, в общем-то незащищенные города, т.к. в тех безлюдных местах не с кем было особо воевать и жили преимущественно охотники да животноводы. Именно способности к охоте и спасли их, многие смогли подняться и уйти, после чего ообосноваться здесь.|Что было дальше?|tell2|Это слишком длинная история для меня|end";
        //        arr_speak["npc.Klavdius"]["tell2"] = "Тогда здесь были сплошные леса, и город, само собой, вырос у реки. Это уже потом приходили другие народы, кровь смешалась и сейчас кто только не живет в городе. Да и вокруг уже не непролазные чащобы, все дальше и дальше осваивается лес, строятся дома, прокладываются дороги. Хочешь об этом месте?|Да, хочу|tell3|Нет, с меня хватит, спасибо|end";
        //        arr_speak["npc.Klavdius"]["tell3"] = "С юга город омывается рекой, на востоке лес простирается вплоть до самих Скалистых гор, на севере тоже леса, правда подвластныя нечисти: разным духам и призракам, на западе Столетний лес, там много всякого зверья и сплошная глушь, ничего интересноего. А вот на северо-востоке расположено беспокойное старое кладбище, туда идет весь рискованный народ, им подавай настоящий смертельный бой, славу да почет. Городу это, конечно, на руку - все да меньше будет мертвечины разгуливать.|Откуда взялись мертвяки?|tell4|Я все понял|end";
        //        arr_speak["npc.Klavdius"]["tell4"] = "С юга город омывается рекой, на востоке лес простирается вплоть до самих Скалистых гор, на севере тоже леса, правда подвластныя нечисти: разным духам и призракам, на западе Столетний лес, там много всякого зверья и сплошная глушь, ничего интересноего. А вот на северо-востоке расположено беспокойное старое кладбище, туда идет весь рискованный народ, им подавай настоящий смертельный бой, славу да почет. Городу это, конечно, на руку - все да меньше будет мертвечины разгуливать.|Откуда берутся мертвяки?|tell5|Я все понял|end";
        //        arr_speak["npc.Klavdius"]["tell5"] = "Никто не знает, может быть в одном из склепов есть тайный вход в подземелья, а может ветер магии иногда меняет течение и будоражит тех, у кого в костях еще осталлась капелька жизни. В последние годы вообще много странного происходит...|Что именно?|tell6|Ясно|end";
        //        arr_speak["npc.Klavdius"]["tell6"] = "[испытующе смотрит на вас, потом качает головой, видимо приняв какое-то решение] Нет, не время еще тебе об этом знать, извини. Может как-нибудь в другой раз расскажу...|Больно нужны мне твои тайны, прощай|end";
        //        arr_speak["npc.Klavdius"]["end"] = "Ну что ж, приходи еще как-нибудь";

        //        arr_speak["npc.Antonio"] = new Dictionary<string, string>();
        //        arr_speak["npc.Antonio"]["begin"] = "Здравствуй, <name>, хочешь узнать больше о магии?|Да, расскажи о магии|mag|Ты можешь меня чему-нибудь научить?|tren|Нет, пока|end";
        //        arr_speak["npc.Antonio"]["mag"] = "Хорошо, главное что тебе надо знать - чем опытней ты как маг, тем легче тебе будут удаваться сложные заклинания. А уж как их кастовать - из книги магии, используя магические реагенты, с одноразовых свитков или из рун, решать тебе.|Расскажи о рунах|run|Где я еще могу изучать магию?|more|Ясно|begin";
        //        arr_speak["npc.Antonio"]["run"] = "Руны - это такие камни с символами, если ты используешь руну, то записанное на ней заклинание тратит только твою ману, а реагенты не нужны. Это очень удобно, так как мана со временем растет сама. И именно поэтому руны такие дорогие, так как позволяют сколько угодно колдовать, не платя за свитки или реагенты.|Ясно|mag";
        //        arr_speak["npc.Antonio"]["more"] = "О боевой магии тебе расскажет Мильтон, о Вызове животных - Серпент на первом этаже. Кроме того, Лорд Хаген во дворе рыцарей владеет палладинской магией, можешь сходить и туда. Ну и я тоже могу тебя кое-чему научить...|Я хочу учиться|tren|Ясно|mag";
        //        arr_speak["npc.Antonio"]["tren"] = "Выбери, что тебя интересует|Я хочу повысить интеллект|int|Медитация|med|Я хочу выучить заклинания|spell|Нет, ничего|begin";
        //        arr_speak["npc.Antonio"]["spell"] = "Я могу научить тебя следующим заклинаниям:|Создать еду|create|Лечение|heal|Исцеление|healgr|Воскрешение|res|Пометить|mark|Возвращение|recall|Я передумал|tren";
        //        arr_speak["npc.Antonio"]["int"] = "Интеллект очень важен дял мага, так как он определяет твой запас маны. Я помогу развить твой интеллект за 150 монет|Согласен|intnow|Я передумал|tren";
        //        arr_speak["npc.Antonio"]["intnow"] = "skill|int|150";
        //        arr_speak["npc.Antonio"]["med"] = "Навык медитации тоже очень важен для мага, он определяет, насколько выстро восстанавливается твоя мана. А кроме того, ты можешь использовать этот навык напрямую, тогда мана восстановится еще быстрее. Но учти, что у тебя должно быть время и никто не должен нарушать твоей концентрации, иначе ничего не получится... Я научу тебя за 300 монет|Согласен|mednow|Не надо|tren";
        //        arr_speak["npc.Antonio"]["mednow"] = "skill|meditation|300";
        //        arr_speak["npc.Antonio"]["create"] = "Это заклинание позволяет создать еду. [улыбается ]Очень удобно, если тебе нужно подкрепиться. Да и не сложное оно, идеально подходит для тренировки. Стоит 100 монет|Согласен|createnow|Не надо|tren";
        //        arr_speak["npc.Antonio"]["createnow"] = "magic|magic.createfood|100";
        //        arr_speak["npc.Antonio"]["heal"] = "Немного залечивает раны. Стоит 200 монет|Согласен|healnow|Не надо|tren";
        //        arr_speak["npc.Antonio"]["healnow"] = "magic|magic.heal|200";
        //        arr_speak["npc.Antonio"]["healgr"] = "Залечивает сильные раны. Сложней, чем простое лечение. Стоит 400 монет|Согласен|healgrnow|Не надо|tren";
        //        arr_speak["npc.Antonio"]["healgrnow"] = "magic|magic.heal.great|400";
        //        arr_speak["npc.Antonio"]["res"] = "Позволяет оживить призрака. Очень сложное заклинание. Стоит 1000 монет|Согласен|resnow|Не надо|tren";
        //        arr_speak["npc.Antonio"]["resnow"] = "magic|magic.ressurect|1000|3";
        //        arr_speak["npc.Antonio"]["mark"] = "Позволяет пометить руну перемещения, если потом использовать на нее заклинание Возвращение, то будешь мгновенно перенесен в это место. Стоит 500 монет|Согласен|marknow|Не надо|tren";
        //        arr_speak["npc.Antonio"]["marknow"] = "magic|magic.mark|500";
        //        arr_speak["npc.Antonio"]["recall"] = "Это заклинание нужно использовать на руну перемещения (неважно, твою или кто ее тебе даст), и ты будешь тут же перенесен в это место! Стоит 500 монет|Согласен|recallnow|Не надо|tren";
        //        arr_speak["npc.Antonio"]["recallnow"] = "magic|magic.recall|500";
        //        arr_speak["npc.Antonio"]["end"] = "Ступай с миром";

        //        arr_speak["npc.Serpent"] = new Dictionary<string, string>();
        //        arr_speak["npc.Serpent"]["begin"] = "Добро пожаловать в зал монстрологии, уважаемый <name>. Здесь ты можешь узнать о волшебных существах, развить некотоыре свои навыки и выучить новые заклинания.|Что за волшебные животные?|mag|Я хочу пройти обучение|tren|Нет, пока|end";
        //        arr_speak["npc.Serpent"]["mag"] = "Хм.. На свете много чудес, оглянись вокруг, видишь эти чучела и картины? Это лишь малая толика того, что есть в этом мире. Но тебя наверно интересуют более приземленные вещи, я прав?|Расскажи о призываемых|run|Какие монстры есть в окрестностях?|more|Рад бы поболтать, но дела не ждут|begin";
        //        arr_speak["npc.Serpent"]["run"] = "Те животные, которых ты можешь призвать, отличаются от обычных. Их нельзя освежевать после их гибели, они исчезают когда истечет их срок в жтом мире и тому подобное. Хоть их названия как и у зверей или монстров, встречаемых на свободе, характеристики вызываемых могут сильно отличаться.|Ясно|mag";
        //        arr_speak["npc.Serpent"]["more"] = "В окрестных лесах много чего ходит... Обычное зверье на тебя не нападет первым, кроме хищшиков, конечно. А вот если повстречает чудовище или нежить, тут даже и не пробуй договориться. [улыбается ]Ну разве только с помощью магии.|Ясно|mag";
        //        arr_speak["npc.Serpent"]["tren"] = "Выбери, что тебя интересует|Я хочу узнать о спиритизме|spir|Я хочу выучить заклинания|spell|Нет, ничего|begin";
        //        arr_speak["npc.Serpent"]["spell"] = "Я могу научить тебя следующим заклинаниям:|Призвать Волка|wolf|Призвать Скелета|skel|Призвать Голема|gol|Призвать Демона|dem|Зачаровать|charm|Привлечь|charme|Усмирить|peace|Тишина|pall|Безумие|sil|Я передумал|tren";
        //        arr_speak["npc.Serpent"]["spir"] = "Как ты знаешь, человек после смерти становится призраком. Чтобы он ни сказал, никто его не поймет. Но если развить свой навык спиритизма, то на высшем уровне ты сможешь понять абсолютно любого призрака! Я научу тебя как это делать за 70 монет|Согласен|spirnow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["spirnow"] = "skill|spirit|70";
        //        arr_speak["npc.Serpent"]["wolf"] = "Это заклинание стоит 200 монет|Согласен|wolfnow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["wolfnow"] = "magic|magic.summon.wolf|200";
        //        arr_speak["npc.Serpent"]["skel"] = "Это заклинание стоит 300 монет|Согласен|skelnow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["skelnow"] = "magic|magic.summon.skeleton|300";
        //        arr_speak["npc.Serpent"]["gol"] = "Это заклинание стоит 400 монет|Согласен|golnow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["golnow"] = "magic|magic.summon.golem|400";
        //        arr_speak["npc.Serpent"]["dem"] = "Это заклинание стоит 500 монет. Если призовешь демона в городе, на тебя набросится стража.|Согласен|demnow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["demnow"] = "magic|magic.summon.demon|500";
        //        arr_speak["npc.Serpent"]["charm"] = "Позволяет зачаровать ненадолго животное, оно будет повсюду следовать за вами. Стоит 300 монет|Согласен|charmnow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["charmnow"] = "magic|magic.charm|300";
        //        arr_speak["npc.Serpent"]["charme"] = "Позволяет привлечь на свою сторону одного врага. Стоит 400 монет|Согласен|charmenow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["charmenow"] = "magic|magic.charm.enemy|400";
        //        arr_speak["npc.Serpent"]["peace"] = "Один враг на время забывает о тебе. Стоит 300 монет|Согласен|peacenow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["peacenow"] = "magic|magic.peace|300";
        //        arr_speak["npc.Serpent"]["pall"] = "На время успокаиваются все враждующие стороны. Стоит 500 монет|Согласен|pallnow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["pallnow"] = "magic|magic.silence|500";
        //        arr_speak["npc.Serpent"]["mad"] = "Кто-то из присутствующих впадает в безумие и набрасывается на другого, неважно, зверь то или человек. Стоит 1000 монет|Согласен|madnow|Не надо|tren";
        //        arr_speak["npc.Serpent"]["madnow"] = "magic|magic.maddnes|1000";
        //        arr_speak["npc.Serpent"]["end"] = "Ступай с миром";

        //        arr_speak["npc.Milton"] = new Dictionary<string, string>();
        //        arr_speak["npc.Milton"]["begin"] = "Рад тебя видеть, <name>. Хочешь развить свою магию или выучить новые боевые заклинания?|Я хочу развить навыки|tren|Я хочу выучить заклинания|spell|Нет, пока|end";
        //        arr_speak["npc.Milton"]["tren"] = "Хорошо, вот магические навыки, которым я могу тебя обучить:|Магия|mag|Уклонение от магии|ukl|Сопротивление магии|resist|Я лучше изучу заклинания|spell|Спасибо, мне пора|end";
        //        arr_speak["npc.Milton"]["mag"] = "Навык магии определяет вероятность успешного заклинания. Кроме того, от навыка магии зависит, какой сложности заклинания доступны магу. Так, с низким уровнем, маг вообще не сможет использовать сложные заклинания. По сути, этот навык и интеллект - главные параметры мага. Я научу тебя за 200 монет.|Согласен|magnow|Не надо|tren";
        //        arr_speak["npc.Milton"]["magnow"] = "skill|magic|200";
        //        arr_speak["npc.Milton"]["ukl"] = "В случае успеха маг может вообще избежать урона от магической атаки. И хоть это бывает редко, но стоит 200 монет, как думаешь?|Верно|uklnow|Я так не думаю|tren";
        //        arr_speak["npc.Milton"]["uklnow"] = "skill|magic_uklon|200";
        //        arr_speak["npc.Milton"]["resist"] = "Сопротивление магии не так эффективно, как уклонение, но зато получается гораздо чаще. В случае успеха урон от магической атаки уменьшается. Стоимость обучени 200 монет.|Хорошо|resistnow|Нет, не пойдет|tren";
        //        arr_speak["npc.Milton"]["resistnow"] = "skill|magic_resist|200";
        //        arr_speak["npc.Milton"]["spell"] = "Выбери, какое заклинание тебя интересует|Магическая стрела|mar|Огненная стрела|far|Ледяной кулак|lk|Огненный столб|fb|Ледяной луч|ll|Струя пламени|fs|Молния|li|Водяной вал|lv|Землетрясение|zt|Что насчет навыков?|tren|Спасибо, мне пора|end";
        //        arr_speak["npc.Milton"]["mar"] = "Самое слабое боевое заклинание. Стоит 50 монет|Согласен|marnow|Не надо|tren";
        //        arr_speak["npc.Milton"]["marnow"] = "magic|magic.war.arrow|50";
        //        arr_speak["npc.Milton"]["far"] = "Стоит 100 монет|Согласен|farnow|Не надо|tren";
        //        arr_speak["npc.Milton"]["farnow"] = "magic|magic.war.firearrow|100";
        //        arr_speak["npc.Milton"]["lk"] = "Это заклинание может причить уже существенный урон. Стоит 150 монет|Согласен|lknow|Не надо|tren";
        //        arr_speak["npc.Milton"]["lknow"] = "magic|magic.war.icefirst|150";
        //        arr_speak["npc.Milton"]["fb"] = "Среднее боевое заклинание. Стоит 250 монет|Согласен|fbnow|Не надо|tren";
        //        arr_speak["npc.Milton"]["fbnow"] = "magic|magic.war.firebolt|200";
        //        arr_speak["npc.Milton"]["ll"] = "Одно из самых мощных боевых заклинаний. Стоит 350 монет|Согласен|llnow|Не надо|tren";
        //        arr_speak["npc.Milton"]["llnow"] = "magic|magic.war.iceray|350";
        //        arr_speak["npc.Milton"]["fs"] = "Лучшее из боевых заклинания на одну цель. Стоит 500 монет|Согласен|fsnow|Не надо|tren";
        //        arr_speak["npc.Milton"]["fsnow"] = "magic|magic.war.firestreem|500";
        //        arr_speak["npc.Milton"]["lv"] = "Ледяной вал наносит урон всем, кроме кастующего. Стоит 400 монет|Согласен|lvnow|Не надо|tren";
        //        arr_speak["npc.Milton"]["lvnow"] = "magic|magic.all.watergross|400";
        //        arr_speak["npc.Milton"]["li"] = "Молния может как не нанести урон, так и сжечь на месте. Стоит 300 монет|Согласен|linow|Не надо|tren";
        //        arr_speak["npc.Milton"]["linow"] = "magic|magic.war.lighting|300";
        //        arr_speak["npc.Milton"]["zt"] = "Наносит большой урон всем, включая кастующего. Стоит 700 монет|Согласен|ztnow|Не надо|tren";
        //        arr_speak["npc.Milton"]["ztnow"] = "magic|magic.all.earthquake|700";
        //        arr_speak["npc.Milton"]["end"] = "Ступай с миром";

        //        arr_speak["npc.Raks"] = new Dictionary<string, string>();
        //        arr_speak["npc.Raks"]["begin"] = "Что тебе надо?|Я тоже хочу стать сильным, как ты!|tren|Ты чем-нибудь торгуешь?|ask|Ничего, до встречи!|end";
        //        arr_speak["npc.Raks"]["ask"] = "Я что, похож на торговца? Я делаю оружие и броню, а продают другие. Видишь вход на севере? Там бронник Силт, продает отличную броню, а на юге вход в магазин оружейника Планта.|Ясно, бывай|end";
        //        arr_speak["npc.Raks"]["tren"] = "Ха! Потягай с мое, станешь не хуже. Впрочем, за две сотни монет я тебе покажу пару трюков, как прокачать мышцы.|Согласен, вот деньги|trennow|Дорого берешь, мастер, в другой раз|end";
        //        arr_speak["npc.Raks"]["trennow"] = "skill|str|200";
        //        arr_speak["npc.Raks"]["end"] = "Ну и ты бывай!";

        //        arr_speak["npc.Silt"] = new Dictionary<string, string>();
        //        arr_speak["npc.Silt"]["begin"] = "Проходи, <name>, выбирай что нравится. У меня лучшая бронь во всем городе. Впрочем, я не только продаю, но и покупаю броню|Покажи свои товары|buy|Я хочу продать|sell|Хм.. мне не нужна броня|end";
        //        arr_speak["npc.Silt"]["end"] = "Понадобится надежная броня, приходи";

        //        arr_speak["npc.Plant"] = new Dictionary<string, string>();
        //        arr_speak["npc.Plant"]["begin"] = "Добро пожаловать, <name>. У меня все виды оружия, лучший выбор! А если хочешь что-нибудь продать, передай мне предмет, о цене сговоримся!|Ты можешь меня научить сражаться?|tren|Покажи свои товары|buy|Я хочу продать оружие|sell|Зайду в другой раз|end";
        //        arr_speak["npc.Plant"]["tren"] = "Если хочешь, научу владеть мечом. Не так здорово, как учат во дворе рыцарей, но и так уж никудышно, как у этих охотников [улыбается]. Это будет стоить тебе 180 монет.|Согласен, вот деньги|trennow|Я подумаю...|end";
        //        arr_speak["npc.Plant"]["trennow"] = "skill|coldweapon|180|0|4";
        //        arr_speak["npc.Plant"]["end"] = "Пока, заглядывай почаще";
        //    }

        //    #endregion

        //    public bool SpawnObject(string LocationID, string ObjectID)
        //    {
        //        if (!locations.ContainsKey(LocationID)) return false;
        //        if (items.ContainsKey(ObjectID))
        //        {
        //            for (int i = 0; i <= 999; i++)
        //            {
        //                if (!locations[LocationID].ContainsKey(ObjectID + "." + Convert.ToString(i)))
        //                {
        //                    locations[LocationID][ObjectID + "." + Convert.ToString(i)] = new _1Item(items[ObjectID]);
        //                    return true;
        //                }
        //            }
        //        }
        //        if (npcs.ContainsKey(ObjectID))
        //        {
        //            for (int i = 0; i <= 999; i++)
        //            {
        //                if (!locations[LocationID].ContainsKey(ObjectID + "." + Convert.ToString(i)))
        //                {
        //                    locations[LocationID][ObjectID + "." + Convert.ToString(i)] = new _1NPC(npcs[ObjectID]);
        //                    return true;
        //                }
        //            }
        //        }

        //        return false;
        //    }

        //}

        //public class _1Item
        //{
        //    public string title;
        //    public int count;
        //    public int cost;

        //    //food|bottle
        //    public int life;
        //    public int mana;

        //    //armor
        //    public int armor;

        //    //weapon
        //    public int damage_min;
        //    public int damage_max;
        //    public int str;
        //    public int speed;
        //    public string weaponby;
        //    public string need_id;
        //    public string needtitle;

        //    //For world or trader
        //    public int time;
        //    public string respawn; //time_min|time_max|count_min|count_max

        //    //Constructors
        //    public _1Item()
        //    {
        //    }

        //    //standart
        //    public _1Item(string title, int count, int cost)
        //    {
        //        this.title = title;
        //        this.count = count;
        //        this.cost = cost;
        //    }

        //    //food|bottle
        //    public _1Item(string title, int count, int cost, int life, int mana)
        //    {
        //        this.title = title;
        //        this.count = count;
        //        this.cost = cost;
        //        this.life = life;
        //        this.mana = mana;
        //        //
        //        /*this.armor = 0;
        //        this.damage_min = 0;
        //        this.damage_max = 0;
        //        this.str = 0;
        //        this.speed = 0;
        //        this.need_id = "";
        //        this.needtitle = "";*/
        //    }

        //    //armor
        //    public _1Item(string title, int count, int cost, int armor)
        //    {
        //        this.title = title;
        //        this.count = count;
        //        this.cost = cost;
        //        this.armor = armor;
        //    }

        //    //weapon
        //    public _1Item(string title, int count, int cost, int damage_min, int damage_max, int str, int speed, string weaponby, string need_id, string needtitle)
        //    {
        //        this.title = title;
        //        this.count = count;
        //        this.cost = cost;
        //        this.damage_min = damage_min;
        //        this.damage_max = damage_max;
        //        this.str = str;
        //        this.speed = speed;
        //        this.weaponby = weaponby;
        //        this.need_id = need_id;
        //        this.needtitle = needtitle;
        //    }

        //    //copy
        //    public _1Item(_1Item item)
        //    {
        //        this.title = item.title;
        //        this.count = item.count;
        //        this.cost = item.cost;
        //        //
        //        if (item.life != null) this.life = item.life;
        //        if (item.mana != null) this.mana = item.mana;
        //        //
        //        if (item.armor != null) this.armor = item.armor;
        //        //
        //        if (item.damage_min != null) this.damage_min = item.damage_min;
        //        if (item.damage_max != null) this.damage_max = item.damage_max;
        //        if (item.str != null) this.str = item.str;
        //        if (item.speed != null) this.speed = item.speed;
        //        if (item.weaponby != null) this.weaponby = item.weaponby;
        //        if (item.need_id != null) this.need_id = item.need_id;
        //        if (item.needtitle != null) this.needtitle = item.needtitle;
        //    }
        //}

        //public class _1Magic
        //{
        //    public string title;
        //    public int mana;
        //    public int level;
        //    public string say;
        //    public int damage_min;
        //    public int damage_max;
        //    public bool needtarget;
        //    public bool onlycrim;
        //    public int speed;
        //    public List<string> need = null; //"need_id|count|title"

        //    public _1Magic()
        //    {
        //    }

        //    public _1Magic(string title, int mana, int level, string say, int damage_min, int damage_max, bool needtarget, bool onlycrim, int speed)
        //    {
        //        this.title = title;
        //        this.mana = mana;
        //        this.level = level;
        //        this.say = say;
        //        this.damage_min = damage_min;
        //        this.damage_max = damage_max;
        //        this.needtarget = needtarget;
        //        this.onlycrim = onlycrim;
        //        this.speed = speed;
        //        this.need = new List<string>();
        //    }

        //    public _1Magic(_1Magic magic)
        //    {
        //        this.title = magic.title;
        //        this.mana = magic.mana;
        //        this.level = magic.level;
        //        this.say = magic.say;
        //        this.damage_min = magic.damage_min;
        //        this.damage_max = magic.damage_max;
        //        this.needtarget = magic.needtarget;
        //        this.onlycrim = magic.onlycrim;
        //        this.speed = magic.speed;
        //        this.need = new List<string>();
        //        this.need = magic.need;
        //    }
        //}

        //public class _1NPC
        //{
        //    //npc.
        //    public string title;
        //    public int life;
        //    public int life_max;
        //    public int mana;
        //    public int mana_max;
        //    public string speak;
        //    public bool bankir;
        //    public bool healer;
        //    public bool crim;
        //    public int tame; //Сложность приручения, 1..4
        //    public Dictionary<string, string> war = null; //hit|damage_min|damage_max|speed|ranged|armor|uklon|parring|shield|magic_uklon|magic_parring|magic_shield|weaponby|exp|need|needtitle
        //    public string attack; //ID атакуемого
        //    public Dictionary<string, string> bank = null;
        //    public Dictionary<string, string> items = null;
        //    public Dictionary<string, string> equip = null;
        //    public string respawn; //"loc|time_min|time_max"
        //    public Dictionary<string, string> osvej = null; //item_id=title:count:cost:param - param - эта строка добавляется к предметам трупа при освежевании ножом
        //    public string move; //num|time_min|time_max|onlyguard,time_nextmove,moved[]: id локаций, которые посетили
        //    public string trader; //price_buy|price_sell|period - коэф покупки|коэф продажи|период обновления
        //    public List<string> trader_filter = null;

        //    public _1NPC()
        //    {
        //    }

        //    public _1NPC(string title, int life, int life_max, string war, string speak = "")
        //    {
        //        this.title = title;
        //        this.life = life;
        //        this.life_max = life_max;

        //        this.mana = 0;
        //        this.mana_max = 0;
        //        this.speak = speak;
        //        this.bankir = false;
        //        this.healer = false;
        //        this.crim = false;
        //        this.tame = 0;

        //        string[] war_arr = war.Split('|');
        //        this.war = new Dictionary<string, string>();
        //        this.war["hit"] = war_arr[0];
        //        this.war["damage_min"] = war_arr[1];
        //        this.war["damage_max"] = war_arr[2];
        //        this.war["speed"] = war_arr[3];
        //        this.war["ranged"] = war_arr[4];
        //        this.war["armor"] = war_arr[5];
        //        this.war["uklon"] = war_arr[6];
        //        this.war["parring"] = war_arr[7];
        //        this.war["shield"] = war_arr[8];
        //        this.war["magic_uklon"] = war_arr[9];
        //        this.war["magic_parring"] = war_arr[10];
        //        this.war["magic_shield"] = war_arr[11];
        //        this.war["weaponby"] = war_arr[12];
        //        this.war["exp"] = war_arr[13];
        //        this.war["need"] = war_arr[14];
        //        this.war["needtitle"] = war_arr[15];

        //        this.attack = "";
        //        this.bank = new Dictionary<string, string>();
        //        this.items = new Dictionary<string, string>();
        //        this.equip = new Dictionary<string, string>();
        //        this.respawn = "";
        //        this.osvej = new Dictionary<string, string>();
        //        this.move = "";
        //        this.trader = "";
        //        this.trader_filter = new List<string>();
        //    }

        //    public _1NPC(_1NPC npc)
        //    {
        //        this.title = npc.title;
        //        this.life = npc.life;
        //        this.life_max = npc.life_max;
        //        this.mana = npc.mana;
        //        this.mana_max = npc.mana_max;
        //        this.speak = npc.speak;
        //        this.bankir = npc.bankir;
        //        this.healer = npc.healer;
        //        this.crim = npc.crim;
        //        this.tame = npc.tame;
        //        this.war = new Dictionary<string, string>(); this.war = npc.war;
        //        this.attack = npc.attack;
        //        this.bank = new Dictionary<string, string>(); this.bank = npc.bank;
        //        this.items = new Dictionary<string, string>(); this.items = npc.items;
        //        this.equip = new Dictionary<string, string>(); this.equip = npc.equip;
        //        this.respawn = npc.respawn;
        //        this.osvej = new Dictionary<string, string>(); this.osvej = npc.osvej;
        //        this.move = npc.move;
        //        this.trader = npc.trader;
        //        this.trader_filter = new List<string>(); this.trader_filter = npc.trader_filter;
        //    }
        //}

        //public class _1Player
        //{
        //    public string title;
        //    public int life;
        //    public int life_max;
        //    public int mana;
        //    public int mana_max;
        //    public bool crim;
        //    public DateTime time_crim;
        //    public bool ghost;
        //    public DateTime time_regenerate;
        //    public bool god;
        //    public string location;
        //    public Dictionary<string, string> war = null; //hit|damage_min|damage_max|speed|ranged|armor|uklon|parring|shield|magic_uklon|magic_parring|magic_shield|weaponby|exp|need|needtitle
        //    public string attack; //ID атакуемого
        //    public DateTime time_speed;
        //    public Dictionary<string, string> items = null;
        //    public Dictionary<string, string> equip = null;
        //    public Dictionary<string, int> skills = null; //str|dex|int|level|points|meditation|steal|animaltaming|hand|coldweapon|ranged|parring|uklon|magic|magic_resist|magic_uklon|regeneration|hiding|look|steallook|animallore|spirit
        //    public List<string> journal = null;

        //    public _1Player()
        //    {
        //    }

        //    public _1Player(string title, int life, int life_max, int mana, int mana_max, bool crim, bool ghost, string location, string war, string attack, string equip, string skills)
        //    {

        //    }

        //    public _1Player(string title, int life, int mana, string location, string war, string skills)
        //    {

        //    }

        //    public _1Player(_1Player player)
        //    {

        //    }
        //}
 
    }
}