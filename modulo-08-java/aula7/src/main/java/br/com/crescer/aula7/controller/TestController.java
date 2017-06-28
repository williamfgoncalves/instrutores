package br.com.crescer.aula7.controller;

import br.com.crescer.aula7.entity.Ator;
import br.com.crescer.aula7.service.AtorService;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

/**
 * @author carloshenrique
 */
@RestController
@RequestMapping("/ator")
public class TestController {

    @Autowired
    private AtorService atorService;

    @GetMapping("/current_date_time.php")
    public Map<String, Object> getCurrentDateTime() {
        final Map<String, Object> map = new HashMap();
        map.put("data", new Date());
        return map;
    }

    @GetMapping("/{id}")
    public Ator findOne(@PathVariable("id") Long id) {
        return atorService.findOne(id);
    }

    @ResponseBody
    @GetMapping
    public Page<Ator> findAll() {
        return atorService.findAll();
    }

    @PostMapping
    public List<Ator> list(@RequestBody Ator a) {
        return Stream.of(a).collect(Collectors.toList());
    }
}
